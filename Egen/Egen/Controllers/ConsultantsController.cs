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
            var list = db.Consultants.Include(c => c.Project).Where(a => a.IsActive == true).ToList();
            return View(list);

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
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consultants consultants)
        {
            if (ModelState.IsValid)
            {
                consultants.IsActive = true;
                db.Consultants.Add(consultants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName", consultants.ProjectId);
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
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName", consultants.ProjectId);
            return View(consultants);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Consultants consultants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName", consultants.ProjectId);
            return View(consultants);
        }

        public ActionResult Delete(int id)
        {
            Consultants data = db.Consultants.First(s => s.ConsultantId == id);
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
