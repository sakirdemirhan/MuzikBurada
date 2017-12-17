using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Muzik.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            TurlerRep rep = new TurlerRep();
            ViewBag.TurSayisi = rep.GetAll().Count(x => x.TurAdi!="_silindi").ToString();
            ViewBag.KullaniciSayisi = rep.GetAllUser().Count().ToString();
            return View();
        }
    }
}