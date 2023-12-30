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
    public class Tbl_InvoicesController : Controller
    {
        private readonly ILogger<Tbl_InvoicesController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public Tbl_InvoicesController(IWebHostEnvironment Environment, ILogger<Tbl_InvoicesController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        // GET: Tbl_Invoices
        public ActionResult Index()
        {
            return View(_context.Tbl_Invoices.OrderByDescending(x=>x.Invoice_Id).ToList());
        }

        // GET: Tbl_Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Invoices tbl_Invoices = _context.Tbl_Invoices.Find(id);
            if (tbl_Invoices == null)
            {
                return NotFound();
            }
            return View(tbl_Invoices);
        }

        // GET: Tbl_Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Invoices tbl_Invoices)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_Invoices.Add(tbl_Invoices);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Invoices);
        }

        // GET: Tbl_Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Invoices tbl_Invoices = _context.Tbl_Invoices.Find(id);
            if (tbl_Invoices == null)
            {
                return NotFound();
            }
            return View(tbl_Invoices);
        }

        // POST: Tbl_Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Invoices tbl_Invoices)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(tbl_Invoices).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Invoices);
        }

        // GET: Tbl_Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Invoices tbl_Invoices = _context.Tbl_Invoices.Find(id);
            if (tbl_Invoices == null)
            {
                return NotFound();
            }
            return View(tbl_Invoices);
        }

        // POST: Tbl_Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Invoices tbl_Invoices = _context.Tbl_Invoices.Find(id);
            _context.Tbl_Invoices.Remove(tbl_Invoices);
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
