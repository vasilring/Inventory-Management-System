namespace InventoryManagementSystem.Commands.Enums
{
    public enum CommandType
    {
        RegisterUser = 1,

        Login = 2,

        Logout = 3,

        // These commands cannot be used from clients 

        CreateInventory = 4,

        CreateCream = 5,

        CreatePerfume = 6,

        CreateLipstick = 7,

        ChangeProductValue = 8,

        RemoveProduct = 9,

        ShowAllUsers = 10,

        RemoveInventory = 11,

        // These commands can be used from clients

        ShowInventoryStock = 12,

        ShowAllCompanies = 13,

        ShowProductById = 14,

        ChangePassword = 15,

        ChangeUsername = 16,

        BuyProduct = 17,

        FilterProductsBy = 18,
    }
}
