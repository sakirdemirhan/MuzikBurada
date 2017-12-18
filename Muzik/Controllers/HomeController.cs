using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entitiy.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Muzik.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TurlerRep rep = new TurlerRep(); 
            return View(rep.GetAll().Where(x => x.TurAdi != "_silindi").ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TurDetay()
        {
            return View();
        }

        public ActionResult Kesfet()
        {
            TurlerRep rep = new TurlerRep();
            var liste = rep.GetAllUser().Where( x=>x.Email != "blogmoderator@admin.com" && x.KullaniciTur.TurAdi != "_silindi");
            //ViewData["Model"] = liste;
            return View(liste);
        }

        [HttpPost]
        public ActionResult Kesfet(int id)
        {
            TurlerRep rep = new TurlerRep();
            var liste = rep.GetAllUser().Where(x=>x.TurID==id && x.KullaniciTur.TurAdi!="_silindi");
            //ViewData["Model"] = liste;
            return View(liste);
        }
        public ActionResult GrupDetay(string id)
        {
            TurlerRep rep = new TurlerRep();
            var user = rep.GetAllUser().FirstOrDefault(x => x.Id==id);
            return View(user);
        }
    }
}