using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entitiy.Models;

namespace Muzik.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            BlogRep rep = new BlogRep();
            var liste = rep.GetAll();
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
    }
}