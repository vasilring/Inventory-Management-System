using InventoryManagementSystem.Exceptions;

namespace InventoryManagementSystem.Models.Common
{
    public class Validate
    {
        // Validations for Length, Null

        public static void ValidateLengthRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNotNullOrEmpty(string value, string message)
        {
            _ = value ?? throw new ArgumentNullException(message);
        }

        public static string ValidatePassword(string password)
        {
            int lowercase = Math.Max(0, 3 - password.Count(c => c >= 'a' && c <= 'z'));
            int uppercase = Math.Max(0, 3 - password.Count(c => c >= 'A' && c <= 'Z'));
            int digit = Math.Max(0, 3 - password.Count(c => c >= '0' && c <= '9'));
            int special = Math.Max(0, 3 - password.Count("!@#$%^&*()_+-=><?".Contains));
            int length = Math.Max(0, 15 - password.Length);

            if (lowercase > 0 || uppercase > 0 || digit > 0 || special > 0 || length > 0)
            {
                throw new InvalidUserInputException("Password must be 15 or more characters and must contain at least 4 special symbols, lower letters, upper letters, and numbers.");
            }

            return password;
        }
    }
}
