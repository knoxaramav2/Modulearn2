using System.ComponentModel.DataAnnotations;

namespace Modulearn2A.Utility
{
    public class NonEmailAttribute : ValidationAttribute
    {
        private string emailStr;

        public string GetErrorMessage() => "Value cannot be an email address.";

        public NonEmailAttribute(string email)
        {
            emailStr = email;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext ctx
            )
        {

            if (!Format.IsEmailFormat(emailStr))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
