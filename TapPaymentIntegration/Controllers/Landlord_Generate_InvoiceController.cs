
using System.Data;
using System.Net;
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
    public class Landlord_Generate_InvoiceController : Controller
    {
        private readonly ILogger<Landlord_Generate_InvoiceController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public Landlord_Generate_InvoiceController(IWebHostEnvironment Environment, ILogger<Landlord_Generate_InvoiceController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        // GET: Landlord_Generate_Invoice
        public ActionResult Index(string Landlord_Generate_Invoice_Extra)
        {
            var id = Convert.ToInt32(Landlord_Generate_Invoice_Extra);
            ViewBag.Landlord_Generate_Invoice_Extra = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
            ViewBag.Landlordinfo = _context.Tbl_Landlord.ToList();

            if(Landlord_Generate_Invoice_Extra != "")
            {
                var ss = _context.Tbl_Landlord_Generate_Invoice.Where(x => x.Landlord_Generate_Invoice_Extra == Landlord_Generate_Invoice_Extra).OrderByDescending(x => x.Landlord_Generate_Invoice_Id).ToList();
                return View(ss);

            }
            return View();
        }

        // GET: Landlord_Generate_Invoice/Details/5
        public ActionResult Details(int? id)
        {
            var tbl_Landlord_Generate_Invoice = _context.Tbl_Landlord_Generate_Invoice.Where(x => x.Landlord_Generate_Invoice_Extra == id.ToString()).ToList();
            if (tbl_Landlord_Generate_Invoice == null)
            {
                return NotFound();
            }
            ViewBag.landlord = _context.Tbl_Landlord.Where(x => x.Landlord_Id == id).Select(x => x.Landlord_Name).FirstOrDefault();
            int sum = 0;
            foreach (var item in tbl_Landlord_Generate_Invoice.Select(x => x.Landlord_Generate_Invoice_Total))
            {
                sum += Convert.ToInt32(item);
            }
            ViewBag.paid = sum;
            ViewBag.Landlordinfo = _context.Tbl_Landlord.ToList();
            return View(tbl_Landlord_Generate_Invoice);
        }

        // GET: Landlord_Generate_Invoice/Create
        public ActionResult Create()
        {
            ViewBag.Landlord_Generate_Invoice_Extra = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
            return View();
        }
        public JsonResult PostQuestionAndOptions(List<Tbl_Landlord_Generate_Invoice> customers)
        {
            int sum = 0;
            foreach (var item in customers.Select(x=>x.Landlord_Generate_Invoice_Amount))
            {
                sum += Convert.ToInt32(item);
            }
            Tbl_Landlord_Generate_Invoice tbl_Landlord_Generate_Invoice = new Tbl_Landlord_Generate_Invoice();
            foreach(var item in customers)
            {
                if (item.Landlord_Generate_Invoice_Extra != null)
                {
                    HttpContext.Session.SetString("products", item.Landlord_Generate_Invoice_Extra);
                }
                    tbl_Landlord_Generate_Invoice.Landlord_Generate_Invoice_Datetime = DateTime.Now;
                    tbl_Landlord_Generate_Invoice.Landlord_Generate_Invoice_Extra = HttpContext.Session.GetString("products");
                    tbl_Landlord_Generate_Invoice.Landlord_Generate_Invoice_Amount = item.Landlord_Generate_Invoice_Amount;
                    tbl_Landlord_Generate_Invoice.Landlord_Generate_Invoice_Description = item.Landlord_Generate_Invoice_Description;
                    tbl_Landlord_Generate_Invoice.Landlord_Generate_Invoice_Total = sum.ToString();
                    _context.Tbl_Landlord_Generate_Invoice.Add(tbl_Landlord_Generate_Invoice);
                    _context.SaveChanges();
                
            }
            HttpContext.Session.SetString("products", null);
            return Json(true);
        }
        [HttpPost]
        public ActionResult Create(string[] sales)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Landlord_Generate_Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            Tbl_Landlord_Generate_Invoice tbl_Landlord_Generate_Invoice = _context.Tbl_Landlord_Generate_Invoice.Find(id);
            if (tbl_Landlord_Generate_Invoice == null)
            {
                return NotFound();
            }
            return View(tbl_Landlord_Generate_Invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Landlord_Generate_Invoice tbl_Landlord_Generate_Invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(tbl_Landlord_Generate_Invoice).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Landlord_Generate_Invoice);
        }

        public ActionResult Delete(int? id)
        {
            Tbl_Landlord_Generate_Invoice tbl_Landlord_Generate_Invoice = _context.Tbl_Landlord_Generate_Invoice.Find(id);
            if (tbl_Landlord_Generate_Invoice == null)
            {
                return NotFound();
            }
            return View(tbl_Landlord_Generate_Invoice);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Landlord_Generate_Invoice tbl_Landlord_Generate_Invoice = _context.Tbl_Landlord_Generate_Invoice.Find(id);
            _context.Tbl_Landlord_Generate_Invoice.Remove(tbl_Landlord_Generate_Invoice);
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
