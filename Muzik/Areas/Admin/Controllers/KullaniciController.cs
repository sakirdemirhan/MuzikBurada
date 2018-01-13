using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Muzik.Models;

namespace Muzik.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [HttpPost]
        public JsonResult ModYap(string id)
        {
            TurlerRep rep = new TurlerRep();
            var user = rep.GetAllUser().FirstOrDefault(x => x.Id == id);
            var _context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.AddToRole(user.Id, "BlogModerator");
            
            return Json("Kullanıcı blog moderatörü yapıldı.");
        }
    }
}