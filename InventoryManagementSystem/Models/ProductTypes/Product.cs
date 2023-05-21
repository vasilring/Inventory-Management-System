using InventoryManagementSystem.Models.Common;
using InventoryManagementSystem.Models.Contracts;
using System.Text;

namespace InventoryManagementSystem.Models.Product
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private string description;
        private decimal price;
        private int quantity;
        public Product(int id, string name, string brand, string description, decimal price, int quantity)
        {
          this.Id = id;
          this.Name = name;
          this.Brand = brand;
          this.Description = description;
          this.Price = price;
          this.Quantity = quantity;
        }

        public int Id { get; } // ToDo make validations for all properties
        public string Name
        {
            get => this.name;
            private set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public string Brand
        {
            get => this.brand;
            private set
            {
                ValidateBrand(value);
                this.brand = value;
            }
        }

        public string Description
        {
            get => this.description;
            private set
            {
                ValidateDescription(value);
                this.description = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                ValidatePrice(value);
                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            private set
            {
                ValidateQuantity(value);
                this.quantity = value;
            }
        }

        public void SetName(string newName)
        {
            ValidateName(newName);
            this.Name = newName;
        }

        public void SetPrice(decimal newPrice)
        {
            ValidatePrice(newPrice);
            this.Price = newPrice;
        }

        public void SetQuantity(int newQuantity)
        {
            ValidateQuantity(newQuantity);
            this.Quantity = newQuantity;
        }

        public void ChangeQuantity(int newQuantity)
        {
            this.Quantity -= newQuantity;
        }

        #region Validations
        public void ValidateName(string name)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(name, message);

            var min = Constants.NameMinLength;
            var max = Constants.NameMaxLength;
            message = Constants.InvalidNameError;
            Validate.ValidateLengthRange(name, min, max, message);
        }

        public void ValidateBrand(string brand)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(brand, message);

            var min = Constants.BrandMinLength;
            var max = Constants.BrandMaxLength;
            message = Constants.InvalidBrandError;
            Validate.ValidateLengthRange(brand, min, max, message);
        }

        public void ValidateDescription(string description)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(description, message);

            var min = Constants.DescriptionMinLength;
            var max = Constants.DescriptionMaxLength;
            message = Constants.InvalidDescriptionError;
            Validate.ValidateLengthRange(description, min, max, message);
        }

        public void ValidatePrice(decimal price)
        {
            var message = $"{GetType().Name} {Constants.InvalidPriceError}";
            Validate.ValidateNonNegativeDecimal(price, message);
        }

        public void ValidateQuantity(int quantity)
        {
            var message = $"{GetType().Name} {Constants.InvalidQuantityError}";
            Validate.ValidateNonNegativeInt(quantity, message);
        }
        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product: '{this.GetType().Name}' with Id: '{this.Id}'");
            sb.AppendLine($"Name: '{this.Name}'");
            sb.AppendLine($"Brand: '{this.Brand}'");
            sb.AppendLine($"Description: '{this.Description}'");
            sb.AppendLine($"Price: '{this.Price}'");
            sb.AppendLine($"Quantity: '{this.Quantity}'");

            return sb.ToString().TrimEnd();
        }
    }
}
