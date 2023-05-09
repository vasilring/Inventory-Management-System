namespace InventoryManagementSystem.Models.Contracts
{
    public interface IProducts
    {
         string Name { get; }
         string Brand { get; }
         decimal Price { get; }
         int Quantity { get; }
    }
}
