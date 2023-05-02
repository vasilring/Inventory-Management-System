using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    public class RegisterUserCommand : BaseCommand
    {
        public RegisterUserCommand(List<string> parameters, IRepository repository)
           : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return false; }
        }

        protected override string ExecuteCommand()
        {
            // RegisterUser, vasilring, Vasil, Lyubenov, abcdefg1, SkyLife, Manager


            if (this.CommandParameters.Count < 5) // ToDo use validations
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 5, Received: {this.CommandParameters.Count}");
            }

            string username = this.CommandParameters[0];
            string firstName = this.CommandParameters[1];
            string lastName = this.CommandParameters[2];
            string password = this.CommandParameters[3];
            string companyName = this.CommandParameters[4];

            Role role = Role.None;
            if (this.CommandParameters.Count == 6)
            {
                role = this.ParseRoleParameter(this.CommandParameters[5], "userRole");
            }

            return this.RegisterUser(username, firstName, lastName, password, companyName, role);
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, string companyName, Role role)
        {
            if (this.Repository.LoggedUser != null)
            {
                string errorMessage = string.Format(BaseCommand.UserAlreadyLoggedIn, this.Repository.LoggedUser.Username);

                throw new AuthorizationException(errorMessage);
            }
            

            IUsers user = this.Repository.CreateUser(username, firstName, lastName, password, companyName, role);
            this.Repository.AddUser(user, companyName);
            this.Repository.LogUser(user);
            return $"User with username:{username},name: {firstName} and role: {role} created registered succsesfully and created company with name: {companyName} ";
        }
    }
}
