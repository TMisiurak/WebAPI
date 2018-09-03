using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Helpers.CustomAttributes
{
    // Attribute that checks if the entered date is not prior 1900
	public class ValidDateAttribute : ValidationAttribute
    {
        DateTime minDate = new DateTime(1900, 01, 01);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);
            if (date < minDate)
            {
                return new ValidationResult("Date cannot be less than 01.01.1900");
            }
            if (date > DateTime.Now)
            {
                return new ValidationResult("Date cannot be greater than the current date");
            }

            return ValidationResult.Success;
        }
    }
}
