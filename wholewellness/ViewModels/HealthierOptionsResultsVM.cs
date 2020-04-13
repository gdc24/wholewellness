using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class HealthierOptionsResultsVM : HealthierOptions
    {
        public string strSearchMessage { get; set; }

        public HealthierOptionsResultsVM()
        {
            strSearchMessage = "Select a food item from above and hit search to see healthier options.";
            alternatives = new List<FoodItem>();
        }
    }
}