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
    public class TrainSchedulesController : Controller
    {
        private dbRailwayReservationAndManagementSystemEntities13 db = new dbRailwayReservationAndManagementSystemEntities13();

        // GET: TrainSchedules
        public ActionResult Index()
        {
           
            var trainSchedules = db.TrainSchedules.Include(t => t.Station).Include(t => t.Train);
            
            return View(trainSchedules.ToList());
        }

        // GET: TrainSchedules/Details/5
        public ActionResult Details(int? id)
        {
            TrainSchedule tc = new TrainSchedule();
            if (tc.Status == 0)
                {
                    ViewBag.Status = "Enable";
                }
                else
                {
                    ViewBag.Status = "Unable";
                }
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }
  

        // GET: TrainSchedules/Create
        public ActionResult Create()
        {
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Code");

            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainNo");
            return View();
        }
      
        // POST: TrainSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainSchedule trainSchedule)
        {
            TrainSchedule tsc = new TrainSchedule();
            TrainSchedule tc = db.TrainSchedules.FirstOrDefault(x => x.TrainID == trainSchedule.TrainID);
            if (tc == null)
            {
                if (ModelState.IsValid)
                {
                    tsc.TrainID = trainSchedule.TrainID;
                    tsc.StationID = trainSchedule.StationID;
                    tsc.StartStationID = trainSchedule.StartStationID;
                    tsc.EndStationID = trainSchedule.EndStationID;
                    tsc.Distances = trainSchedule.Distances;
                    tsc.DepartureTime = trainSchedule.DepartureTime;
                    tsc.ArrivalTime = trainSchedule.ArrivalTime;
                    tsc.Status = 0;
                    db.TrainSchedules.Add(tsc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "The Train ID aldready!";
            }

            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Code", trainSchedule.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", trainSchedule.TrainID);
            return View(trainSchedule);
        }
       
      
        // GET: TrainSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Code", trainSchedule.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", trainSchedule.TrainID);
            return View(trainSchedule);
        }

        // POST: TrainSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainID,StationID,StartStationID,EndStationID,Distances,ArrivalTime,DepartureTime,Status")] TrainSchedule trainSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "Code", trainSchedule.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", trainSchedule.TrainID);
            return View(trainSchedule);
        }

        // GET: TrainSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // POST: TrainSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            db.TrainSchedules.Remove(trainSchedule);
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
