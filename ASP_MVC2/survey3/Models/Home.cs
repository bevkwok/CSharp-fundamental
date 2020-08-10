using System.ComponentModel.DataAnnotations;
namespace survey2.Models

{
    public class Ninja
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Name:")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Location:")]
        public string Location {get;set;}

        [Required]
        [Display(Name = "Language:")]
        public string Language {get;set;}

        [MaxLength(30)]
        [Display(Name = "Comment:")]
        public string Comment {get;set;}

    }
}