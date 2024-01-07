using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;
using Property_Management_Sys.Utility;

namespace Property_Management_Sys.Controllers
{
    [Authorize]
    public class LandlordController : Controller
    {
        private readonly ILogger<LandlordController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public LandlordController(IWebHostEnvironment Environment, ILogger<LandlordController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        // GET: Landlord
        public ActionResult Index()
        {
            List<Tbl_Landlord> list = null;
            var current_user = GetCurrentUserAsync().Result;
            if (current_user.UserType == UserType.SuperAdmin)
            {
                list = _context.Tbl_Landlord.Where(x => x.IsDeleted == false && x.Status == true).OrderByDescending(x => x.Landlord_Id).AsNoTracking().ToList();
            }
            else if (current_user.UserType == UserType.AppTenant)
            {
                list = _context.Tbl_Landlord.Where(x => x.IsDeleted == false && x.Status == true && x.AppTenantId == Convert.ToInt32(current_user.AppTenantId)).OrderByDescending(x => x.Landlord_Id).AsNoTracking().ToList();
            }
            else if (current_user.UserType == UserType.User)
            {
                list = _context.Tbl_Landlord.Where(x => x.IsDeleted == false && x.Status == true && x.AddedBy == current_user.Id).OrderByDescending(x => x.Landlord_Id).AsNoTracking().ToList();
            }
            return View(list);
        }

        // GET: Landlord/Details/5
        public ActionResult Details(int? id)
        {
            var tbl_Landlord = _context.Tbl_Agreement_Form.Where(x => x.Landlord_Id == id).ToList();
            return View(tbl_Landlord);
        }

        // GET: Landlord/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult GenerateInvoice()
        {
            return View();
        }
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Landlord tbl_Landlord)
        {
            if (ModelState.IsValid)
            {
                Random generator = new Random();
                String r = generator.Next(0, 1000000).ToString("D6");
                tbl_Landlord.Landlord_Datetime = DateTime.UtcNow;
                tbl_Landlord.Landlord_Unique_No = r;
                var names = FirstCharToUpper(tbl_Landlord.Landlord_Name);
                tbl_Landlord.Landlord_Name = names;
                tbl_Landlord.Status = true;
                tbl_Landlord.IsDeleted = false;
                tbl_Landlord.AddedDate = DateTime.UtcNow;
                tbl_Landlord.AddedBy = GetCurrentUserAsync().Result.Id;
                tbl_Landlord.AppTenantId = Convert.ToInt32(GetCurrentUserAsync().Result.AppTenantId);
                _context.Tbl_Landlord.Add(tbl_Landlord);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Landlord);
        }

        // GET: Landlord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Landlord tbl_Landlord = _context.Tbl_Landlord.Find(id);
            if (tbl_Landlord == null)
            {
                return NotFound();
            }
            return View(tbl_Landlord);
        }

        // POST: Landlord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Landlord tbl_Landlord)
        {
            if (ModelState.IsValid)
            {
                var names = FirstCharToUpper(tbl_Landlord.Landlord_Name);
                tbl_Landlord.Landlord_Name = names;
                tbl_Landlord.Status = true;
                tbl_Landlord.IsDeleted = false;
                tbl_Landlord.ModifiedDate = DateTime.UtcNow;
                tbl_Landlord.ModifiedBy = GetCurrentUserAsync().Result.Id;
                tbl_Landlord.AppTenantId = Convert.ToInt32(GetCurrentUserAsync().Result.AppTenantId);
                _context.Entry(tbl_Landlord).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Landlord);
        }

        // GET: Landlord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Landlord tbl_Landlord = _context.Tbl_Landlord.Find(id);
            if (tbl_Landlord == null)
            {
                return NotFound();
            }
            return View(tbl_Landlord);
        }

        // POST: Landlord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Landlord tbl_Landlord = _context.Tbl_Landlord.Find(id);
            tbl_Landlord.IsDeleted = true;
            _context.Entry(tbl_Landlord).State = EntityState.Modified;
            _context.Tbl_Landlord.Update(tbl_Landlord);
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
