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

        private readonly static int USER_NUMBER = 1;

        // GET: Food
        public ActionResult Index()
        {
            return View("FoodHome");
        }
        
        public ActionResult FoodHome()
        {
            return View("FoodHome");
        }

        public ActionResult AddMeal()
        {
            User user = UserDAL.GetUser(USER_NUMBER);

            AddMealVM model = new AddMealVM
            {
                user = user,
                currentDayForUser = DayDAL.GetDayByUserAndDay(user.intUserID),
                possibleFoodItems = FoodItemDAL.GetAllFoodItems()
            };

            return View(model);
        }

        [HttpPost]
        //public ActionResult PostNewMeal(MealType mealType, List<FoodItem> lstContents, int intDayID, int intUserID)
        public ActionResult PostNewMeal(MealType newMealType, int[] arrFoodItemIDs, int intUserID, int intDayID)
        {
            //Meal newMeal = Meal.of(mealType, lstContents);

            List<FoodItem> lstContents = FoodItemDAL.GetFoodItemsByIDs(arrFoodItemIDs);
            Meal newMeal = Meal.of(newMealType, lstContents);

            bool success = MealDAL.AddMeal(newMeal, intUserID, intDayID);

            var x = 0;

            return RedirectToAction("AddMeal");
        }

        public ActionResult DeleteMeal(Meal meal, int intDayID, int intUserID)
        {
            FoodVM model = new FoodVM();
            //{
            //    LstMealsForDay = MealDAL.GetMealsByDayAndUser(intDayID, intUserID).Where(m => m != meal)
            //};
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