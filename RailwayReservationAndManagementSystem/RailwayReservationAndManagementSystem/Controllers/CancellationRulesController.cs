using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RailwayReservationAndManagementSystem.Models;

namespace RailwayReservationAndManagementSystem.Controllers
{
    public class CancellationRulesController : Controller
    {
        private dbRailwayReservationAndManagementSystemEntities13 db = new dbRailwayReservationAndManagementSystemEntities13();

        // GET: CancellationRules
        public ActionResult Index()
        {
            return View(db.CancellationRules.ToList());
        }

        // GET: CancellationRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancellationRule cancellationRule = db.CancellationRules.Find(id);
            if (cancellationRule == null)
            {
                return HttpNotFound();
            }
            return View(cancellationRule);
        }

        // GET: CancellationRules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CancellationRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CancelNo,Details,CancellationFees")] CancellationRule cancellationRule)
        {
            if (ModelState.IsValid)
            {
                db.CancellationRules.Add(cancellationRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cancellationRule);
        }

        // GET: CancellationRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancellationRule cancellationRule = db.CancellationRules.Find(id);
            if (cancellationRule == null)
            {
                return HttpNotFound();
            }
            return View(cancellationRule);
        }

        // POST: CancellationRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CancelNo,Details,CancellationFees")] CancellationRule cancellationRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancellationRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cancellationRule);
        }

        // GET: CancellationRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CancellationRule cancellationRule = db.CancellationRules.Find(id);
            if (cancellationRule == null)
            {
                return HttpNotFound();
            }
            return View(cancellationRule);
        }

        // POST: CancellationRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CancellationRule cancellationRule = db.CancellationRules.Find(id);
            db.CancellationRules.Remove(cancellationRule);
            db.SaveChanges();
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
