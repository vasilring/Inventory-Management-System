using InventoryManagementSystem.Exceptions;

namespace InventoryManagementSystem.Core.Validations
{
    public class Helper
    {
        public static void ValidateParameters(IList<string> CommandParameters, int minimumNumberOfArguments)
        {
            if (CommandParameters.Count < minimumNumberOfArguments || CommandParameters.Count > minimumNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {minimumNumberOfArguments}, Received: {CommandParameters.Count}");
            }
        }
    }
}
