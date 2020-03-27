using System.Linq;
using wholewellness.DAL;
using wholewellness.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using wholewellness.ViewModels;

namespace wholewellness.Controllers
{
    public class FoodController : Controller
    {

        // GET: Food
        public ActionResult Index()
        {
            return View("FoodHome");
        }
        
        public ActionResult FoodHome()
        {
            return View("FoodHome");
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
            HomeVM model = new HomeVM();
            //{
               // User = UserDAL.GetUser(intUserID)
          //  };
            return View("Home", model);
        }


        // below will be implemented in a future demo:

            // GetAllFoodItems

            // addExercise

            // deleteExercise

            // GetAllWorkouts
    }
}