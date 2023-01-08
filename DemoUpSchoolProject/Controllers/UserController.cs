using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;
namespace DemoUpSchoolProject.Controllers
{
    public class UserController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
    
    public PartialViewResult Partial1()
    {
        return PartialView();
    }

    public PartialViewResult HeadPartial()
    {
            return PartialView();
    }
    public PartialViewResult HeaderPartial()
    {
            return PartialView();
    }
    public PartialViewResult AboutPartial()
    {
            var values = db.TblAbout2.ToList();
            return PartialView(values);
    }
    public PartialViewResult ServicePartial()
    {
            ViewBag.Description = db.TblServices.Where(x => x.ServicesID == 1).Select(y => y.Description).FirstOrDefault();
            ViewBag.Image = db.TblAbout2.Where(x => x.AboutID == 1).Select(y => y.ImageUrl2).FirstOrDefault();
            var values = db.TblServices.ToList();
            return PartialView(values);
    }

    public PartialViewResult SkillsPartial()
    {
            var values = db.TblSkills.ToList();
            return PartialView(values);
            
    }

     public PartialViewResult CrtPartial()
     {
            ViewBag.Resim = db.TblCrt.Where(x => x.CrtID == 1).Select(y => y.Image).FirstOrDefault();
            var values = db.TblCrt.ToList();
            return PartialView(values);

      }

        public PartialViewResult ReferencePartial()
        {
            //ViewBag.Resim = db.TblCrt.Where(x => x.CrtID == 1).Select(y => y.Image).FirstOrDefault();
            var values = db.TblReference.ToList();
            return PartialView(values);

        }
        [HttpGet]
        public PartialViewResult MessagePartial()
        {
            var values = db.TblMember.Where(z => z.MemberID == 1004).FirstOrDefault();
            ViewBag.Aciklama = values.MemberDescription;
            ViewBag.Adres = values.MemberAddress;
            ViewBag.Tel = values.MemberPhone;
            ViewBag.Email = values.MemberEmail;

            return PartialView();

        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage p)
        { 
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ReceiverNameSurname = "Cansu Sürücü";
            p.ReceiverMail = "cansubican11@gmail.com";

            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}