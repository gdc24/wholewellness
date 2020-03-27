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

        public readonly static int USER_NUMBER = 1;
        private readonly static int NUM_PREVIEWS = 3;

        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            Day currentDayForUser = DayDAL.GetDayByUserAndDay(USER_NUMBER);
            User user = UserDAL.GetUser(USER_NUMBER);

            HomeVM model = new HomeVM
            {
                user = user,
                intCalsLeft = currentDayForUser.intCalsLeft,
                mostRecentMeals = MealDAL.GetMealsByDayAndUser(currentDayForUser.intDayID, user.intUserID).Take(NUM_PREVIEWS).ToList()
            };
            return View(model);
        }

        


    }
}
