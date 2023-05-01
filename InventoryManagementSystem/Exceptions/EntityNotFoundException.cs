namespace InventoryManagementSystem.Exceptions
{
    internal class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {

        }
    }
}
