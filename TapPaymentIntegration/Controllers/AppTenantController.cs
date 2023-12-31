using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;
using PropertyManagementSystem.Models.TableEntities;

namespace Property_Management_Sys.Controllers
{
    [Authorize]
    public class AppTenantController : Controller
    {
        private readonly ILogger<AppTenantController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public AppTenantController(IWebHostEnvironment Environment, ILogger<AppTenantController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        // GET: Tenant
        public ActionResult Index()
        {
            return View(_context.AppTenant.ToList());
        }
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        // GET: Tenant/Details/5
        public ActionResult Details(int? id)
        {

            var tbl_Tenant = _context.AppTenant.Where(x => x.TenantId == id).ToList();
            return View(tbl_Tenant);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppTenant tbl_Tenant)
        {
            if (ModelState.IsValid)
            {
                tbl_Tenant.AddedDate = DateTime.Now;
                var names = FirstCharToUpper(tbl_Tenant.AppTenantName);
                tbl_Tenant.AppTenantName = names;
                tbl_Tenant.TenantName = names;
                tbl_Tenant.TenantPropertyName = tbl_Tenant.AppTenantPropertyName;
                _context.AppTenant.Add(tbl_Tenant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Tenant);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            AppTenant tbl_Tenant = _context.AppTenant.Find(id);
            if (tbl_Tenant == null)
            {
                return NotFound();
            }
            return View(tbl_Tenant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppTenant tbl_Tenant)
        {
            if (ModelState.IsValid)
            {
                var names = FirstCharToUpper(tbl_Tenant.AppTenantName);
                tbl_Tenant.AppTenantName = names;
                _context.Entry(tbl_Tenant).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Tenant);
        }

        // GET: Tenant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            AppTenant tbl_Tenant = _context.AppTenant.Find(id);
            if (tbl_Tenant == null)
            {
                return NotFound();
            }
            return View(tbl_Tenant);
        }

        // POST: Tenant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppTenant tbl_Tenant = _context.AppTenant.Find(id);
            _context.AppTenant.Remove(tbl_Tenant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
