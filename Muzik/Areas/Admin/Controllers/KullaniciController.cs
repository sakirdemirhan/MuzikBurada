using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Muzik.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Admin/Kullanici
        public ActionResult Index()
        {
            TurlerRep rep = new TurlerRep();
            var liste = rep.GetAllUser();
            return View(liste);
        }
        [HttpPost]
        public JsonResult KullaniciSil(string id)
        {
            TurlerRep rep = new TurlerRep();
            rep.DeleteUser(id);
            return Json("Kayıt Başarıyla Silindi.");
        }
    }
}