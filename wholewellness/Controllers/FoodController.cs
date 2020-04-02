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

        //private readonly static int USER_NUMBER = 1;

        // GET: Food
        public ActionResult Index()
        {
            return RedirectToAction("FoodHome");
        }
        
        public ActionResult FoodHome()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);
            Day day = DayDAL.GetDayByUserAndDay(user.intUserID);

            FoodVM model = new FoodVM()
            {
                user = user,
                LstMealsForDay = MealDAL.GetMealsByDayAndUser(day.intDayID, user.intUserID)
            };
            return View("FoodHome", model);
        }

        public ActionResult AddMeal()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);
            Day currentDay = DayDAL.GetDayByUserAndDay(user.intUserID);

            AddMealVM model = new AddMealVM
            {
                user = user,
                currentDayForUser = currentDay,
                possibleFoodItems = FoodItemDAL.GetAllFoodItems(),
                intPassedCurrentDayID = currentDay.intDayID,
                intPassedUserID = user.intUserID
            };

            return View(model);
        }

        [HttpPost]
        //public ActionResult PostNewMeal(MealType mealType, List<FoodItem> lstContents, int intDayID, int intUserID)
        public ActionResult PostNewMeal(MealType newMealType, int[] arrFoodItemIDs, int intPassedUserID, int intPassedCurrentDayID)
        {
            //Meal newMeal = Meal.of(mealType, lstContents);

            List<FoodItem> lstContents = FoodItemDAL.GetFoodItemsByIDs(arrFoodItemIDs);
            Meal newMeal = Meal.of(newMealType, lstContents);

            bool success = MealDAL.AddMeal(newMeal, intPassedUserID, intPassedCurrentDayID);

            return RedirectToAction("Index", "Home");
        }

        // TODO: finish
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

        // TODO: finish
        public ActionResult GetUserInfo(int intUserID)
        {
            HomeVM model = new HomeVM();
            //{
               // User = UserDAL.GetUser(intUserID)
          //  };
            return View("Home", model);
        }

        public ActionResult GetAllFoodItems()
        {
            AddMealVM model = new AddMealVM()
            {
                possibleFoodItems = FoodItemDAL.GetAllFoodItems()
            };
            return View("FoodHome", model);
        }

           
    }
}