using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class LoginController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            var values = db.TblMember.FirstOrDefault(x => x.MemberEmail == p.MemberEmail && x.MemberPassword == p.MemberPassword);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.MemberEmail, false);
                Session["MemberEmail"] = p.MemberEmail;
                return RedirectToAction("Index","About");

            }
            else 
            {
                return RedirectToAction("Index");
            }
           
        }
    }
}