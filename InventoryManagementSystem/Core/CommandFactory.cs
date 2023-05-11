using InventoryManagementSystem.Commands;
using InventoryManagementSystem.Commands.Contracts;
using InventoryManagementSystem.Commands.CreateCommands;
using InventoryManagementSystem.Commands.Enums;
using InventoryManagementSystem.Commands.ShowCommands;
using InventoryManagementSystem.Commands.UserCommands;
using InventoryManagementSystem.Core.Contracts;

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

            return commandType switch
            {
                CommandType.RegisterUser => new RegisterUserCommand(commandParameters, repository),

                CommandType.Login => new LoginCommand(commandParameters, repository),

                CommandType.Logout => new LogoutCommand(repository),

                CommandType.CreateInventory => new CreateInventoryCommand(commandParameters, repository),

                CommandType.CreateCream => new CreateCreamCommand(commandParameters, repository),

                CommandType.CreatePerfume => new CreatePerfumeCommand(commandParameters, repository),

                CommandType.CreateLipstick => new CreateLipstickCommand(commandParameters, repository),

                CommandType.ShowInventoryStock => new ShowInventoryStockCommand(commandParameters, repository),

                CommandType.ShowAllCompanies => new ShowAllCompaniesCommand(repository),

                CommandType.ShowProductById => new ShowProductByIdCommand(commandParameters, repository),

                CommandType.ChangeProductValue => new UpdateProductCommand(commandParameters, repository),

                CommandType.RemoveProduct => new RemoveProductCommand(commandParameters, repository),

                CommandType.RemoveInventory => new RemoveInventoryCommand(commandParameters, repository),


                _ => throw new InvalidOperationException($"Command with name: {command} doesn't exist!"),
            };
        }

        private CommandType ParseCommandType(string value)
        {
            Enum.TryParse(value, true, out CommandType result);

            return result;
        }

        private List<String> ExtractCommandParameters(string[] arguments)
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
