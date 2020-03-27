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
        public string strName { get; set; }

        [Display(Name = "Calories")]
        public int intCalories { get; set; }

        [Display(Name = "Brand Name")]
        public string strBrandName { get; set; }


        [Display(Name = "Full Name and Calories")]
        public string strFullNameAndCals { get; set; }


        private FoodItem(int intFoodItemID, string strName, int intCalories, string strBrandName) 
        {
            this.intFoodItemID = intFoodItemID;
            this.strName = strName;
            this.intCalories = intCalories;
            if (strBrandName != null)
                this.strBrandName = strBrandName;
            else
                this.strBrandName = "";
            this.strFullNameAndCals = strBrandName + " " + strName + " (" + intCalories + " calories)";
        }

        public static FoodItem of(int intFoodItemID, string strName, int intCalories, string strBrandName)
        {
            return new FoodItem(intFoodItemID, strName, intCalories, strBrandName);
        }
    }
}
