using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;
using Property_Management_Sys.Utility;
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

    }
}