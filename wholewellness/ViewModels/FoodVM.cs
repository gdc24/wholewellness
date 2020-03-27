using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
namespace wholewellness.ViewModels
{
    public class FoodVM
    {
        public IEnumerable<Meal> LstMeals { get; set; }
        public IEnumerable<Meal> LstMealsForDay { get; internal set; }
    }
}