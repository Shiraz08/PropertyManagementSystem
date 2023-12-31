using CRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;
using Property_Management_Sys.Utility;
using PropertyManagementSystem.Models;
using System.Security.Claims;
using static Property_Management_Sys.Models.StaticRoles;
using ApplicationUser = Property_Management_Sys.Areas.Identity.Data.ApplicationUser;

namespace Property_Management_Sys.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private readonly RoleManager<IdentityRole> roleManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public HomeController(IWebHostEnvironment Environment, ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }
        public ActionResult Index()
        {
            Layout model = new Layout();
            model.SuperAdmin = (from t in _context.Users select t).Where(x => x.UserType == UserType.SuperAdmin);
            model.AppTenant = (from t in _context.Users select t).Where(x => x.UserType == UserType.AppTenant);
            model.Users = (from t in _context.Users select t).Where(x => x.UserType == UserType.User);
            model.Tbl_Agreement_Forms = (from t in _context.Tbl_Agreement_Form select t).ToList();
            model.Tbl_Agreement_Period = (from t in _context.Tbl_Agreement_Period select t).ToList();
            model.Tbl_Landlords = (from t in _context.Tbl_Landlord select t).ToList();
            model.Tbl_Property_Details = (from t in _context.Tbl_Property_Detail select t).ToList();
            model.Tbl_Tenants = (from t in _context.Tbl_Tenant select t).ToList();
            model.Total_Invoices = (from t in _context.Tbl_Invoices select t).ToList();
            model.Total_Invoices_Paid = (from t in _context.Tbl_Invoices select t).Where(x => x.Invoice_Paid == true).ToList();
            model.Total_Invoices_Paid_to_Landlord = (from t in _context.Tbl_Invoices select t).Where(x => x.Invoice_Paid_To_Landlord == true).ToList();
            model.Total_Invoices_Unpaid = (from t in _context.Tbl_Invoices select t).Where(x => x.Invoice_Paid == false).ToList();
            model.Total_Invoices_Unpaid_to_Landlord = (from t in _context.Tbl_Invoices select t).Where(x => x.Invoice_Paid_To_Landlord == false).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Home", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login", "Account", new { Areas = "Identity" });
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            if (signInResult.IsLockedOut)
            {
                return RedirectToAction("Login", "Account", new { Areas = "Identity" });
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["Provider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginModel { Email = email });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return View();
            var user = await _userManager.FindByEmailAsync(model.Email);
            IdentityResult result;
            if (user != null)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }
            else
            {
                ClaimsViewModel claimsViewModel = new ClaimsViewModel();
                model.Principal = info.Principal;
                var defaultUser = new ApplicationUser
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    FullName = model.Email.Split('@')[0],
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserType = UserType.User,
                    Status = true,
                    Password = "Pass@123",
                    IsDeleted = false,
                    AddedBy = "ByDefault",
                    AddedDate = DateTime.UtcNow
                };
                user = defaultUser;

                await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                var id = roleManager.Roles.Where(x => x.Name == Roles.User.ToString()).Select(x => x.Id).FirstOrDefault();
                ClaimsListViewModel cla = new ClaimsListViewModel();

                List<ClaimsListViewModel> inputData = new List<ClaimsListViewModel>();

                // going through collection from which I want to copy
                foreach (var parameter in AllClaims)
                {
                    inputData.Add(new ClaimsListViewModel() { IsSelected = true, ClaimsType = parameter.Value });
                }
                claimsViewModel.RoleId = id;
                claimsViewModel.ClaimsList = inputData;

                var Role = await roleManager.FindByIdAsync(claimsViewModel.RoleId);
                if (Role.Id != "" && Role.Id != null)
                {
                    IList<Claim> cl = await roleManager.GetClaimsAsync(Role);
                    for (var i = 0; i < cl.Count; i++)
                    {
                        var results = await roleManager.RemoveClaimAsync(Role, cl[i]);
                    }

                    foreach (var item in claimsViewModel.ClaimsList.Where(c => c.IsSelected == true))
                    {
                        Claim c = new Claim(item.ClaimsType, item.ClaimsType);
                        var r = await roleManager.AddClaimAsync(Role, c);
                    }
                }

                result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index","Home");
                    }
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return View(nameof(ExternalLogin), model);
        }
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("canadduser","canadduser"),
            new Claim("canupdateuser","canupdateuser"),
            new Claim("canviewuser","canviewuser"),
            new Claim("superadminpermission","superadminpermission")
        };
    }
}