using InventoryManagementSystem.Models.Common;
using InventoryManagementSystem.Models.Contracts;

namespace InventoryManagementSystem.Models
{
    public class Inventory : IInventory
    {
        private string name;
        private readonly IList<IProduct> products = new List<IProduct>();
        public Inventory(string name)
        {
            this.Name = name;
        }
        public string Name 
        { 
            get => this.name;

            private set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public IList<IProduct> Products => new List<IProduct>(this.products);

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        private void ValidateName(string name)
        {
            var message = $"{GetType().Name} {Constants.NullOrEmptyMessage}";
            Validate.ValidateNotNullOrEmpty(name, message);

            var min = Constants.InventoryMinLength;
            var max = Constants.InventoryMaxLength;
            message = Constants.InvalidInventoryNameError;
            Validate.ValidateLengthRange(name, min, max, message);
        }

        public override string ToString()
        {
            return $"Inventory with name: {this.Name} was created";
        }
    }
}
