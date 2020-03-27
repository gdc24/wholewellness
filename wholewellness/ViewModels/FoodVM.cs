using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
namespace wholewellness.ViewModels
{
    public class FoodVM
    {
        public List<Meal> LstMeals { get; set; }
        public List<Meal> LstMealsForDay { get; internal set; }

        public User user { get; set; }
    }
}