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

        // addMeal(Meal meal)
        public ActionResult AddMeal(MealType mealType, List<FoodItem> lstContents)
        {
            Meal newMeal = Meal.of(mealType, lstContents);

            FoodVM model = new FoodVM()
            {
                LstMealsForDay = DayDAL.lstMealsAdded(),
                User = UserDAL.GetUser(1) // not right, need user ID as input
            };

            return View("Food", model);
        }


      
        // deleteMeal(Meal meal)
        

        // getHistory()
        public ActionResult GetHistory()
        {
            string username = "username";
            User newUser = User.of(username,140,65,ExerciseLevel.MediumIntensity,1500,30,new List<Day>());

            HomeVM model = new HomeVM()
            {
                // User = UserDAL.GetUser(1),
                // calories left
                IntCaloriesLeft = DayDAL.GetDaysByUser(1)
                // meals eaten
            };

            return View("Home", model);
        }


        // GetUserInfo(String username)
        public ActionResult GetUserInfo()
        {
            HomeVM model = new HomeVM()
            {

            }
        }


        // GetAllFoodItems()
        public ActionResult GetAllFoodItems()
        {
            FoodVM model = new FoodVM()
            {
                

            };
            return View("Food", model);
        }



        // addExercise

        // deleteExercise

        // GetAllWorkouts() 


    }
}
