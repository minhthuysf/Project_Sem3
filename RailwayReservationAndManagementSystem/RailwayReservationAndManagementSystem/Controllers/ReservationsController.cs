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
    public class ReservationsController : Controller
    {
        private dbRailwayReservationAndManagementSystemEntities13 db = new dbRailwayReservationAndManagementSystemEntities13();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Cancellation).Include(r => r.Class).Include(r => r.Passenger).Include(r => r.Train);
            return View(reservations.ToList());


        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.ReservationID = new SelectList(db.Cancellations, "CancelID", "CancelID");
            ViewBag.PNRID = new SelectList(db.Classes, "ClassID", "ClassID");
            ViewBag.TrainID = new SelectList(db.Passengers, "PNRID", "Name");
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationID,PNRID,TrainID,DateOfTravel,Name,StartStationCode,EndStationCode,CoachNo,ClassID,TotalPassenger,SeatNo,TotalFee,ReservateDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReservationID = new SelectList(db.Cancellations, "CancelID", "CancelID", reservation.ReservationID);
            ViewBag.PNRID = new SelectList(db.Classes, "ClassID", "ClassID", reservation.PNRID);
            ViewBag.TrainID = new SelectList(db.Passengers, "PNRID", "Name", reservation.TrainID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", reservation.TrainID);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReservationID = new SelectList(db.Cancellations, "CancelID", "CancelID", reservation.ReservationID);
            ViewBag.PNRID = new SelectList(db.Classes, "ClassID", "ClassID", reservation.PNRID);
            ViewBag.TrainID = new SelectList(db.Passengers, "PNRID", "Name", reservation.TrainID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", reservation.TrainID);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationID,PNRID,TrainID,DateOfTravel,Name,StartStationCode,EndStationCode,CoachNo,ClassID,TotalPassenger,SeatNo,TotalFee,ReservateDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReservationID = new SelectList(db.Cancellations, "CancelID", "CancelID", reservation.ReservationID);
            ViewBag.PNRID = new SelectList(db.Classes, "ClassID", "ClassID", reservation.PNRID);
            ViewBag.TrainID = new SelectList(db.Passengers, "PNRID", "Name", reservation.TrainID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", reservation.TrainID);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
