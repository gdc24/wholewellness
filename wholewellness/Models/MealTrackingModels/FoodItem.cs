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
        public int intFoodItemID { get; set; }

        [Display(Name = "Name")]
        public String strName { get; set; }

        [Display(Name = "Calories")]
        public int intCalories { get; set; }

        [Display(Name = "Brand Name")]
        public String? strBrandName { get; set; }


        private FoodItem(int intFoodItemID, String strName, int intCalories, String? strBrandName) 
        {
            this.intFoodItemID = intFoodItemID;
            this.strName = strName;
            this.intCalories = intCalories;
            if (strBrandName != null)
                this.strBrandName = strBrandName;
        }

        public FoodItem of(int intFoodItemID, String strName, int intCalories, String? strBrandName)
        {
            return new FoodItem(intFoodItemID, strName, intCalories, strBrandName);
        }
    }
}
