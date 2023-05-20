using InventoryManagementSystem.Commands.Validations;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;

namespace InventoryManagementSystem.Commands.UserCommands
{
   public class ChangePasswordCommand : BaseCommand
   {
      public const int ExpectedNumberOfArguments = 2;

      public ChangePasswordCommand(List<string> parameters, IRepository repository)
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
           // CommandName[ChangePassword], Username [vasilring], New password [Vasil]

           // ChangePassword, vasilring, h867#$%HCAebYwi

           // Original command form: Register
           // Parameters:
           //  [0] - username
           //  [1] - password

           var username = this.Repository.GetUser(this.CommandParameters[0]);
           var newPassword = Validator.ValidatePassword(this.CommandParameters[1]);

          this.Repository.ChangePassword(username, newPassword);

          return $"Password of user: {username.Username} was changed to {newPassword} :D";
      }
   }
}

