using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            var values = db.TblAbout2.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddAbout(TblAbout2 p)
        {
            db.TblAbout2.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout2.Find(id);
            db.TblAbout2.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            //ViewBag.aboutId = id;
            var values = db.TblAbout2.Find(id);
            return View(values);
        }
        [HttpPost]

        public ActionResult UpdateAbout(TblAbout2 p)
        {

            var values = db.TblAbout2.Find(p.AboutID);
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            values.Title = p.Title;
            values.NameSurname = p.NameSurname;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}