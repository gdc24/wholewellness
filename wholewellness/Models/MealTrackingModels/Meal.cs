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
        [Display(Name = "Meal ID")]
        public int intMealID { get; set; }

        [Display(Name = "Meal Type")]
        public MealType mealType { get; set; }

        [Display(Name = "Contents")]
        public List<FoodItem> lstContents { get; set; }

        private Meal(MealType mealType, List<FoodItem> lstContents)
        {
            this.mealType = mealType;
            this.lstContents = lstContents;
        }

        public static Meal of(MealType mealType, List<FoodItem> lstContents)
        {
            return new Meal(mealType, lstContents);
        }

    }
}
