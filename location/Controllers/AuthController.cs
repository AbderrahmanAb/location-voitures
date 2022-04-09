using location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace location.Controllers
{
    public class AuthController : Controller
    {
        private GCDB db = new GCDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string pwd)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(pwd))
            {
                ViewBag.Message = "Les champs sont requis";
                return View();
            }

            var client = db.clts.Where(cl => cl.AdresseMail.ToLower() == email.ToLower() && cl.MotDePasse == pwd).SingleOrDefault();
            if (client == null)
            {
                ViewBag.Message = "Client n'existe pas";
                return View();
            }

            Session["cid"] = client.CID;

            return RedirectToAction("Index", "clts");
        }


    }
    }

