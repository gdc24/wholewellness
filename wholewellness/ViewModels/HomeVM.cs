using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class HomeVM
    {
        public WorkoutHomeVM _exercise_vm { get; set; }
        public FoodVM _food_vm { get; set; }
        public User user { get; set; }

        public int intCalsLeft { get; set; }

        public int intExMinsLeft { get; set; }

        public List<Meal> mostRecentMeals { get; set; }

    }
}