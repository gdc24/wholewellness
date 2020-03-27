using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.Models;
using wholewellness.DAL;
using System.Linq;
using wholewellness.ViewModels;

namespace wholewellness.Controllers
{
    public class HomeController : Controller
    {

        private static int USER_NUMBER = 1;
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            HomeVM model = new HomeVM();
            model.user = UserDAL.GetUser(USER_NUMBER);
            return View(model);
        }

        


    }
}
