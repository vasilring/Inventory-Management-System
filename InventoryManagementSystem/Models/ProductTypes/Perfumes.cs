using InventoryManagementSystem.Models.Contracts;

namespace InventoryManagementSystem.Models.Product
{
    public class Perfumes : Product, IPerfumes
    {
        public Perfumes(int id, string name, string brand, string description, decimal price, int quantity) : base(id, name, brand, description, price, quantity)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
