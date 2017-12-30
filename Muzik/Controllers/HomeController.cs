﻿using System;
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

        public ActionResult Ara(string id)
        {
            Session["aranacak"] = id.ToLower();
            var str = Session["aranacak"].ToString();
            return View();
        }
        public ActionResult GrupSonuclar()
        {
            TurlerRep rep = new TurlerRep();
            var kullanicilar = rep.GetAllUser().Where(x => 
            x.Email != "blogmoderator@admin.com" 
            && x.KullaniciTur.TurAdi != "_silindi"
            && x.Email != "admin@admin.com");
            List<Kullanici> liste = new List<Kullanici>();
            foreach (var item in kullanicilar)
            {
                item.GrupUyeleri += " A";
                if (item.GrupAdi.ToLower().Contains(Session["aranacak"].ToString()) 
                    || item.GrupUyeleri.ToLower().Contains(Session["aranacak"].ToString())
                    || item.Aciklama.ToLower().Contains(Session["aranacak"].ToString()))
                {
                    liste.Add(item);
                }
            }
            //var liste = kullanicilar.Where(x => x.Aciklama.ToLower().Contains(Session["aranacak"].ToString())
            //|| x.GrupUyeleri.ToLower().Contains(Session["aranacak"].ToString())
            //|| x.GrupAdi.ToLower().Contains(Session["aranacak"].ToString()));
            return View(liste);
        }
        public ActionResult BlogSonuclar()
        {
            BlogRep rep = new BlogRep();
            var blogs = rep.GetAll().Where(x => x.Etiket.Contains(Session["aranacak"].ToString())
             || x.Baslik.Contains(Session["aranacak"].ToString()));
            return View(blogs);
        }

        public ActionResult Kesfet()
        {
            TurlerRep rep = new TurlerRep();
            var liste = rep.GetAllUser().Where( x=>x.Email != "blogmoderator@admin.com" && x.KullaniciTur.TurAdi != "_silindi").OrderByDescending(t=>t.SiteKayitTarihi);
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
        [HttpPost]
        public JsonResult Begen(string id)
        {
            Session["begeniler"] += " ";
            string begenilenler = Session["begeniler"].ToString();
            if (begenilenler.Contains(id))
            {
                return Json("Bu grubu daha önce zaten beğenmişsiniz.");
            }
            TurlerRep rep = new TurlerRep();
            var user = rep.GetAllUser().FirstOrDefault(x => x.Id == id);
            user.Begeni++;
            rep.UpdateUser(user);
            
            Session["begeniler"] += id;
            return Json(user.GrupAdi + " grubunu beğendiniz.");
        }
    }
}