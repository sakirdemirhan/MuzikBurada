using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entitiy.Models;

namespace Muzik.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogAdminController : Controller
    {
        // GET: Admin/Blog
        public ActionResult Index()
        {
            BlogRep rep = new BlogRep();
            return View(rep.GetAll());
        }

        [HttpPost]
        public JsonResult BlogSil(int id)
        {
            BlogRep rep = new BlogRep();
            rep.Delete(id);
            return Json("Kayıt Başarıyla Silindi.");
        }
    }
}