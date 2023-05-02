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
        public Products(string name, string brand, decimal price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

    }
}
