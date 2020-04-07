using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class HealthierOptionsVM
    {

        public List<FoodItem> possibleFoodItems { get; set; }

        public User user { get; set; }

        //public int intPassedUserID { get; set; }

        public int intPassedFoodItemID { get; set; }

        public HealthierOptionsResultsVM _results_vm { get; set; }

        public HealthierOptionsVM()
        {
            _results_vm = new HealthierOptionsResultsVM();
        }

    }
}