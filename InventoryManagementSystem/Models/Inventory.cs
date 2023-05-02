using InventoryManagementSystem.Models.Contracts;

namespace InventoryManagementSystem.Models
{
    public class Inventory : IInventory
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
            this.products.Add(product);
        }

        public void RemoveProduct(IProducts product)
        {
            this.products.Remove(product);
        }

        public override string ToString()
        {
            return $"Inventory with name: {this.Name} was created";
        }
    }
}
