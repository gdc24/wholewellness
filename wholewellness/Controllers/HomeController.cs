using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using wholewellness.Models;
using wholewellness.ViewModels;
using wholewellness.DAL;
using wholewellness.Views.ViewModels.CRUD_VMs;

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
                User = UserDAL.GetUser() // not right, need user ID as input
            };

            return View("Food", model);
        }


      
        // deleteMeal(Meal meal)
        

        // getHistory()
        public ActionResult GetHistory()
        {
            HomeVM model = new HomeVM()
            {

            }
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
                LstMealsForDay.DayDAL.lstMealsAdded(),

            };
        }



        // addExercise

        // deleteExercise

        // GetAllWorkouts() 


    }
}
