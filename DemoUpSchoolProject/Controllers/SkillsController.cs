using DemoUpSchoolProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblSkills.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkills p)
        {
            db.TblSkills.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var values = db.TblSkills.Find(id);
            db.TblSkills.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = db.TblSkills.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkills p)
        {
            var values = db.TblSkills.Find(p.SkillID);
            values.SkillName = p.SkillName;
            values.SkillLevel = p.SkillLevel; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}