using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using wholewellness.Models;
using wholewellness.Models.ExerciseTrackingModels;
using wholewellness.ViewModels;
using wholewellness.DAL;

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

        // mostly action results
        // from that action result you call the DAL method
        // pass back down data you need

        // addMeal(Meal meal)
        public ActionResult AddMeal(MealType mealType, List<FoodItem> lstContents)
        {
            Meal newMeal = Meal.of(mealType, lstContents);

            FoodVM model = new FoodVM()
            {
                LstMealsForDay = DayDAL.lstMealsAdded(),
                User = UserDAL.GetUserFromDR() // not right
            };

            return View("Food", model);
        }


      
        // deleteMeal(Meal meal)


        // addExercise(
        

        // deleteExercise
        

        // getHistory()


        // GetUserInfo(String username)


        // GetAllWorkouts() - is this meant to get all that the user has done in a day or all that there are in the database?

        // GetAllFoodItems() - is this meant to get all that the user has eaten in a day or all that there are in the database?


    }
}
