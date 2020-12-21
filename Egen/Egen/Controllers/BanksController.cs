using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Egen.Models;

namespace Egen.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BanksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Banks
        public ActionResult Index()
        {
            var list = db.Banks.Include(c => c.Consultant).Where(a => a.IsActive == true).ToList();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banks banks = db.Banks.Find(id);
            if (banks == null)
            {
                return HttpNotFound();
            }
            return View(banks);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Banks banks)
        {
            if (ModelState.IsValid)
            {
                banks.IsActive = true;
                db.Banks.Add(banks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName", banks.ConsultantId);
            return View(banks);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banks banks = db.Banks.Find(id);
            if (banks == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName", banks.ConsultantId);
            return View(banks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Banks banks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName", banks.ConsultantId);
            return View(banks);
        }
        public ActionResult Delete(int id)
        {
            Banks data = db.Banks.First(s => s.BankId == id);
            if (data != null)
            {
                data.IsActive = false;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
