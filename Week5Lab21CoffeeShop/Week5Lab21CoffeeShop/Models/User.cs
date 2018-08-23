using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week5Lab21CoffeeShop.Validators;

namespace Week5Lab21CoffeeShop.Models
{
    public class UserFormData
    {

        [MinLength(2, ErrorMessage ="Do you have a longer version of that name?")]
        [Required]
        [MaxLength(50, ErrorMessage ="time to lawyer up against ur parents")]
        [Display(Name = ("First Name"))]
        [RegularExpression("\\D+", ErrorMessage = "No numblos plz")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "No initals plz")]
        [Required]
        [MaxLength(50, ErrorMessage ="time to lawyer up against ur parents")]
        [Display(Name = ("Last Name"))]
        [RegularExpression("\\D+",ErrorMessage = "No numblos plz")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "please try again")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "more please")]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare("Password", ErrorMessage ="lol, try again.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string FavoriteCoffee { get; set; }
    }

}