
using System.Data;
using System.Globalization;
using System.Net;
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
    public class Agreement_FormController : Controller
    {
        private readonly ILogger<Agreement_FormController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore;
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public Agreement_FormController(IWebHostEnvironment Environment, ILogger<Agreement_FormController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
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
            return View(_context.Tbl_Agreement_Form.Where(x => x.IsDeleted == false && x.Status == true).OrderByDescending(x=>x.Agreement_Form_Id).ToList());
        }
        [HttpPost]
        public JsonResult LandlordSuggestion(string Prefix)
        {

            var ObjList = _context.Tbl_Landlord.Where(x => x.IsDeleted == false && x.Status == true).ToList();
            var CityList = (from N in ObjList
                            where  N.Landlord_Name.Contains(Prefix.ToUpper())
                            select new { N.Landlord_Name, N.Landlord_Identiy_Card_No });
            return Json(CityList);
        }

        [HttpPost]
        public JsonResult TenantSuggestion(string Prefix)
        {

            var ObjList = _context.Tbl_Tenant.Where(x => x.IsDeleted == false && x.Status == true).ToList();
            var CityList = (from N in ObjList
                            where N.Tenant_Name.StartsWith(Prefix.ToUpper())
                            select new { N.Tenant_Name, N.Tenant_Identity_Card });
            return Json(CityList); 
        }
        [HttpPost]
        public JsonResult Pro_DetailSuggestion(string Prefix)
        {
            var ObjList = _context.Tbl_Property_Detail.Where(x => x.IsDeleted == false && x.Status == true).ToList();
            var CityList = (from N in ObjList
                            where N.Builiding_Name.StartsWith(Prefix)
                            select new { N.Builiding_Name });
            return Json(CityList);
        }
        
        public ActionResult allinvoicepaid(string vals)
        {
            int vfd =Convert.ToInt32( vals); 
            var getallinvoices = _context.Tbl_Invoices.Where(x => x.Agreement_Form_Id == vfd && x.Invoice_Paid == false).ToList();
            foreach(var item in getallinvoices.Select(x=>x.Invoice_Id))
            {
                Tbl_Invoices invoice = _context.Tbl_Invoices.Find(Convert.ToInt32(item));
                invoice.Invoice_Paid = true;
                _context.Entry(invoice).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return Json(true);
        }
        public ActionResult allinvoicepaidtolandlord(string vals)
        {
            int vfd = Convert.ToInt32(vals);
            var getallinvoices = _context.Tbl_Invoices.Where(x => x.Agreement_Form_Id == vfd && x.Invoice_Paid_To_Landlord == false).ToList();
            foreach (var item in getallinvoices.Select(x => x.Invoice_Id))
            {
                Tbl_Invoices invoice = _context.Tbl_Invoices.Find(Convert.ToInt32(item));
                invoice.Invoice_Paid_To_Landlord = true;
                _context.Entry(invoice).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return Json(true);
        }
        public ActionResult paidinvoice(string vals)
        {
            Tbl_Invoices invoice = _context.Tbl_Invoices.Find(Convert.ToInt32(vals));
            invoice.Invoice_Paid = true;
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
            return Json(true);
        }
        public ActionResult paidinvoiceTOlandlord(string vals)
        {
            Tbl_Invoices invoice = _context.Tbl_Invoices.Find(Convert.ToInt32(vals));
            invoice.Invoice_Paid_To_Landlord = true;
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
            return Json(true);
        }
        public ActionResult landlordgetdata(string vals)
        {
            var intval = Convert.ToInt32(vals);
            var response = _context.Tbl_Landlord.Where(x => x.Landlord_Id == intval).FirstOrDefault();
            return Json(response);
        }
        public ActionResult landlordgetdataidcard(string vals)
        {
            var response = _context.Tbl_Landlord.Where(x => x.Landlord_Identiy_Card_No == vals).FirstOrDefault();
            return Json(response);
        }
        public ActionResult fillbuildingdropdown (string vals)
        {

            var _val = Convert.ToInt32(vals);
            var response = _context.Tbl_Property_Detail.Where(x => x.LanLoadrd_Id == _val).Select(x => new SelectListItem { Text = x.Building_No.ToString(), Value = x.Builiding_Name.ToString() }).ToList();
            return Json(response);
        }
        public ActionResult Pro_Detailgetdata(string vals)
        {
            var response = _context.Tbl_Property_Detail.Where(x => x.Building_No == vals).FirstOrDefault();
            return Json(response);
        }
        public ActionResult Tenantgetdata(string vals)
        {
            var intval = Convert.ToInt32(vals);
            var response = _context.Tbl_Tenant.Where(x => x.Tenant_Id == intval).FirstOrDefault();
            return Json(response);
        }
        public ActionResult Tenantgetdataidcard(string vals)
        {
            var response = _context.Tbl_Tenant.Where(x => x.Tenant_Identity_Card == vals).FirstOrDefault();
            return Json(response);
        } 
        public ActionResult Details(int? id)
        {
            var tbl_Invoice = _context.Tbl_Invoices.Where(x => x.Agreement_Form_Id == id).ToList();
            var parts = tbl_Invoice.Where(x => x.Invoice_Paid == true).ToList();
            int sum = 0;
            foreach (var item in parts.Select(x=>x.Rent_Ammount))
            {
                sum += Convert.ToInt32(item);
            }
            ViewBag.paid = sum;
            var part2 = tbl_Invoice.Where(x => x.Invoice_Paid == false).ToList();
            int sum2 = 0;
            foreach (var item in part2.Select(x => x.Rent_Ammount))
            {
                sum2 += Convert.ToInt32(item);
            }
            ViewBag.unpaid = sum2;
            var part3 = tbl_Invoice.Where(x => x.Invoice_Paid_To_Landlord == true).ToList();
            int sum3 = 0;
            foreach (var item in part3.Select(x => x.Rent_Ammount))
            {
                sum3 += Convert.ToInt32(item);
            }
            ViewBag.paidtolandlord = sum3;
            var part4 = tbl_Invoice.Where(x => x.Invoice_Paid_To_Landlord == false).ToList();
            int sum4 = 0;
            foreach (var item in part4.Select(x => x.Rent_Ammount))
            {
                sum4 += Convert.ToInt32(item);
            }
            ViewBag.unpaidtolandlord = sum4;
            return View(tbl_Invoice);
        }
        public ActionResult DownloadInvoice(int? id)
        {
            var tbl_Invoice = _context.Tbl_Invoices.Where(x => x.Invoice_Id == id).FirstOrDefault();
            ViewBag.tbl_invoice = _context.Tbl_Invoices.Where(x => x.Invoice_Id == id).FirstOrDefault();
            var tbl_agreementform = _context.Tbl_Agreement_Form.Where(x => x.Agreement_Form_Id == tbl_Invoice.Agreement_Form_Id).FirstOrDefault();
            return View(tbl_agreementform);
        }
        public ActionResult DownloadAgreementForm(int? id)
        {
            var tbl_agreementform = _context.Tbl_Agreement_Form.Where(x => x.Agreement_Form_Id == id).FirstOrDefault();
            return View(tbl_agreementform);
        }
        public ActionResult Create()
        {

            ViewBag.lanlords = _context.Tbl_Landlord.Select(x => new SelectListItem { Text = x.Landlord_Id.ToString(), Value = x.Landlord_Name.ToString() }).Distinct().ToList();
            ViewBag.Tenants = _context.Tbl_Tenant.Select(x => new SelectListItem { Text = x.Tenant_Id.ToString(), Value = x.Tenant_Name.ToString() }).Distinct().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Agreement_Form tbl_Agreement_Form)
        {
            if (ModelState.IsValid)
            {
                //code for save form
                tbl_Agreement_Form.Agreement_Form_DateTime = DateTime.UtcNow.Date;
                var landlordname = _context.Tbl_Landlord.Where(x => x.Landlord_Id == tbl_Agreement_Form.Landlord_Id).Select(x => x.Landlord_Name).FirstOrDefault();
                var Tenantname = _context.Tbl_Tenant.Where(x => x.Tenant_Id == tbl_Agreement_Form.Tenant_Id).Select(x => x.Tenant_Name).FirstOrDefault();
                tbl_Agreement_Form.Landlord_Name = landlordname;
                tbl_Agreement_Form.Tenant_Name = Tenantname;
                var dd = _context.Tbl_Property_Detail.Where(x => x.Pro_Detail_Id == tbl_Agreement_Form.Pro_Detail_Id).Select(x => x.Builiding_Name).FirstOrDefault();
                tbl_Agreement_Form.Builiding_Name = dd;
                tbl_Agreement_Form.Status = true;
                tbl_Agreement_Form.IsDeleted = false;
                tbl_Agreement_Form.AddedDate = DateTime.UtcNow;
                tbl_Agreement_Form.AddedBy = GetCurrentUserAsync().Result.UserType;
                _context.Tbl_Agreement_Form.Add(tbl_Agreement_Form);
                _context.SaveChanges();
                //code for generate invoices
                var max_form_id = _context.Tbl_Agreement_Form.Max(x => x.Agreement_Form_Id).ToString();
                var firstdate =Convert.ToDateTime(tbl_Agreement_Form.Agreement_Period_From_DateTime).ToString("yyyy-MM");
                var enddate = Convert.ToDateTime(tbl_Agreement_Form.Agreement_Period_To_DateTime).ToString("yyyy-MM");
                string format = "yyyy-MM";
                DateTime startDT = DateTime.ParseExact(firstdate.ToString(), format, CultureInfo.InvariantCulture);
                DateTime endDT = DateTime.ParseExact(enddate.ToString(), format, CultureInfo.InvariantCulture);
                DateTime finalenddate = endDT.AddMonths(-1);
                while (startDT <= finalenddate)
                {
                    Tbl_Invoices tbl_Invoices = new Tbl_Invoices();
                    tbl_Invoices.Agreement_Form_Id =Convert.ToInt32(max_form_id);
                    tbl_Invoices.Invoice_Created_Date = DateTime.UtcNow;
                    tbl_Invoices.Invoice_Date = startDT;
                    tbl_Invoices.Invoice_Paid =false;
                    tbl_Invoices.Invoice_Paid_To_Landlord = false;
                    tbl_Invoices.Landlord_Id = tbl_Agreement_Form.Landlord_Id;
                    tbl_Invoices.Landlord_Name = tbl_Agreement_Form.Landlord_Name;
                    tbl_Invoices.Rent_Ammount = tbl_Agreement_Form.Rent_Amount;
                    tbl_Invoices.Tenant_Id = tbl_Agreement_Form.Tenant_Id;
                    tbl_Invoices.Tenant_Name = tbl_Agreement_Form.Tenant_Name;
                    tbl_Invoices.Status = true;
                    tbl_Invoices.IsDeleted = false;
                    tbl_Invoices.AddedDate = DateTime.UtcNow;
                    tbl_Invoices.AddedBy = GetCurrentUserAsync().Result.UserType;
                    _context.Tbl_Invoices.Add(tbl_Invoices);
                    _context.SaveChanges();
                    startDT = startDT.AddMonths(1);
                }
                return RedirectToAction("Index");
            }

            return View(tbl_Agreement_Form);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Agreement_Form tbl_Agreement_Form = _context.Tbl_Agreement_Form.Find(id);
            if (tbl_Agreement_Form == null)
            {
                return NotFound();
            }
            return View(tbl_Agreement_Form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Agreement_Form tbl_Agreement_Form)
        {
            if (ModelState.IsValid)
            {
                //edit data save in _context
                tbl_Agreement_Form.Agreement_Form_DateTime = DateTime.UtcNow.Date;
                var landlordname = _context.Tbl_Landlord.Where(x => x.Landlord_Id == tbl_Agreement_Form.Landlord_Id).Select(x => x.Landlord_Name).FirstOrDefault();
                var Tenantname = _context.Tbl_Tenant.Where(x => x.Tenant_Id == tbl_Agreement_Form.Tenant_Id).Select(x => x.Tenant_Name).FirstOrDefault();
                tbl_Agreement_Form.Landlord_Name = landlordname;
                tbl_Agreement_Form.Tenant_Name = Tenantname;
                var dd = _context.Tbl_Property_Detail.Where(x => x.Pro_Detail_Id == tbl_Agreement_Form.Pro_Detail_Id).Select(x => x.Builiding_Name).FirstOrDefault();
                tbl_Agreement_Form.Builiding_Name = dd;
                tbl_Agreement_Form.Status = true;
                tbl_Agreement_Form.IsDeleted = false;
                tbl_Agreement_Form.ModifiedDate = DateTime.UtcNow;
                tbl_Agreement_Form.ModifiedBy = GetCurrentUserAsync().Result.UserType;
                _context.Entry(tbl_Agreement_Form).State = EntityState.Modified;
                _context.SaveChanges();
                //delete invoice 
                int vfd = Convert.ToInt32(tbl_Agreement_Form.Agreement_Form_Id);
                var getallinvoices = _context.Tbl_Invoices.Where(x => x.Agreement_Form_Id == vfd).ToList();
                foreach (var item in getallinvoices.Select(x => x.Invoice_Id))
                {
                    Tbl_Invoices personalDetail = _context.Tbl_Invoices.Find(item);
                    _context.Tbl_Invoices.Remove(personalDetail);
                    _context.SaveChanges();
                }
                //add new invoices
                //code for generate invoices
                var max_form_id = tbl_Agreement_Form.Agreement_Form_Id;
                var firstdate = Convert.ToDateTime(tbl_Agreement_Form.Agreement_Period_From_DateTime).ToString("yyyy-MM");
                var enddate = Convert.ToDateTime(tbl_Agreement_Form.Agreement_Period_To_DateTime).ToString("yyyy-MM");
                string format = "yyyy-MM";
                DateTime startDT = DateTime.ParseExact(firstdate.ToString(), format, CultureInfo.InvariantCulture);
                DateTime endDT = DateTime.ParseExact(enddate.ToString(), format, CultureInfo.InvariantCulture);
                while (startDT <= endDT)
                {
                    Tbl_Invoices tbl_Invoices = new Tbl_Invoices();
                    tbl_Invoices.Agreement_Form_Id = Convert.ToInt32(max_form_id);
                    tbl_Invoices.Invoice_Created_Date = DateTime.UtcNow;
                    tbl_Invoices.Invoice_Date = startDT;
                    tbl_Invoices.Invoice_Paid = false;
                    tbl_Invoices.Invoice_Paid_To_Landlord = false;
                    tbl_Invoices.Landlord_Id = tbl_Agreement_Form.Landlord_Id;
                    tbl_Invoices.Landlord_Name = tbl_Agreement_Form.Landlord_Name;
                    tbl_Invoices.Rent_Ammount = tbl_Agreement_Form.Rent_Amount;
                    tbl_Invoices.Tenant_Id = tbl_Agreement_Form.Tenant_Id;
                    tbl_Invoices.Tenant_Name = tbl_Agreement_Form.Tenant_Name;
                    tbl_Invoices.Status = true;
                    tbl_Invoices.IsDeleted = false;
                    tbl_Invoices.ModifiedDate = DateTime.UtcNow;
                    tbl_Invoices.ModifiedBy = GetCurrentUserAsync().Result.UserType;
                    _context.Tbl_Invoices.Add(tbl_Invoices);
                    _context.SaveChanges();
                    startDT = startDT.AddMonths(1);
                }
                return RedirectToAction("Index");
            }
            return View(tbl_Agreement_Form);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Agreement_Form tbl_Agreement_Form = _context.Tbl_Agreement_Form.Find(id);
            if (tbl_Agreement_Form == null)
            {
                return NotFound();
            }
            return View(tbl_Agreement_Form);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Agreement_Form tbl_Agreement_Form = _context.Tbl_Agreement_Form.Find(id);
            tbl_Agreement_Form.IsDeleted = true;
            _context.Entry(tbl_Agreement_Form).State = EntityState.Modified;
            _context.Tbl_Agreement_Form.Update(tbl_Agreement_Form);
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
