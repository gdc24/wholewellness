using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace wholewellness.Models
{
    public class HealthierOptions
    {
        [Key]
        [Display(Name = "Original")]
        public FoodItem original;

        [Display(Name = "Alternatives")]
        public List<FoodItem> alternatives { get; set; }

        public HealthierOptions(FoodItem original, List<FoodItem> alternatives) 
        {
            this.original = original;
            this.alternatives = alternatives;
        }
    }
}
