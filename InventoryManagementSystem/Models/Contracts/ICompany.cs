namespace InventoryManagementSystem.Models.Contracts
{
    public interface ICompany
    {
        string Name { get; }
        IList<IInventory> Inventory { get; }
        IList<IUser> Users { get; }
        void CreateInventory(IInventory inventory);
        void RemoveInventory(IInventory inventory);
        void AddMember(IUser member);
        void RemoveMember(IUser member);
    }
}
