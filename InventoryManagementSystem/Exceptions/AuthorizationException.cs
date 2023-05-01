namespace InventoryManagementSystem.Exceptions
{
    internal class AuthorizationException : ApplicationException
    {
        public AuthorizationException(string message)
            : base(message)
        {

        }
    }
}
