using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using location.Models;

namespace location.Controllers
{
    public class voituresController : Controller
    {
        private GCDB db = new GCDB();

        // GET: voitures
        public ActionResult Index()
        {
            var voitures = db.voitures.Include(v => v.Categorie).Include(v => v.Modele);
            return View(voitures.ToList());
        }

        // GET: voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: voitures/Create
        public ActionResult Create()
        {
            ViewBag.categorieID = new SelectList(db.categories, "CategorieID", "CategorieID");
            ViewBag.modelID = new SelectList(db.Modeles, "modelID", "nom");
            return View();
        }

        // POST: voitures/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(voiture voiture)
        {
            string filename = Path.GetFileNameWithoutExtension(voiture.Imagevoiture.FileName);
            string extention = Path.GetExtension(voiture.Imagevoiture.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
            voiture.image = "../Image/" + filename;
            filename = Path.Combine(Server.MapPath("../Image/"), filename);
            voiture.Imagevoiture.SaveAs(filename);
            if (ModelState.IsValid)
            {
                db.voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categorieID = new SelectList(db.categories, "CategorieID", "CategorieID", voiture.categorieID);
            ViewBag.modelID = new SelectList(db.Modeles, "modelID", "nom", voiture.modelID);
            return View(voiture);
        }

        // GET: voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieID = new SelectList(db.categories, "CategorieID", "CategorieID", voiture.categorieID);
            ViewBag.modelID = new SelectList(db.Modeles, "modelID", "nom", voiture.modelID);
            return View(voiture);
        }

        // POST: voitures/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "voitureID,numero_matriculation,date_mise_circulation,prix_Par_Jour,carburant,image,categorieID,modelID")] voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorieID = new SelectList(db.categories, "CategorieID", "CategorieID", voiture.categorieID);
            ViewBag.modelID = new SelectList(db.Modeles, "modelID", "nom", voiture.modelID);
            return View(voiture);
        }

        // GET: voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            voiture voiture = db.voitures.Find(id);
            db.voitures.Remove(voiture);
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
