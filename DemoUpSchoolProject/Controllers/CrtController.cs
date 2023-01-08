using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class CrtController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            
            var values = db.TblCrt.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCrt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCrt(TblCrt p)
        {
            db.TblCrt.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCrt(int id)
        {
            var values = db.TblCrt.Find(id);
            db.TblCrt.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCrt(int id)
        {
            var values = db.TblCrt.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCrt(TblCrt p)
        {
            var values = db.TblCrt.Find(p.CrtID);
            values.CrtName = p.CrtName;
            values.CrtDescription = p.CrtDescription;
            values.CrtDate = p.CrtDate;
            values.Image = p.Image;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}