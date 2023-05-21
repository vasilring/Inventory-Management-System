using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;


namespace InventoryManagementSystem.Commands.UserCommands
{
    public class RegisterUserCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;

        public RegisterUserCommand(List<string> parameters, IRepository repository)
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

            //Input:
            // CommandName[RegisterUser], Username [vasilring], Name [Vasil], Last name [Lyubenov], Password [abcdefg1], Company name [SkyLife], Role in the company [Manager]

            // RegisterUser, vasilring, Vasil, Lyubenov, abcdefg1, SkyLife, Manager

            // Original command form: Register
            // Parameters:
            //  [0] - username
            //  [1] - name
            //  [2] - last name
            //  [3] - password
            //  [4] - company name
            //  [5] - role (if there is no role, the default role will be "None")

            string username = this.CommandParameters[0];
            string firstName = this.CommandParameters[1];
            string lastName = this.CommandParameters[2];
            string password = this.CommandParameters[3];
            string companyName = this.CommandParameters[4];

            Role role = Role.None;

            if (this.CommandParameters.Count == 6) // ToDo Fix the roles, there cannot be Role: "NoNe" :D
            {
                role = ParseRoleParameter(CommandParameters[5], "userRole");
            }

            return RegisterUser(username, firstName, lastName, password, companyName, role);
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, string companyName, Role role)
        {
            if (this.Repository.LoggedUser != null)
            {
                string errorMessage = string.Format(UserAlreadyLoggedIn, this.Repository.LoggedUser.Username);

                throw new AuthorizationException(errorMessage);
            }


            IUser user = Repository.CreateUserAndCompany(username, firstName, lastName, password, companyName, role);
            this.Repository.AddUser(user, companyName);
            this.Repository.LogUser(user);

            return $"User with username \"{username}\", name \"{firstName}\", and role \"{role}\" has been successfully registered. We have also created a company named \"{companyName}\" for this user. ";
        }
    }
}
