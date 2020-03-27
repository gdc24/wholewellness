using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.ViewModels
{
    public class ExerciseVM
    {
        public IEnumerable<WorkoutRoutine> LstWorkoutRoutines { get; set; }
    }
}
