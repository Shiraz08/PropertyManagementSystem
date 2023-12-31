﻿using Microsoft.AspNetCore.Authorization;
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
    public class Agreement_PeriodController : Controller
    {
        private readonly ILogger<Agreement_PeriodController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private TapPaymentIntegrationContext _context;
        private readonly IUserStore<ApplicationUser> _userStore; 
        private IWebHostEnvironment _environment;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        EmailSender _emailSender = new EmailSender();
        public Agreement_PeriodController(IWebHostEnvironment Environment, ILogger<Agreement_PeriodController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, TapPaymentIntegrationContext context, IUserStore<ApplicationUser> userStore)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _environment = Environment;
        }

        // GET: Agreement_Period
        public ActionResult Index()
        {
            List<Tbl_Agreement_Period> list = null;
            var current_user = GetCurrentUserAsync().Result;
            if (current_user.UserType == UserType.SuperAdmin)
            {
                list = _context.Tbl_Agreement_Period.Where(x => x.IsDeleted == false && x.Status == true).OrderByDescending(x => x.Agreement_Period_Id).AsNoTracking().ToList();
            }
            else if (current_user.UserType == UserType.AppTenant)
            {
                list = _context.Tbl_Agreement_Period.Where(x => x.IsDeleted == false && x.Status == true && x.AppTenantId == Convert.ToInt32(current_user.AppTenantId)).OrderByDescending(x => x.Agreement_Period_Id).AsNoTracking().ToList();
            }
            else if (current_user.UserType == UserType.User)
            {
                list = _context.Tbl_Agreement_Period.Where(x => x.IsDeleted == false && x.Status == true && x.AddedBy == current_user.Id).OrderByDescending(x => x.Agreement_Period_Id).AsNoTracking().ToList();
            }
            return View(list);
        }

        // GET: Agreement_Period/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Agreement_Period tbl_Agreement_Period = _context.Tbl_Agreement_Period.Find(id);
            if (tbl_Agreement_Period == null)
            {
                return NotFound();
            }
            return View(tbl_Agreement_Period);
        }

        // GET: Agreement_Period/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Agreement_Period tbl_Agreement_Period)
        {
            if (ModelState.IsValid)
            {
                tbl_Agreement_Period.Agreement_Period_DateTime = DateTime.UtcNow;
                tbl_Agreement_Period.Status = true;
                tbl_Agreement_Period.IsDeleted = false;
                tbl_Agreement_Period.ModifiedDate = DateTime.UtcNow;
                tbl_Agreement_Period.ModifiedBy = GetCurrentUserAsync().Result.Id;
                _context.Tbl_Agreement_Period.Add(tbl_Agreement_Period);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Agreement_Period);
        }

        // GET: Agreement_Period/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Agreement_Period tbl_Agreement_Period = _context.Tbl_Agreement_Period.Find(id);
            if (tbl_Agreement_Period == null)
            {
                return NotFound();
            }
            return View(tbl_Agreement_Period);
        }

        // POST: Agreement_Period/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Agreement_Period tbl_Agreement_Period)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(tbl_Agreement_Period).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Agreement_Period);
        }

        // GET: Agreement_Period/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            Tbl_Agreement_Period tbl_Agreement_Period = _context.Tbl_Agreement_Period.Find(id);
            if (tbl_Agreement_Period == null)
            {
                return NotFound();
            }
            return View(tbl_Agreement_Period);
        }

        // POST: Agreement_Period/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Agreement_Period tbl_Agreement_Period = _context.Tbl_Agreement_Period.Find(id);
            _context.Tbl_Agreement_Period.Remove(tbl_Agreement_Period);
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
