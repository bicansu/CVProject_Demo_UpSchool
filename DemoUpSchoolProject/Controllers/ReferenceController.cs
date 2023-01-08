using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class ReferenceController : Controller
    {
        // GET: Reference


        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
           
            var values = db.TblReference.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddReference()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReference(TblReference p)
        {
            db.TblReference.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteReference(int id)
        {
            var values = db.TblReference.Find(id);
            db.TblReference.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var values = db.TblReference.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateReference(TblReference p)
        {
            var values = db.TblReference.Find(p.ReferenceID);
            values.ReferenceName = p.ReferenceName;
            values.ReferencePhone = p.ReferencePhone;
            values.ReferenceMail = p.ReferenceMail;
            values.ReferenceCompany = p.ReferenceCompany;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}