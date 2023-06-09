﻿using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;

namespace InventoryManagementSystem.Commands.UserCommands
{
   public class ChangePasswordCommand : BaseCommand
   {
      public const int ExpectedNumberOfArguments = 2;

      public ChangePasswordCommand(List<string> parameters, IRepository repository)
         : base(parameters, repository)
      {

      }

      protected override bool RequireLogin
      {
          get { return false; }
      }

      protected override string ExecuteCommand()
      {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            // CommandName[ChangePassword], Username [vasilring], New password [Vasil]

            // ChangePassword, vasilring, h867#$%HCAebYwi

            // Original command form: Register
            // Parameters:
            //  [0] - username
            //  [1] - password

            var username = this.Repository.GetUser(this.CommandParameters[0]);
           var newPassword = this.CommandParameters[1];

           this.Repository.ChangePassword(username, newPassword);

            return $"The password for user \"{username.Username}\" has been successfully changed to \"{newPassword}\".";

        }
    }
}

