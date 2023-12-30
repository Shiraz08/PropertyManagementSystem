using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Property_Management_Sys.Areas.Identity.Data;
using Property_Management_Sys.Data;
using Property_Management_Sys.Models;
using Property_Management_Sys.Models.Email;

namespace Property_Management_Sys.Controllers
{
    [Authorize]
    public class Property_DetailController : Controller
    {
        private readonly ILogger<Property_DetailController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public Property_DetailController(IWebHostEnvironment Environment, ILogger<Property_DetailController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        // GET: Property_Detail
        public ActionResult Index()
        {
            var val = _context.Tbl_Property_Detail.OrderByDescending(x=>x.LanLoadrd_Id).ToList();
            return View(val);
        }
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        // GET: Property_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                var val = _context.Tbl_Property_Detail.Where(x => x.LanLoadrd_Id == id).ToList();
                return View(val);
            }
            return View();
        }

        // GET: Property_Detail/Create
        public ActionResult Create()
        {
            ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
            return View();
        }

        // POST: Property_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Property_Detail tbl_Property_Detail)
        {
            if (ModelState.IsValid)
            {
                tbl_Property_Detail.Pro_Detail_Datetime = DateTime.Now;
                var getname = _context.Tbl_Landlord.Where(x => x.Landlord_Id == tbl_Property_Detail.LanLoadrd_Id).Select(x => x.Landlord_Name).FirstOrDefault();
                tbl_Property_Detail.LanLoadrd_Name = getname;
                var names = FirstCharToUpper(tbl_Property_Detail.Builiding_Name);
                tbl_Property_Detail.Builiding_Name = names;
                _context.Tbl_Property_Detail.Add(tbl_Property_Detail);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "UserType_Id", "UserType_Name", tbl_Property_Detail.LanLoadrd_Id);
            return View(tbl_Property_Detail);
        }

        // GET: Property_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Property_Detail tbl_Property_Detail = _context.Tbl_Property_Detail.Find(id);
            if (tbl_Property_Detail == null)
            {
                return NotFound();
            }
            ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "UserType_Id", "UserType_Name", tbl_Property_Detail.LanLoadrd_Id);
            return View(tbl_Property_Detail);
        }

        // POST: Property_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Property_Detail tbl_Property_Detail)
        {
            if (ModelState.IsValid)
            {
                tbl_Property_Detail.Pro_Detail_Datetime = DateTime.Now;
                var getname = _context.Tbl_Landlord.Where(x => x.Landlord_Id == tbl_Property_Detail.LanLoadrd_Id).Select(x => x.Landlord_Name).FirstOrDefault();
                tbl_Property_Detail.LanLoadrd_Name = getname;
                var names = FirstCharToUpper(tbl_Property_Detail.Builiding_Name);
                tbl_Property_Detail.Builiding_Name = names;
                _context.Entry(tbl_Property_Detail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "UserType_Id", "UserType_Name", tbl_Property_Detail.LanLoadrd_Id);
            return View(tbl_Property_Detail);
        }

        // GET: Property_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Property_Detail tbl_Property_Detail = _context.Tbl_Property_Detail.Find(id);
            if (tbl_Property_Detail == null)
            {
                return NotFound();
            }
            return View(tbl_Property_Detail);
        }

        // POST: Property_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Property_Detail tbl_Property_Detail = _context.Tbl_Property_Detail.Find(id);
            _context.Tbl_Property_Detail.Remove(tbl_Property_Detail);
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
