using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models.ExerciseTrackingModels
{
    public class ExerciseType
    {
        [Key]
        [Display(Name = "Exercise Type ID")]
        public int intExerciseTypeID { get; set; }

        [Display(Name = "Muscle Group")]
        public MuscleGroup muscleGroup { get; set; }

        [Display(Name = "Name")]
        public string strName { get; set; }

        [Display(Name = "Calories Burned")]
        public int intCaloriesBurned { get; set; }

        [Display(Name = "Accessibility")]
        public bool ysnAccessibility { get; set; }

        [Display(Name = "Intensity")]
        public Intensity intensity { get; set; }

        [Display(Name = "Equipment")]
        public Equipment equipment { get; set; }

        [Display(Name = "Minutes")]
        public int intTime { get; set; }

        [Display(Name = "Add to Workout")]
        public bool isSelected { get; set; }

        private ExerciseType(MuscleGroup muscleGroup, string strName, int intCaloriesBurned, bool ysnAccessibility, Intensity intensity, Equipment equipment, int intTime)
        {
            this.muscleGroup = muscleGroup;
            this.strName = strName;
            this.intCaloriesBurned = intCaloriesBurned;
            this.ysnAccessibility = ysnAccessibility;
            this.intensity = intensity;
            this.equipment = equipment;
            this.intTime = intTime;
        }

        public static ExerciseType of(MuscleGroup muscleGroup, string strName, int intCaloriesBurned, bool ysnAccessibility, Intensity intensity, Equipment equipment, int intTime)
        {
            return new ExerciseType(muscleGroup, strName, intCaloriesBurned, ysnAccessibility, intensity, equipment, intTime);
        }

        private ExerciseType(int intExerciseTypeID, MuscleGroup muscleGroup, string strName, int intCaloriesBurned, bool ysnAccessibility, Intensity intensity, Equipment equipment, int intTime)
        {
            this.intExerciseTypeID = intExerciseTypeID;
            this.muscleGroup = muscleGroup;
            this.strName = strName;
            this.intCaloriesBurned = intCaloriesBurned;
            this.ysnAccessibility = ysnAccessibility;
            this.intensity = intensity;
            this.equipment = equipment;
            this.intTime = intTime;
        }

        public static ExerciseType of(int intExerciseTypeID, MuscleGroup muscleGroup, string strName, int intCaloriesBurned, bool ysnAccessibility, Intensity intensity, Equipment equipment, int intTime)
        {
            return new ExerciseType(intExerciseTypeID, muscleGroup, strName, intCaloriesBurned, ysnAccessibility, intensity, equipment, intTime);
        }

        public ExerciseType() { }
    }
}
