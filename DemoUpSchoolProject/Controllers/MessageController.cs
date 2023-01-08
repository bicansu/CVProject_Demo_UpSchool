using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Inbox()
        {
            var mail = Session["MemberEmail"].ToString();
            var values = db.TblMessage.Where(x => x.ReceiverMail == mail).ToList();
            return View(values);
        }  
        public ActionResult OutBox()
        {
            var mail = Session["MemberEmail"].ToString();
            var values = db.TblMessage.Where(x => x.SenderMail == mail).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage p)
        {
            var mail = Session["MemberEmail"].ToString();
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SenderMail = mail;
            p.SenderNameSurname = db.TblMember.Where(x => x.MemberEmail == mail).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            p.ReceiverNameSurname = db.TblMember.Where(x => x.MemberEmail == p.ReceiverMail).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            db.TblMessage.Add(p);
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }
      
        public ActionResult MessageDetails(int id)
        {

            var mesajDetay = db.TblMessage.Where(x => x.MessageID == id).FirstOrDefault();
            db.SaveChanges();
            ViewBag.mesaj = mesajDetay;
           
            return View();
        }
        public ActionResult DeleteMessage(int id)
        {
            var values = db.TblMessage.Find(id);
            db.TblMessage.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Inbox");
        }



    }
}