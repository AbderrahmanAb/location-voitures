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
    public class cltsController : Controller
    {
        private GCDB db = new GCDB();

        // GET: clts
        public ActionResult Index()
        {
            return View(db.clts.ToList());
        }

        // GET: clts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clt clt = db.clts.Find(id);
            if (clt == null)
            {
                return HttpNotFound();
            }
            return View(clt);
        }

        // GET: clts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clts/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clt clt)
        {//Imagepermis
            string filename = Path.GetFileNameWithoutExtension(clt.ImageCin.FileName);
            string extention = Path.GetExtension(clt.ImageCin.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
            clt.CIN = "../Image/" + filename;
            filename = Path.Combine(Server.MapPath("../Image/"), filename);
            clt.ImageCin.SaveAs(filename);
            //********************************
            string filename1 = Path.GetFileNameWithoutExtension(clt.Imagepermis.FileName);
            string extention1 = Path.GetExtension(clt.Imagepermis.FileName);
            filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extention1;
            clt.permis = "../Image/" + filename1;
            filename1 = Path.Combine(Server.MapPath("../Image/"), filename1);
            clt.Imagepermis.SaveAs(filename1);

            if (ModelState.IsValid)
            {
                db.clts.Add(clt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clt);
        }

        // GET: clts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clt clt = db.clts.Find(id);
            if (clt == null)
            {
                return HttpNotFound();
            }
            return View(clt);
        }

        // POST: clts/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CID,Nom,AdresseMail,MotDePasse,DateNaissance,CIN,permis")] clt clt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clt);
        }

        // GET: clts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clt clt = db.clts.Find(id);
            if (clt == null)
            {
                return HttpNotFound();
            }
            return View(clt);
        }

        // POST: clts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clt clt = db.clts.Find(id);
            db.clts.Remove(clt);
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
