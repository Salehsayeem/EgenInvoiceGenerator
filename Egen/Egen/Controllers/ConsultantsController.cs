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
    public class ConsultantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultants
        public ActionResult Index()
        {
            var consultants = db.Consultants.Include(c => c.Project);
            return View(consultants.ToList());
        }

        // GET: Consultants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultants consultants = db.Consultants.Find(id);
            if (consultants == null)
            {
                return HttpNotFound();
            }
            return View(consultants);
        }

        // GET: Consultants/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultantId,ConsultantName,ConsultantDesignation,ProjectId")] Consultants consultants)
        {
            if (ModelState.IsValid)
            {
                db.Consultants.Add(consultants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", consultants.ProjectId);
            return View(consultants);
        }

        // GET: Consultants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultants consultants = db.Consultants.Find(id);
            if (consultants == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", consultants.ProjectId);
            return View(consultants);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultantId,ConsultantName,ConsultantDesignation,ProjectId")] Consultants consultants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", consultants.ProjectId);
            return View(consultants);
        }

        public ActionResult Delete(int id)
        {
            Consultants data = db.Consultants.First(s => s.ConsultantId == id);
            if (data != null)
            {
                db.Consultants.Remove(data);
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
