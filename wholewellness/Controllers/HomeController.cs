using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.Models;
using wholewellness.DAL;
using wholewellness.Views.ViewModels;
using System.Linq;

namespace wholewellness.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        


    }
}
