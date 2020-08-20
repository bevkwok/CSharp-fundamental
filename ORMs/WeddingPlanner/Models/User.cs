using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        
        [Required(ErrorMessage = "First name is required")]
        [MinLength(2)]
        public string FirstName {get; set;}
        
        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2)]
        public string LastName {get; set;}
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must have at least 8 characters.")]
        public string Password {get; set;}

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get; set;}
        public List<Wedding> PlannedWedding {get; set;}
        public List<Guest> AttendingWedding { get; set; }
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;
    }
}