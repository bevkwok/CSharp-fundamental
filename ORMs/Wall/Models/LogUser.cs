using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wall.Models
{
    public class LogUser
    {
        [Display(Name="Email")]
        [Required(ErrorMessage = "Email is required")]
        public string LogEmail { get; set; }

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LogPassword {get; set;}
    }
}