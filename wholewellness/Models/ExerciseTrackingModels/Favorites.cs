using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models.ExerciseTrackingModels
{
    public class Favorites
    {
        [Key]

        [Display(Name = "Favorites")]
        public List<ExerciseType> favorites { get; set; }


        public Favorites(List<ExerciseType> favorites)
        {
            this.favorites = favorites;
        }

        public Favorites of(List<ExerciseType> favorities)
        {
            return new Favorites(favorites);
        }
    }
}
