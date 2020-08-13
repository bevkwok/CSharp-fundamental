using System.ComponentModel.DataAnnotations;
using System;
namespace cru.Models
{
    public class Dishes
    {
        [Key]
        public int DishId {get; set;}

        [Required]
        [Display(Name = "Name of Dish")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Chef's Name")]
        public string Chef {get; set;}

        [Required]
        [Display(Name = "Tastiness")]
        public int Tastiness {get; set;}

        [Required]
        [Range(0,10000)]
        [Display(Name = "# of Calories")]
        public int Calories {get; set;}

        [Required]
        [Display(Name = "Description")]
        public string Description {get; set;}

        public DateTime CreateAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;
    }
}