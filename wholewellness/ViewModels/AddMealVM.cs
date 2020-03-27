using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class AddMealVM
    {

        public User user { get; set; }

        public Meal newMeal { get; set; }

        public List<FoodItem> possibleFoodItems { get; set; }
    }
}