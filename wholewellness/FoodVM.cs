using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
namespace wholewellness.Views.ViewModels.CRUD_VMs
{
    public class FoodVM : Meal
    {
        public IEnumerable<Meal> LstMeals { get; set; }
    }
}