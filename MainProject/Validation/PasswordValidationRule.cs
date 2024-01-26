using System.Globalization;
using System.Windows.Controls;

public class PasswordValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string password = value as string;

        // Add your password validation logic here
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
        {
            return new ValidationResult(false, "Password must be at least 8 characters long.");
        }

        return ValidationResult.ValidResult;
    }
}