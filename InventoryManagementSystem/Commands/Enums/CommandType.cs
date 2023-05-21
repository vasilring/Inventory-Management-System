namespace InventoryManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        RegisterUser = 1,

        Login = 2,

        Logout = 3,

        // These commands cannot be used from clients 

        CreateInventory = 4,

        CreateCream =5,

        CreatePerfume = 6,

        CreateLipstick = 7,

        ChangeProductValue = 8,

        RemoveProduct = 9,

        RemoveInventory = 10,

        // These commands can be used from clients

        ShowInventoryStock = 11,

        ShowAllCompanies = 12,

        ShowProductById = 13,

        ChangePassword = 14,

        ChangeUsername = 15,
    }
}
