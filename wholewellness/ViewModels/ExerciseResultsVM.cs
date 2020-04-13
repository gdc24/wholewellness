using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.ViewModels
{
    public class ExerciseResultsVM : ExerciseType
    {
        public string strSearchMessage { get; set; }

        public List<ExerciseType> possibleExercises { get; set; }


        public ExerciseResultsVM()
        {
            strSearchMessage = "Please select a muscle group from the dropdown above.";
            possibleExercises = new List<ExerciseType>();
        }
    }
}