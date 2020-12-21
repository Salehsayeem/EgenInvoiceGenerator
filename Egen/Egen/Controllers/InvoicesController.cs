using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Egen.Models;
using Rotativa;

namespace Egen.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            var list = db.Invoices.Include(i => i.Bank).Include(i => i.Company).Include(i => i.Consultant).Include(i => i.Project).OrderByDescending(a=>a.CreatedDate).Where(a => a.IsActive == true).ToList();
            return View(list);
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return HttpNotFound();
            }
            return View(invoices);
        }
        public ActionResult GenerateInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return HttpNotFound();
            }
            return new ViewAsPdf(invoices);
        }
        //Dropdown
        public List<Projects> GetProjects()
        {
            List<Projects> projects = db.Projects.ToList();
            return projects;
        }

        public ActionResult GetConsultantList(int? ProjectId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Consultants> consultants = db.Consultants.Where(c => c.ProjectId == ProjectId).ToList();
            return Json(consultants, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBankList(int? ConsultantId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Banks> bank = db.Banks.Where(c => c.ConsultantId == ConsultantId).ToList();
            return Json(bank,JsonRequestBehavior.AllowGet);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Banks.Where(a => a.IsActive == true), "BankId", "AccountName");
            ViewBag.CompanyId = new SelectList(db.Companies.Where(a => a.IsActive == true), "CompanyId", "CompanyName");
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName");
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                invoices.CreatedDate = DateTime.Now;
                invoices.IsActive = true;
                db.Invoices.Add(invoices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Banks.Where(a => a.IsActive == true), "BankId", "AccountName", invoices.BankId);
            ViewBag.CompanyId = new SelectList(db.Companies.Where(a => a.IsActive == true), "CompanyId", "CompanyName", invoices.CompanyId);
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName", invoices.ConsultantId);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName", invoices.ProjectId);
            return View(invoices);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks.Where(a => a.IsActive == true), "BankId", "AccountName", invoices.BankId);
            ViewBag.CompanyId = new SelectList(db.Companies.Where(a => a.IsActive == true), "CompanyId", "CompanyName", invoices.CompanyId);
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName", invoices.ConsultantId);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName", invoices.ProjectId);
            return View(invoices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                invoices.ModifiedDate = DateTime.Now;
                try
                {
                    db.Entry(invoices).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
                
            }

            ViewBag.BankId = new SelectList(db.Banks.Where(a=>a.IsActive == true), "BankId", "AccountName", invoices.BankId);
            ViewBag.CompanyId = new SelectList(db.Companies.Where(a => a.IsActive == true), "CompanyId", "CompanyName", invoices.CompanyId);
            ViewBag.ConsultantId = new SelectList(db.Consultants.Where(a => a.IsActive == true), "ConsultantId", "ConsultantName", invoices.ConsultantId);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(a => a.IsActive == true), "ProjectId", "ProjectName", invoices.ProjectId);
            return View(invoices);
        }

        public ActionResult Delete(int id)
        {
            Invoices data = db.Invoices.First(s => s.InvoiceId == id);
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
