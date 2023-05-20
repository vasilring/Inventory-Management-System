using InventoryManagementSystem.Models.Contracts;
using System.Text;

namespace InventoryManagementSystem.Models.Product
{
    public abstract class Products : IProducts
    {
        public Products(int id, string name, string brand, string description, decimal price, int quantity)
        {
          this.Id = id;
          this.Name = name;
          this.Brand = brand;
          this.Description = description;
          this.Price = price;
          this.Quantity = quantity;
        }

        public int Id { get; } // ToDo make validations for all properties
        public string Name { get; private set; }
        public string Brand { get;  private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

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

        public void SetName(string newPassword) // ToDo maybe validate them if needed?
        {
            this.Name = newPassword;
        }

        public void SetPrice(decimal newPrice)
        {
            this.Price = newPrice;
        }

        public void SetQuantity(int newQuantity)
        {
            this.Quantity = newQuantity;
        }
    }
}
