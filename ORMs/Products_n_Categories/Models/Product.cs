using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Products_n_Categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Name")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Price")]
        public double Price {get; set;}

        [Display(Name = "Descriptions")]
        public string Descriptions {get; set;}

        public List<Association> belongedCategory {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}