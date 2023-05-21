namespace InventoryManagementSystem.Models.Contracts
{
    public interface IInventory
    {
        string Name { get; }
        IList<IProduct> Products { get; }
        void AddProduct(IProduct product);
        void RemoveProduct(IProduct product);
    }
}
