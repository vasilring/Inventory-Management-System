using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.UserCommands
{
    public class LogoutCommand : BaseCommand
    {
        //Input:
        // CommandName[Logout]
        // You will be loged out of the system and wont be able to use the commands
        public LogoutCommand(IRepository repository)
            : base(repository)
        {
        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            this.Repository.LogOutUser();
            return "You logged out!";
        }
    }
}
