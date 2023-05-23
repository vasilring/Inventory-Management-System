using InventoryManagementSystem.Commands;
using InventoryManagementSystem.Commands.Contracts;
using InventoryManagementSystem.Commands.CreateCommands;
using InventoryManagementSystem.Commands.Enums;
using InventoryManagementSystem.Commands.RemoveCommands;
using InventoryManagementSystem.Commands.ShowCommands;
using InventoryManagementSystem.Commands.UserCommands;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {

            string[] arguments = commandLine.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var commandType = ParseCommandType(arguments[0]);
            var command = arguments[0];
            List<string> commandParameters = ExtractCommandParameters(arguments);

            if (this.repository.LoggedUser != null && this.repository.LoggedUser.Role == Role.Client && IsCommandDisabledForClients(commandType)) // Disable some commands if the role is 'Client'
            {
                throw new InvalidUserInputException("Access denied. You are not authorized to execute this command.");
            }
            else if(this.repository.LoggedUser != null && this.repository.LoggedUser.Role == Role.Manager && IsCommandDisabledForManagers(commandType))
            {
                throw new InvalidUserInputException("Access denied. You are not authorized to execute this command.");
            }

            return commandType switch
            {
                CommandType.RegisterUser => new RegisterUserCommand(commandParameters, repository),

                CommandType.Login => new LoginCommand(commandParameters, repository),

                CommandType.Logout => new LogoutCommand(repository),

                CommandType.ChangePassword => new ChangePasswordCommand(commandParameters, repository),

                CommandType.ChangeUsername => new ChangeUsernameCommand(commandParameters, repository),

                CommandType.CreateInventory => new CreateInventoryCommand(commandParameters, repository),

                CommandType.CreateCream => new CreateCreamCommand(commandParameters, repository),

                CommandType.CreatePerfume => new CreatePerfumeCommand(commandParameters, repository),

                CommandType.CreateLipstick => new CreateLipstickCommand(commandParameters, repository),

                CommandType.ShowInventoryStock => new ShowInventoryStockCommand(commandParameters, repository),

                CommandType.ShowAllCompanies => new ShowAllCompaniesCommand(commandParameters, repository),

                CommandType.ShowAllUsers => new ShowAllUsersCommand(commandParameters, repository),

                CommandType.ShowProductById => new ShowProductByIdCommand(commandParameters, repository),

                CommandType.ChangeProductValue => new UpdateProductCommand(commandParameters, repository),

                CommandType.RemoveProduct => new RemoveProductCommand(commandParameters, repository),

                CommandType.RemoveInventory => new RemoveInventoryCommand(commandParameters, repository),

                CommandType.BuyProduct => new BuyProductCommand(commandParameters, repository),

                CommandType.FilterProductsBy => new FilterProductsCommand(commandParameters, repository),

                _ => throw new InvalidOperationException($"Command with name: {command} doesn't exist!"),
            };
        }

        private static bool IsCommandDisabledForClients(CommandType commandType) // If I want to disable more commands, add them here, for the role 'Client'
        {
            return commandType >= CommandType.CreateInventory &&
                   commandType <= CommandType.RemoveInventory;
        }

        private static bool IsCommandDisabledForManagers(CommandType commandType) // If I want to disable more commands, add them here, for the role 'Client'
        {
            return commandType is CommandType.BuyProduct;        
        }

        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType result);

            return result;
        }

        private static List<string> ExtractCommandParameters(string[] arguments)
        {
            List<string> commandParameters = new List<string>();

            for (int i = 1; i < arguments.Length; i++)
            {
                commandParameters.Add(arguments[i]);
            }

            return commandParameters;
        }
    }
}
