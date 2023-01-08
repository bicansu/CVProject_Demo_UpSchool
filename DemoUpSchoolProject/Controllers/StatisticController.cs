using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            //referansların toplam sayısı
            ViewBag.v1 = db.TblTestimonial.Count();
            //İstanbuldaki referans sayısı
            ViewBag.v2 = db.TblTestimonial.Where(x => x.City == "İstanbul").Count();
            //Yazılım Mühendisi Haricindeki kişi sayısı
            ViewBag.v3 = db.TblTestimonial.Where(x => x.Profession != "Yazılım Mühendisi").Count();
            //Şehri Trabzon olan kişinin ismini getiren sorgu:
            ViewBag.v4 = db.TblTestimonial.Where(x => x.City == "Trabzon").Select(y => y.NameSurname).FirstOrDefault();
            //Referansların ortalama maaşı:
            ViewBag.V5 = db.TblTestimonial.Average(x => x.Balance);
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        public JsonResult getJson()
        {
            
            return this.Json(
                (from obj in db.TblTestimonial where obj.Profession == "Yazılım Mühendisi" select new {counter=obj.Profession, litres=obj.Balance}), 
                JsonRequestBehavior.AllowGet
                );
        }
    }
}