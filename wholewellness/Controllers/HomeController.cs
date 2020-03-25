using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using wholewellness.Models;
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

        public ActionResult AddMeal(MealType mealType, List<FoodItem> lstContents, int intDayID, int intUserID)
        {
            Meal newMeal = Meal.of(mealType, lstContents);

            FoodVM model = new FoodVM()
            {
                LstMealsForDay = MealDAL.GetMealsByDayAndUser(intDayID, intUserID).add(newMeal)
            };

            return View("Food", model);
        }

        public ActionResult DeleteMeal(Meal meal, int intDayID, int intUserID)
        {
            FoodVM model = new FoodVM()
            {
                LstMealsForDay = MealDAL.GetMealsByDayAndUser(intDayID, intUserID) // need to remove meal still
            };
            return View("Food", model);
        }

        public ActionResult GetHistory(int intUserID)
        {
            HomeVM model = new HomeVM()
            {
                User = (IEnumerable<User>)UserDAL.GetUser(intUserID),
                IntCaloriesLeft = (IEnumerable<int>)((Day) DayDAL.GetDaysByUser(intUserID)).intCalsLeft,
                MealsEaten = ((Day) DayDAL.GetDaysByUser(intUserID)).lstMealsAdded
            };

            return View("Home", model);
        }

        public ActionResult GetUserInfo(int intUserID)
        {
            HomeVM model = new HomeVM()
            {
                User = (IEnumerable<User>)UserDAL.GetUser(intUserID),
            };
            return View("Home", model);
        }


        // GetAllFoodItems
        public ActionResult GetAllFoodItems()
        {
            FoodVM model = new FoodVM()
            {

            };
            return View("Food", model);
        }



        // addExercise

        // deleteExercise

        // GetAllWorkouts 


    }
}
