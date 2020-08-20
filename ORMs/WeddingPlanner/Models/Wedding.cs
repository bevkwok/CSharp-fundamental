using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder One")]
        public string WedderOne {get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get;set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder Address")]
        public string Address { get;set; }

        public int UserId { get; set; }
        public User Planner { get; set; }
        
        public List<Guest> Guests { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}