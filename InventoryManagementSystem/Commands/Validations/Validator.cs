using InventoryManagementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.Validations
{
    public class Validator
    {
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
