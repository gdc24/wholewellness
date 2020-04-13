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


        public ActionResult HealthierOptions()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);

            HealthierOptionsVM model = new HealthierOptionsVM
            {
                possibleFoodItems = FoodItemDAL.GetAllFoodItems()
            };

            model._results_vm.alternatives = new List<FoodItem>();
            model.user = user;

            return View("HealthierOptions", model);
        }

        public ActionResult GetHealthierOptions(int intFoodItemID)
        {
            HealthierOptionsResultsVM model = new HealthierOptionsResultsVM
            {
                alternatives = FoodItemDAL.GetHealthyAlternatives(intFoodItemID),
                original = FoodItemDAL.GetFoodItemByID(intFoodItemID)
            };

            if (!model.alternatives.Any())
                model.strSearchMessage = "No results for that food item. Please select another.";

            return PartialView("_HealthierOptionsResults", model);
        }

        public ActionResult AddFoodItem()
        {
            User user = UserDAL.GetUser(HomeController.USER_NUMBER);

            AddFoodItemVM model = new AddFoodItemVM
            {
                user = user
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PostNewFoodItem(FoodItem newFoodItem)
        {

            bool success = FoodItemDAL.AddFoodItem(newFoodItem);

            if (success)
                return RedirectToAction("AddMeal");
            else
                throw new Exception("error adding food item");
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
        public ActionResult PostNewMeal(MealType newMealType, int[] arrFoodItemIDs, int intPassedUserID, int intPassedCurrentDayID)
        {

            List<FoodItem> lstContents = FoodItemDAL.GetFoodItemsByIDs(arrFoodItemIDs);
            Meal newMeal = Meal.of(newMealType, lstContents);

            bool success = MealDAL.AddMeal(newMeal, intPassedUserID, intPassedCurrentDayID);

            return RedirectToAction("Index", "Home");
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
                user = UserDAL.GetUser(intUserID)
            };
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