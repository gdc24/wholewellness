using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wholewellness.Models
{
    public class FoodItem
    {
        [Key]

        [Display(Name = "Food Item ID")]
        public int foodItemID { get; set; }

        [Display(Name = "Name")]
        public String name { get; set; }

        [Display(Name = "Calories")]
        public int calories { get; set; }

        [Display(Name = "Brand Name")]
        public String brandName { get; set; }


        public FoodItem(int foodItemID, String name, int calories, String brandName) 
        {
            this.foodItemID = foodItemID;
            this.name = name;
            this.calories = calories;
            this.brandName = brandName;
        }

        public FoodItem of(int foodItemID, String name, int calories, String brandName)
        {
            return new FoodItem(foodItemID, name, calories, brandName);
        }
    }
}
