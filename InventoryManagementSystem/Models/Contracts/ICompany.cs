namespace InventoryManagementSystem.Models.Contracts
{
    public interface ICompany
    {
        public string Name { get; }
        IList<IInventory> Inventory { get; }
        IList<IUsers> Users { get; }
        public void CreateInventory(IInventory inventory);
        public void RemoveInventory(IInventory inventory);
        void AddMember(IUsers member);
        void RemoveMember(IUsers member);
    }
}
