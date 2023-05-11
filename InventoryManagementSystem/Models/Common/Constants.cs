using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Common
{
    public static class Constants
    {
        public const string DateFormat = "yyyyMMdd|HH:mm:ss.ffff";

        public const int ProductMinLength = 5;
        public const int ProductMaxLength = 25;
        public static string InvalidProductNameError = $"Product name must be between {ProductMinLength} and {ProductMaxLength} characters long!";

        public const int InventoryMinLength = 3;
        public const int InventoryMaxLength = 15;
        public static string InvalidInventoryNameError = $"Inventory name must be between {InventoryMinLength} and {InventoryMaxLength} characters long!";

        public const int UserMinLength = 5;
        public const int UserMaxLength = 15;
        public static string InvalidUsernameError = $"Username must be between {UserMinLength} and {UserMaxLength} characters long!";

        public const int CompanyMinLength = 3;
        public const int CompanyMaxLength = 15;
        public static string InvalidCompanyNameError = $"Company name must be between {CompanyMinLength} and {CompanyMaxLength} characters long!";

        public const int ProductDescriptionMinLength = 10;
        public const int ProductDescriptionMaxLength = 500;
        public static string InvalidProductDescriptionError = $"Product description must be between {ProductDescriptionMinLength} and {ProductDescriptionMaxLength} characters long!";

        public const string NullOrEmptyMessage = "name cannot be null or empty!";

    }
}
