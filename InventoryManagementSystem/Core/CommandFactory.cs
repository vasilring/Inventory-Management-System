using InventoryManagementSystem.Commands.Contracts;
using InventoryManagementSystem.Commands.Enums;
using InventoryManagementSystem.Core.Contracts;
using System.Xml.Linq;

namespace InventoryManagementSystem.Core
{
    internal class CommandFactory : ICommandFactory
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
                //CommandType.CreateCompany => new (Command Name) (commandParameters, repository),

                //CommandType.CreateManager => new (Command Name) (commandParameters, repository),

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
