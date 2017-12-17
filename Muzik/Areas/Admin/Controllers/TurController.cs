using BLL;
using Entitiy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muzik.Areas.Admin.Controllers
{
    public class TurController : Controller
    {
        // GET: Admin/Tur
        public ActionResult Index()
        {
            TurlerRep rep = new TurlerRep();
            return View(rep.GetAll().Where(x=>x.TurAdi!="_silindi").ToList());
        }
        
        public ActionResult TurEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TurEkle(Tur tur)
        {
            TurlerRep rep = new TurlerRep();
            rep.Insert(tur);
            return View();
        }
        public ActionResult TurDuzenle(int id)
        {
            TurlerRep rep = new TurlerRep();
            var tur = rep.GetById(id);
            return View(tur);
        }
        [HttpPost]
        public ActionResult TurDuzenle(Tur tur)
        {
            TurlerRep rep = new TurlerRep();
            rep.Update(tur);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult TurSil(int id)
        {
            TurlerRep rep = new TurlerRep();
            var tur = rep.GetById(id);
            tur.TurAdi = "_silindi";
            tur.TurAciklama = "";
            rep.Update(tur);
            return Json("Kayıt Başarıyla Silindi.");
        }
    }
}