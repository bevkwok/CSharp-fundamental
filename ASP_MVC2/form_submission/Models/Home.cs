using System;
using System.ComponentModel.DataAnnotations;
namespace form_submission.Models
{
    public class User
    {
        [Required(ErrorMessage="Required field")]
        [MinLength(4, ErrorMessage="Minimun Length is 4")]
        [Display(Name = "First Name:")]     
        public string FirstName {get;set;}


        [Required(ErrorMessage="Required field")]
        [MinLength(4, ErrorMessage="Minimun Length is 4")]
        public string LastName {get;set;}


        [Required(ErrorMessage="Required field")]
        [Range(0,150)]
        public int Age {get;set;}


        [Required(ErrorMessage="Required field")]
        [EmailAddress]
                public string Email {get;set;}


        [Required(ErrorMessage="Required field")]
        [DataType(DataType.Password)]
        [Compare("Confirm_Password", ErrorMessage = "Password should match up with confirm password")]
        public string Password {get;set;}


        [Required(ErrorMessage="Required field")]
        [DataType(DataType.Password)]
        public string Confirm_Password {get;set;}
    }
}