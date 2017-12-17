using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muzik.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Admin/Kullanici
        public ActionResult Index()
        {
            return View();
        }
    }
}