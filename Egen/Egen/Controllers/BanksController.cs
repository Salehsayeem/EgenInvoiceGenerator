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
            var banks = db.Banks.Include(b => b.Consultant);
            return View(banks.ToList());
        }

        // GET: Banks/Details/5
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
            ViewBag.ConsultantId = new SelectList(db.Consultants, "ConsultantId", "ConsultantName");
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankId,AccountName,AccountNumber,Iban,BankName,SwiftCode,RoutingType,RoutingNumber,BankCountry,BankBranch,ConsultantId")] Banks banks)
        {
            if (ModelState.IsValid)
            {
                db.Banks.Add(banks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsultantId = new SelectList(db.Consultants, "ConsultantId", "ConsultantName", banks.ConsultantId);
            return View(banks);
        }

        // GET: Banks/Edit/5
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
            ViewBag.ConsultantId = new SelectList(db.Consultants, "ConsultantId", "ConsultantName", banks.ConsultantId);
            return View(banks);
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankId,AccountName,AccountNumber,Iban,BankName,SwiftCode,RoutingType,RoutingNumber,BankCountry,BankBranch,ConsultantId")] Banks banks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsultantId = new SelectList(db.Consultants, "ConsultantId", "ConsultantName", banks.ConsultantId);
            return View(banks);
        }

        // GET: Banks/Delete/5
        public ActionResult Delete(int id)
        {
            Banks data = db.Banks.First(s => s.BankId == id);
            if (data != null)
            {
                db.Banks.Remove(data);
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
