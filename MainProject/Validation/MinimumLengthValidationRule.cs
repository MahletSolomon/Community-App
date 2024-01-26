using System.Globalization;
using System.Windows.Controls;

public class MinimumLengthValidationRule : ValidationRule
{
    public int MinimumLength { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is string password && password.Length < MinimumLength)
        {
            return new ValidationResult(false, $"Password must have a minimum length of {MinimumLength} characters.");
        }

        return ValidationResult.ValidResult;
    }
}