using System;
using System.ComponentModel.DataAnnotations;
namespace Chefs_n_dishes.Models
{
    public class Dish
    {
        [Key]
        
        public int DishId {get; set;}
        
        [Required]
        [MinLength(2)]
        [Display(Name = "Name of Dish")]
        public string Name {get; set;}

        [Required]
        [Range(0,10000)]
        [Display(Name = "# of Calories")]
        public int? Calories {get; set;}

        [Required]
        [Range(1,5)]
        [Display(Name = "Tastiness")]
        public int? Tastiness {get; set;}

        [Required]
        [Display(Name = "Description")]
        public string Description {get; set;}

        public int ChefId {get; set;}
        public Chef CookedBy {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}