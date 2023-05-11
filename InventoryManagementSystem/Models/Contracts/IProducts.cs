namespace InventoryManagementSystem.Models.Contracts
{
    public interface IProducts 
    {
         int Id { get; }
         string Name { get; }
         string Brand { get; }
         string Description { get; }
         decimal Price { get; }
         int Quantity { get; }
    }
}
