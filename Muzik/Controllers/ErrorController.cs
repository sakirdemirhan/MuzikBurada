using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muzik.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Errror
        public ActionResult Error()
        {
            return View("Error");
        }
    }
}