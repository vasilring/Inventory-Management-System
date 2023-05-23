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

        //--------------------------------------- Product Const----------------------------------------------

        public const int ProductMinLength = 5;
        public const int ProductMaxLength = 45;
        public static string InvalidProductNameError = $"Product name must be between {ProductMinLength} and {ProductMaxLength} characters long!";

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 500;
        public static string InvalidDescriptionError = $"Product description must be between {DescriptionMinLength} and {DescriptionMaxLength} characters long!";

        public const int BrandMinLength = 3;
        public const int BrandMaxLength = 25;
        public static string InvalidBrandError = $"Brand must be between {BrandMinLength} and {BrandMaxLength} characters long!";

        public const int NameMinLength = 5;
        public const int NameMaxLength = 45;
        public static string InvalidNameError = $"Product name must be between {NameMinLength} and {NameMaxLength} characters long!";

        public static string InvalidPriceError = "Price cannot be negative!";

        public static string InvalidQuantityError = "Quantity cannot be negative!";

        //--------------------------------------- Inventory Const----------------------------------------------

        public const int InventoryMinLength = 3;
        public const int InventoryMaxLength = 15;
        public static string InvalidInventoryNameError = $"Inventory name must be between {InventoryMinLength} and {InventoryMaxLength} characters long!";

        //--------------------------------------- User Const----------------------------------------------

        public const int UserMinLength = 5;
        public const int UserMaxLength = 15;
        public static string InvalidUsernameError = $"Username must be between {UserMinLength} and {UserMaxLength} characters long!";

        public const int FirstNameMinLength = 3;
        public const int FirstNameMaxLength = 10;
        public static string InvalidFirstNameError = $"First name must be between {FirstNameMinLength} and {FirstNameMaxLength} characters long!";

        public const int LastNameMinLength = 3;
        public const int LastNameMaxLength = 15;
        public static string InvalidLastNameError = $"Last name must be between {LastNameMinLength} and {LastNameMaxLength} characters long!";

        //--------------------------------------- Company Const----------------------------------------------

        public const int CompanyMinLength = 3;
        public const int CompanyMaxLength = 15;
        public static string InvalidCompanyNameError = $"Company name must be between {CompanyMinLength} and {CompanyMaxLength} characters long!";

        public const string NullOrEmptyMessage = "Name cannot be null or empty!";

    }
}
