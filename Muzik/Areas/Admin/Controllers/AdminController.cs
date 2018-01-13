using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Muzik.Areas.Admin.Controllers { 

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            TurlerRep rep = new TurlerRep();
            YorumRep yRep = new YorumRep();
            BlogRep bRep = new BlogRep();
            ViewBag.YorumSayisi = yRep.GetAll().Count.ToString();
            ViewBag.BlogSayisi = bRep.GetAll().Count.ToString();
            ViewBag.TurSayisi = rep.GetAll().Count(x => x.TurAdi!="_silindi").ToString();
            ViewBag.KullaniciSayisi = rep.GetAllUser().Count().ToString();
            return View();
        }
    }
}