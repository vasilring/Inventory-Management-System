using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Product
{
    public class Cream : Products, ICream
    {
        public Cream(int id, string name, string brand, decimal price, int quantity) : base(id, name, brand, price, quantity)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
