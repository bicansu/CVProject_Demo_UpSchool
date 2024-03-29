﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var mail = Session["MemberEmail"].ToString();
            var values = db.TblMember.Where(x => x.MemberEmail == mail).FirstOrDefault();
            ViewBag.name = values.MemberName;
            ViewBag.Surname = values.MemberSurname;
            ViewBag.id = values.MemberID;
            return View();
        }
    }
}