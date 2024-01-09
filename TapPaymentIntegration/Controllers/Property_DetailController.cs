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
using Property_Management_Sys.Utility;

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
            List<Tbl_Property_Detail> list = null;
            var current_user = GetCurrentUserAsync().Result;
            if (current_user.UserType == UserType.SuperAdmin)
            {
                list = _context.Tbl_Property_Detail.Where(x => x.IsDeleted == false && x.Status == true).OrderByDescending(x => x.Pro_Detail_Id).AsNoTracking().ToList();
            }
            else if (current_user.UserType == UserType.AppTenant)
            {
                list = _context.Tbl_Property_Detail.Where(x => x.IsDeleted == false && x.Status == true && x.AppTenantId == Convert.ToInt32(current_user.AppTenantId)).OrderByDescending(x => x.Pro_Detail_Id).AsNoTracking().ToList();
            }
            else if (current_user.UserType == UserType.User)
            {
                list = _context.Tbl_Property_Detail.Where(x => x.IsDeleted == false && x.Status == true && x.AddedBy == current_user.Id).OrderByDescending(x => x.Pro_Detail_Id).AsNoTracking().ToList();
            }
            return View(list);
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
            if (id != null)
            {
                var val = _context.Tbl_Property_Detail.Where(x => x.Pro_Detail_Id == id).ToList();
                return View(val);
            }
            return View();
        }

        // GET: Property_Detail/Create
        public ActionResult Create()
        {
            ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
            Tbl_Property_Detail tbl_Property_Detail = new Tbl_Property_Detail();
            tbl_Property_Detail.Address_Country = "0";
            return View(tbl_Property_Detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Property_Detail tbl_Property_Detail)
        {
            if (ModelState.IsValid)
            {
                string wwwPath = _environment.WebRootPath;
                string contentPath = _environment.ContentRootPath;

                string path = Path.Combine(_environment.WebRootPath, "UploadFiles");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                IFormFile doc_File = tbl_Property_Detail.DocumentsFile;
                string fileName = Path.GetFileName(DateTime.UtcNow.Millisecond + doc_File.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    doc_File.CopyTo(stream);
                }

                IFormFile inv_File = tbl_Property_Detail.InventoryFile;
                string fileName2 = Path.GetFileName(DateTime.UtcNow.Millisecond + inv_File.FileName);
                using (FileStream stream2 = new FileStream(Path.Combine(path, fileName2), FileMode.Create))
                {
                    inv_File.CopyTo(stream2);
                }

                var getname = _context.Tbl_Landlord.Where(x => x.Landlord_Id == tbl_Property_Detail.LanLoadrd_Id).Select(x => x.Landlord_Name).FirstOrDefault();
                tbl_Property_Detail.LanLoadrd_Name = getname;
                tbl_Property_Detail.Asset_data_Typeasset = "0";
                tbl_Property_Detail.DocumentsFileName = fileName;
                tbl_Property_Detail.InventoryFileName = fileName2;
                tbl_Property_Detail.Status = true;
                tbl_Property_Detail.IsDeleted = false;
                tbl_Property_Detail.AddedDate = DateTime.UtcNow;
                tbl_Property_Detail.AddedBy = GetCurrentUserAsync().Result.Id;
                tbl_Property_Detail.AppTenantId = Convert.ToInt32(GetCurrentUserAsync().Result.AppTenantId);
                _context.Tbl_Property_Detail.Add(tbl_Property_Detail);
                _context.SaveChanges();

                ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
                tbl_Property_Detail = null;
                ViewBag.Status = true;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
                ViewBag.Status = false;
                return View(tbl_Property_Detail);
            }
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
            ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
            return View(tbl_Property_Detail);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Property_Detail tbl_Property_Detail)
        {
            if (ModelState.IsValid)
            {
                string wwwPath = _environment.WebRootPath;
                string contentPath = _environment.ContentRootPath;

                string path = Path.Combine(_environment.WebRootPath, "UploadFiles");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = "";
                 if (tbl_Property_Detail.DocumentsFile != null)
                {
                    IFormFile doc_File = tbl_Property_Detail.DocumentsFile;
                    fileName = Path.GetFileName(DateTime.UtcNow.Millisecond + doc_File.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        doc_File.CopyTo(stream);
                    }
                }
                 else
                {
                    fileName = tbl_Property_Detail.DocumentsFileName;
                }

                string fileName2 = "";
                if (tbl_Property_Detail.InventoryFile != null)
                {
                    IFormFile inv_File = tbl_Property_Detail.InventoryFile;
                    fileName2 = Path.GetFileName(DateTime.UtcNow.Millisecond + inv_File.FileName);
                    using (FileStream stream2 = new FileStream(Path.Combine(path, fileName2), FileMode.Create))
                    {
                        inv_File.CopyTo(stream2);
                    }
                }
                else
                {
                    fileName2 = tbl_Property_Detail.InventoryFileName;
                }


                var getname = _context.Tbl_Landlord.Where(x => x.Landlord_Id == tbl_Property_Detail.LanLoadrd_Id).Select(x => x.Landlord_Name).FirstOrDefault();
                tbl_Property_Detail.LanLoadrd_Name = getname;
                tbl_Property_Detail.Asset_data_Typeasset = "0";
                tbl_Property_Detail.DocumentsFileName = fileName;
                tbl_Property_Detail.InventoryFileName = fileName2;
                var names = FirstCharToUpper(tbl_Property_Detail.Basic_Builiding_Name);
                tbl_Property_Detail.Basic_Builiding_Name = names;
                tbl_Property_Detail.Status = true;
                tbl_Property_Detail.IsDeleted = false;
                tbl_Property_Detail.ModifiedDate = DateTime.UtcNow;
                tbl_Property_Detail.ModifiedBy = GetCurrentUserAsync().Result.Id;
                tbl_Property_Detail.AppTenantId = Convert.ToInt32(GetCurrentUserAsync().Result.AppTenantId);
                _context.Entry(tbl_Property_Detail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LanLoadrd_Id = new SelectList(_context.Tbl_Landlord, "Landlord_Id", "Landlord_Name");
                ViewBag.Status = false;
                return View(tbl_Property_Detail);
            }
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
