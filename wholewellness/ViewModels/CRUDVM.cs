using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Views.ViewModels;

namespace wholewellness.Views.ViewModels
{
    public class CRUDVM
    { 
        public ExerciseVM _exercise_vm { get; set; }
        public FoodVM _food_vm { get; set; }

        public CRUDVM()
        {
            _exercise_vm = new ExerciseVM();
            _food_vm = new FoodVM();
        }
    }
}
