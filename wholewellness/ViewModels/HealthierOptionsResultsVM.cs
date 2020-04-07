using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.ViewModels
{
    public class HealthierOptionsResultsVM : HealthierOptions
    {
        public HealthierOptionsResultsVM()
        {
            alternatives = new List<FoodItem>();
        }
    }
}