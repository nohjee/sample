using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WepApiSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult UpdateProduct()
        {
            return View();
        }

        public ActionResult FormDataTransfer()
        {
            return View();
        }

        public ActionResult CookieForm()
        {
            return View();
        }
    }
}
