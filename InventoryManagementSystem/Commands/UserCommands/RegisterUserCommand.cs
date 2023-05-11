﻿using InventoryManagementSystem.Commands.Validations;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            if (CommandParameters.Count < 5) // ToDo use validations
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 5, Received: {CommandParameters.Count}");
            }

            string username = CommandParameters[0];
            string firstName = CommandParameters[1];
            string lastName = CommandParameters[2];
            string password = Validator.ValidatePassword(this.CommandParameters[3]);
            string companyName = CommandParameters[4];


            Role role = Role.None;

            if (CommandParameters.Count == 6) // ToDo Fix the roles, there cannot be Role: "NoNe" :D
            {
                role = ParseRoleParameter(CommandParameters[5], "userRole");
            }

            return RegisterUser(username, firstName, lastName, password, companyName, role);
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, string companyName, Role role)
        {
            if (Repository.LoggedUser != null)
            {
                string errorMessage = string.Format(UserAlreadyLoggedIn, Repository.LoggedUser.Username);

                throw new AuthorizationException(errorMessage);
            }


            IUsers user = Repository.CreateUserAndCompany(username, firstName, lastName, password, companyName, role);
            Repository.AddUser(user, companyName);
            Repository.LogUser(user);
            return $"User with username:{username},name: {firstName} and role: {role} created registered succsesfully and created company with name: {companyName} ";
        }
    }
}
