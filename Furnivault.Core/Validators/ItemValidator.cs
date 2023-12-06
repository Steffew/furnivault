using System.ComponentModel.DataAnnotations;

namespace Furnivault.Core.Validators
{
    public class ItemValidator
    {
        public bool ValidateString(string parameterName, string value, int minLength, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{parameterName} cannot be null or whitespace.");
            }

            if (value.Length < minLength || value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} cannot be less than {minLength} or more than {maxLength}. Current value is {value.Length}.");
            }

            return true;
        }

        public bool ValidateString(string parameterName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{parameterName} cannot be null or whitespace.");
            }

            return true;
        }
    }
}