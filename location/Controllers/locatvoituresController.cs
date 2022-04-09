using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using location.Models;

namespace location.Controllers
{
    public class locatvoituresController : Controller
    {
        private GCDB db = new GCDB();

        // GET: locatvoitures
        public ActionResult Index()
        {
            var locatvoitures = db.locatvoitures.Include(l => l.clt).Include(l => l.voiture);
            return View(locatvoitures.ToList());
        }

        // GET: locatvoitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            locatvoiture locatvoiture = db.locatvoitures.Find(id);
            if (locatvoiture == null)
            {
                return HttpNotFound();
            }
            return View(locatvoiture);
        }

        // GET: locatvoitures/Create
        public ActionResult Create()
        {
            ViewBag.voitureID = new SelectList(db.voitures, "voitureID", "numero_matriculation");
            return View();
        }

        // POST: locatvoitures/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationID,StartDate,EndDate,voitureID,cltID")] locatvoiture locatvoiture)
        {
            if (ModelState.IsValid)
            {
                db.locatvoitures.Add(locatvoiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.clts, "CID", "Nom", locatvoiture.cltID);
            ViewBag.voitureID = new SelectList(db.voitures, "voitureID", "numero_matriculation", locatvoiture.voitureID);
            return View(locatvoiture);
        }

        // GET: locatvoitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            locatvoiture locatvoiture = db.locatvoitures.Find(id);
            if (locatvoiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.voitureID = new SelectList(db.voitures, "voitureID", "numero_matriculation", locatvoiture.voitureID);
            return View(locatvoiture);
        }

        // POST: locatvoitures/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationID,StartDate,EndDate,voitureID,cltID")] locatvoiture locatvoiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locatvoiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.voitureID = new SelectList(db.voitures, "voitureID", "numero_matriculation", locatvoiture.voitureID);
            return View(locatvoiture);
        }

        // GET: locatvoitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            locatvoiture locatvoiture = db.locatvoitures.Find(id);
            if (locatvoiture == null)
            {
                return HttpNotFound();
            }
            return View(locatvoiture);
        }

        // POST: locatvoitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            locatvoiture locatvoiture = db.locatvoitures.Find(id);
            db.locatvoitures.Remove(locatvoiture);
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
