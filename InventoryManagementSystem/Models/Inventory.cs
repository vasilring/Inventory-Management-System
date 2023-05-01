using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Inventory : IInventory
    {
        private readonly IList<IProducts> products = new List<IProducts>();
        public Inventory(string name) 
        {
            this.Name = name;
        }
        public string Name { get; }

        public IList<IProducts> Products => new List<IProducts>(this.products);

        public void AddProduct(IProducts product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(IProducts product)
        {
            throw new NotImplementedException();
        }
    }
}
