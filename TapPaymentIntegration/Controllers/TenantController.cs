using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;

namespace Property_Management_Sys.Controllers
{
    [Authorize]
    public class TenantController : Controller
    {
        private readonly ILogger<TenantController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public TenantController(IWebHostEnvironment Environment, ILogger<TenantController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
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
            return View(_context.Tbl_Tenant.Where(x => x.IsDeleted == false && x.Status == true).ToList());
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

            var tbl_Tenant = _context.Tbl_Agreement_Form.Where(x => x.Tenant_Id == id).ToList();
            return View(tbl_Tenant);
        }

        // GET: Tenant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tenant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Tenant tbl_Tenant)
        {
            if (ModelState.IsValid)
            {
                var names = FirstCharToUpper(tbl_Tenant.Tenant_Name);
                tbl_Tenant.Tenant_Name = names;
                tbl_Tenant.Status = true;
                tbl_Tenant.IsDeleted = false;
                tbl_Tenant.AddedDate = DateTime.UtcNow;
                tbl_Tenant.AddedBy = GetCurrentUserAsync().Result.UserName;
                _context.Tbl_Tenant.Add(tbl_Tenant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Tenant);
        }

        // GET: Tenant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Tenant tbl_Tenant = _context.Tbl_Tenant.Find(id);
            if (tbl_Tenant == null)
            {
                return NotFound();
            }
            return View(tbl_Tenant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Tenant tbl_Tenant)
        {
            if (ModelState.IsValid)
            {
                var names = FirstCharToUpper(tbl_Tenant.Tenant_Name);
                tbl_Tenant.Tenant_Name = names;
                tbl_Tenant.Status = true;
                tbl_Tenant.IsDeleted = false;
                tbl_Tenant.ModifiedDate = DateTime.UtcNow;
                tbl_Tenant.ModifiedBy = GetCurrentUserAsync().Result.UserName;
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
            Tbl_Tenant tbl_Tenant = _context.Tbl_Tenant.Find(id);
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
            Tbl_Tenant tbl_Tenant = _context.Tbl_Tenant.Find(id);
            tbl_Tenant.IsDeleted = true;
            _context.Entry(tbl_Tenant).State = EntityState.Modified;
            _context.Tbl_Tenant.Update(tbl_Tenant);
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
