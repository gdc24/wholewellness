using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
using wholewellness.Views.ViewModels.CRUD_VMs;

namespace wholewellness.Views.ViewModels
{
    public class HomeVM
    { 
        public ExerciseVM _exercise_vm { get; set; }
        public FoodVM _food_vm { get; set; }
        public User user { get; internal set; }

        public HomeVM()
        {
            _exercise_vm = new ExerciseVM();
            _food_vm = new FoodVM();
        }
    }
}
