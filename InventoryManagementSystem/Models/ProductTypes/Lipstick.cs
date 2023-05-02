using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Product
{
    public class Lipstick : Products, ILipstick
    {
        public Lipstick(string name, string brand, decimal price, int quantity) : base(name, brand, price, quantity)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
