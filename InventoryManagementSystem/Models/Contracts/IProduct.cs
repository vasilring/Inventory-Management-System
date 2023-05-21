namespace InventoryManagementSystem.Models.Contracts
{
    public interface IProduct 
    {
         int Id { get; }
         string Name { get; }
         string Brand { get; }
         string Description { get; }
         decimal Price { get; }
         int Quantity { get; }
    }
}
