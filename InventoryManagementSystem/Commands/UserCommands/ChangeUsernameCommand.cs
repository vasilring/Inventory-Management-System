using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;

namespace InventoryManagementSystem.Commands.UserCommands
{
    public class ChangeUsernameCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public ChangeUsernameCommand(List<string> parameters, IRepository repository)
           : base(parameters, repository)
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);
        }

        protected override bool RequireLogin
        {
            get { return false; }
        }

        protected override string ExecuteCommand()
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            // CommandName[ChangeUsername], Username [vasilring], New username [vasilrig]

            // ChangeUsername, vasilring, vasilrig

            // Original command form: Register
            // Parameters:
            //  [0] - Old username
            //  [1] - New username

            var username = this.Repository.GetUser(this.CommandParameters[0]);
            var newUsername = this.CommandParameters[1];

            this.Repository.ChangeUsername(username, newUsername);

            return $"Username changed to {newUsername} successfully";
        }
    }
}

