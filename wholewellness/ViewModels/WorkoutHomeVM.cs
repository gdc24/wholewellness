using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.ViewModels
{
    public class WorkoutHomeVM
    {
        public IEnumerable<WorkoutRoutine> LstWorkoutRoutines { get; set; }

        public IEnumerable<Meal> LstMealsForDay { get; internal set; }

        public User user { get; set; }
        public WorkoutHomeVM()
        {
            LstWorkoutRoutines = new List<WorkoutRoutine>();
        }
    }
}
