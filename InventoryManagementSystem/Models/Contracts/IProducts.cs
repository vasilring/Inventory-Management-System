namespace InventoryManagementSystem.Models.Contracts
{
    internal interface IProducts
    {
         string Name { get; }
         string Brand { get; }
         decimal Price { get; }
    }
}
