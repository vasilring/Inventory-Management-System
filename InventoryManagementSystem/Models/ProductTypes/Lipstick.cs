using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Product
{
    internal class Lipstick : Products
    {
        public Lipstick(string name, string brand, decimal price) : base(name, brand, price)
        {
        }
    }
}
