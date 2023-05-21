namespace InventoryManagementSystem.Models.Contracts
{
    public interface ICompany
    {
        public string Name { get; }
        IList<IInventory> Inventory { get; }
        IList<IUser> Users { get; }
        public void CreateInventory(IInventory inventory);
        public void RemoveInventory(IInventory inventory);
        void AddMember(IUser member);
        void RemoveMember(IUser member);
    }
}
