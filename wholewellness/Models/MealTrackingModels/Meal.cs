using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models
{
    public class Meal
    {
        [Key]

        [Display(Name = "Meal Type")]
        MealType mealType { get; set; }

        [Display(Name = "Contents")]
        List<FoodItem> contents { get; set; }

        public Meal(MealType mealType, List<FoodItem> contents)
        {
            this.mealType = mealType;
            this.contents = contents;
        }

        public Meal of(MealType mealType, List<FoodItem> contents)
        {
            return new Meal(mealType, contents);
        }

    }
}
