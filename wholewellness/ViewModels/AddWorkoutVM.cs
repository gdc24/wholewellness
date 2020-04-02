using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;
using wholewellness.Models.ExerciseTrackingModels;

namespace wholewellness.ViewModels
{
    public class AddWorkoutVM
    {
        public Day currentDayForUser { get; set; }

        public User user { get; set; }

        public int intPassedUserID { get; set; }

        public int intPassedCurrentDayID { get; set; }

        public int[] arrExercises;

        public List<ExerciseType> possibleExercises { get; set; }

    }
}
