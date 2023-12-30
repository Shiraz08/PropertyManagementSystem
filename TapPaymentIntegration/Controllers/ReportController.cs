using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models.Email;
namespace Property_Management_Sys.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public ReportController(IWebHostEnvironment Environment, ILogger<ReportController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        public ActionResult ExpiringContracts(DateTime? StartDate, DateTime? EndDate)
        {
            if(StartDate != null)
            {
                var list = _context.Tbl_Agreement_Form.ToList();
                var query = from l in list
                            where l.Agreement_Period_To_DateTime >= StartDate
                               && l.Agreement_Period_To_DateTime <= EndDate
                            select l;



                var get = _context.Tbl_Agreement_Form.Where(i => i.Agreement_Period_To_DateTime <= StartDate && i.Agreement_Period_To_DateTime >= EndDate).ToList();
                return View(query);
            }
            return View();
        }

        public ActionResult ViewRentDetails(string BuildingNo, string appno , DateTime? StartDate, DateTime? EndDate)
        {
            ViewBag.BuildingNo = new SelectList(_context.Tbl_Property_Detail, "Building_No", "Building_No");
            ViewBag.appno = new SelectList(_context.Tbl_Property_Detail, "Apt_Villa_No", "Apt_Villa_No");
            if (appno != null)
            {
                var formid = _context.Tbl_Agreement_Form.Where(x => x.Building_No == BuildingNo && x.Apt_Villa_No == appno).Select(x => x.Agreement_Form_Id).FirstOrDefault();
                ViewBag.Invoiceslist = _context.Tbl_Invoices.Where(x => x.Agreement_Form_Id == formid).ToList();
                var getlist = _context.Tbl_Agreement_Form.Where(x => x.Building_No == BuildingNo && x.Apt_Villa_No == appno ).ToList();
                var finallist = getlist.Where(x => x.Agreement_Form_DateTime >= StartDate && x.Agreement_Form_DateTime <= EndDate).ToList();
                return View(finallist);
            }
            return View();
        }
    }
}