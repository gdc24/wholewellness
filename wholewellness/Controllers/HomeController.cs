using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.Models;
using wholewellness.DAL;
using wholewellness.Views.ViewModels.CRUD_VMs;
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

        public ActionResult AddMeal(MealType mealType, List<FoodItem> lstContents, int intDayID, int intUserID)
        {
            Meal newMeal = Meal.of(mealType, lstContents);

            FoodVM model = new FoodVM()
            {
                LstMealsForDay = MealDAL.GetMealsByDayAndUser(intDayID, intUserID).Append(newMeal)
            };

            return View("Food", model);
        }

        public ActionResult DeleteMeal(Meal meal, int intDayID, int intUserID)
        {
            FoodVM model = new FoodVM()
            {
                LstMealsForDay = MealDAL.GetMealsByDayAndUser(intDayID, intUserID).Where(m => m != meal)
            };
            return View("Food", model);
        }

        public ActionResult GetHistory(int intUserID)
        {
            HomeVM model = new HomeVM();

            return View("Home", model);
        }

        public ActionResult GetUserInfo(int intUserID)
        {
            HomeVM model = new HomeVM()
            {
                user = UserDAL.GetUser(intUserID),
            };
            return View("Home", model);
        }


        // below will be implemented in a future demo:

            // GetAllFoodItems
        
            // addExercise

            // deleteExercise

            // GetAllWorkouts 


    }
}
