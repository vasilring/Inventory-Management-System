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
        public Products(int id, string name, string brand, decimal price, int quantity)
        {
          this.Id = id;
          this.Name = name;
          this.Brand = brand;
          this.Price = price;
          this.Quantity = quantity;
        }

        public int Id { get; set; } // ToDo make validations for all properties
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product: '{this.GetType().Name}' with Id: '{this.Id}'");
            sb.AppendLine($"Name: '{this.Name}'");
            sb.AppendLine($"Brand: '{this.Brand}'");
            sb.AppendLine($"Price: '{this.Price}'");
            sb.AppendLine($"Quantity: '{this.Quantity}'");

            return sb.ToString().TrimEnd();
        }

    }
}
