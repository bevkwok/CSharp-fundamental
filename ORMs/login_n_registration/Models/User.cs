using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace login_n_registration.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        
        [Required]
        [MinLength(2)]
        public string FirstName {get; set;}
        
        [Required]
        [MinLength(2)]
        public string LastName {get; set;}
        
        [Required]
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

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;
    }
}