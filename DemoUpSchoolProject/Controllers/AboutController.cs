using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;

namespace DemoUpSchoolProject.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        // GET: About
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        
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

            string birinci_foto = "";
            string ikinci_foto = "";
            if (Request.Files.Count > 1)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string dosyaAdi = "";
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    dosyaAdi = Path.GetFileName(Request.Files[i].FileName);
                    string yol = "~/Images/" + dosyaAdi;
                    Request.Files[i].SaveAs(Server.MapPath(yol));
                    if (i == 0)
                    {
                        birinci_foto = "/Images/" + dosyaAdi;
                    }
                    else
                    {
                        ikinci_foto = "/Images/" + dosyaAdi;
                    }


                }
            }
            TblAbout2 tbl = new TblAbout2();

            tbl.Title = p.Title;
            tbl.Description = p.Description;
            tbl.ImageUrl = p.ImageUrl;
            tbl.ImageUrl2 = p.ImageUrl2;
            tbl.NameSurname = p.NameSurname;

            db.TblAbout2.Add(tbl);
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
            string birinci_foto = "";
            string ikinci_foto = "";
            if(Request.Files.Count>1)
            {
                for(int i=0; i<Request.Files.Count; i++)
                {
                    string dosyaAdi = "";
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    dosyaAdi = Path.GetFileName(Request.Files[i].FileName);
                    string yol = "~/Images/" + dosyaAdi;
                    Request.Files[i].SaveAs(Server.MapPath(yol));
                    if(i==0)
                    {
                        birinci_foto = "/Images/" + dosyaAdi;
                    }else{                    
                        ikinci_foto = "/Images/" + dosyaAdi;
                    }
                  

                }

            }
            var values = db.TblAbout2.Find(p.AboutID);
            values.Description = p.Description;
            values.ImageUrl = birinci_foto;
            values.ImageUrl2 = ikinci_foto;
            values.Title = p.Title;
            values.NameSurname = p.NameSurname;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}