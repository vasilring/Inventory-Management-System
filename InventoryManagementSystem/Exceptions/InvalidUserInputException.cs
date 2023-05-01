namespace InventoryManagementSystem.Exceptions
{
    internal class InvalidUserInputException : ApplicationException
    {
        public InvalidUserInputException(string message)
             : base(message)
        {

        }
    }
}
