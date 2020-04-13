using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class AddFoodItemVM : FoodItem
    {
        public User user { get; set; }

        public AddFoodItemVM() { }
    }
}