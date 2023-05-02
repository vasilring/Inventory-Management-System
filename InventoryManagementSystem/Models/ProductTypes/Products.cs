using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Product
{
    public abstract class Products : IProducts
    {
        public Products(string name, string brand, decimal price, int quantity)
        {
          this.Name = name;
          this.Brand = brand;
          this.Price = price;
          this.Quantity = quantity;
        }

        public string Name { get; }
        public string Brand { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product: {this.GetType().Name}");
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Brand: {this.Brand}");
            sb.AppendLine($"Price: {this.Price}");
            sb.AppendLine($"Quantity: {this.Quantity}");

            return sb.ToString().TrimEnd();
        }

    }
}
