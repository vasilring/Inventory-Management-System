namespace InventoryManagementSystem.Models.Contracts
{
    public interface IInventory
    {
        string Name { get; }
        IList<IProducts> Products { get; }
        void AddProduct(IProducts product);
        void RemoveProduct(IProducts product);
    }
}
