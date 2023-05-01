using InventoryManagementSystem.Commands.Contracts;

namespace InventoryManagementSystem.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
