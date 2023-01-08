using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using DemoUpSchoolProject.Models.Entities;


namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        // GET: Servises
        /*
         ToList
         Add
         Remove
         Where
        */
         
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblServices p)
        {

           
           

            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImageUrlService = "/Images/" + dosyaAdi;

                TblServices tbl = new TblServices();

                tbl.Description = p.Description;
                tbl.ImageUrlService = p.ImageUrlService;
                db.TblServices.Add(tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
     
                return RedirectToAction("AddService");
            }
           
        }
        public ActionResult DeleteService(int id)
        {
            var values=db.TblServices.Find(id);
            db.TblServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblServices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblServices p)
        {

            if (Request.Files.Count > 0)
            {
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImageUrlService = "/Images/" + dosyaAdi;
                var values = db.TblServices.Find(p.ServicesID);
                values.Description = p.Description;
                values.ImageUrlService = p.ImageUrlService;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("UpdateService");
            }
          
        }
    }
}