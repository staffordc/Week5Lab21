using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Week5Lab21CoffeeShop.Validators
{
    public class CustomeEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value.ToString();
            var emailRegex = new Regex("\\w+@\\w+.\\w");

            var isValidEmail = emailRegex.IsMatch(email);
            if (isValidEmail)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("This is an invalid email address");
            }
        }

    }
}