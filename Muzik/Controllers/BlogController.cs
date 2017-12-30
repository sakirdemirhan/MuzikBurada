using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entitiy.Models;
using Microsoft.AspNet.Identity;

namespace Muzik.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            BlogRep rep = new BlogRep();
            var liste = rep.GetAll().OrderByDescending(x=>x.EklenmeTarihi);
            return View(liste);
        }

        [Authorize(Roles = "Admin,BlogModerator")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,BlogModerator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Blog article)
        {
            if (ModelState.IsValid)
            {
                new BlogRep().Insert(article);
            }

            return View();
        }

        public ActionResult Detail(int id)
        {
            BlogRep rep = new BlogRep();
            var blog = rep.GetById(id);
            return View(blog);
        }

        public ActionResult Yorum(int id)
        {
            YorumRep rep = new YorumRep();
            var liste = rep.GetAll().Where(x => x.BlogYorum.BlogID == id);
            return View(liste);
        }

        [HttpPost]
        public ActionResult YorumYap(Yorum yorum, int id)
        {
            YorumRep rep = new YorumRep();
            yorum.BlogYorumID = id;
            yorum.YorumYapanId = User.Identity.GetUserId();
            yorum.EklenmeTarihi = DateTime.Now;
            rep.Insert(yorum);
            return RedirectToAction("Detail", "Blog", new { @id = id });
        }
        public ActionResult tags(string id)
        {
            BlogRep rep = new BlogRep();
            var liste = rep.GetAll().Where(x => x.Etiket.Contains(id));
            ViewBag.tag = id;
            return View(liste);
        }
    }
}