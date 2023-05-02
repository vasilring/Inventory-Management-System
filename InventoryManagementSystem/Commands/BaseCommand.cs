using InventoryManagementSystem.Commands.Contracts;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models.Enums;
using System.Globalization;

namespace InventoryManagementSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected int count = 1;
        protected const string UserAlreadyLoggedIn = "User {0} is logged in! Please log out first!";
        private const string LoginRequiredError = "This command requires login first."; //ToDo use constants maybe?
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }

        public string Execute()
        {
            if (this.RequireLogin && this.Repository.LoggedUser == null)
            {
                throw new AuthorizationException(LoginRequiredError);
            }
            return this.ExecuteCommand();
        }
        protected abstract string ExecuteCommand();


        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected abstract bool RequireLogin { get; }

        //Parse method for int and return value
        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            throw new ArgumentException($"Invalid value for {parameterName}. Should be a valid int type.");
        }

        protected decimal ParseDecimalParameter(string value, string parameterName)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be a real number.");
        }

        protected bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either true or false.");
        }       //ToDo check if i need this later

        protected Role ParseRoleParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out Role result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either Normal, VIP or Admin.");
        }
    }
}
