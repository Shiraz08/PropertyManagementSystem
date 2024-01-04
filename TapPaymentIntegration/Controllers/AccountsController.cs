using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models.Email;
using Property_Management_Sys.Models.Roles;

namespace Property_Management_Sys.Controllers
{
 
    public class AccountsController : Controller
    {
        private readonly ILogger<Agreement_FormController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public AccountsController(IWebHostEnvironment Environment, ILogger<Agreement_FormController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        #region Identity
          public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Accounts", new { token, email = user.Email }, Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, "Reset password Email", "For Reset Passowrd Click This: <a href='" + callback + "'>Link</a>");
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword change)
        {
            var user = await _userManager.GetUserAsync(User); 
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, change.OldPassword, change.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            user.Password = change.NewPassword;
            _context.Users.Update(user);
            await _signInManager.RefreshSignInAsync(user);
            ModelState.AddModelError(string.Empty, "Your password has been changed.");
            return View();
        }
        [Authorize]
        public IActionResult ChangeProfile()
        {
            UpdateProfile updateProfile = new UpdateProfile();
            updateProfile.Email = GetCurrentUserAsync().Result.Email;
            updateProfile.PhoneNumber = GetCurrentUserAsync().Result.PhoneNumber;
            return View(updateProfile);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeProfile(UpdateProfile change)
        { 
            var user = await _userManager.GetUserAsync(User);
            user.Email = change.Email;
            user.PhoneNumber = change.PhoneNumber;
            user.NormalizedEmail = change.Email;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.UpdateAsync(user);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await _signInManager.RefreshSignInAsync(user);
            ModelState.AddModelError(string.Empty, "Your Profile has been changed.");
            return View();
        }
        #endregion
        #region Accounts Page
        [Authorize]
        public ActionResult Rents()
        {
            return View();
        }
        [Authorize]
        public ActionResult Asset_expenses()
        {
            return View();
        }
        [Authorize]
        public ActionResult Supplies()
        {
            return View();
        }
        [Authorize]
        public ActionResult Deposits()
        {
            return View();
        }
        [Authorize]
        public ActionResult Banks()
        {
            return View();
        }
        [Authorize]
        public ActionResult Billing()
        {
            return View();
        }
        #endregion
    }
}
