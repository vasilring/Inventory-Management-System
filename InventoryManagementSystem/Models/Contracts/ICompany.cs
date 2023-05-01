namespace InventoryManagementSystem.Models.Contracts
{
    internal interface ICompany
    {
        public string Name { get; }
        IList<Inventory> Inventory { get; }
        IList<Users> Users { get; }
        public void CreateInventory(Inventory inventory);
        public void RemoveInventory(Inventory inventory);
        void AddMember(Users member);
        void RemoveMember(Users member);
    }
}
