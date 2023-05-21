using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.UserCommands
{
    public class LoginCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public LoginCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);
        }

        protected override bool RequireLogin
        {
            get { return false; }
        }

        //Login, vasilring, abcdefg1

        //Input:
        // CommandName[Login], Username [vasilring], Password [abcdefg1]

        //Login, vasilring, abcdefg1

        // Original command form: Login
        // Parameters:
        //  [0] - username
        //  [1] - password

        protected override string ExecuteCommand()
        {
            string username = CommandParameters[0];
            string password = CommandParameters[1];

            return Login(username, password);
        }

        private string Login(string username, string password)
        {
            if (Repository.LoggedUser != null)
            {
                string errorMessage = string.Format(UserAlreadyLoggedIn, Repository.LoggedUser.Username);

                throw new AuthorizationException(errorMessage);
            }

            var user = Repository.GetUser(username);
            if (user.Password != password)
            {
                throw new AuthorizationException("Wrong username or password!");
            }

            Repository.LogUser(user);

            return $"User {username} successfully logged in!";
        }
    }
}
