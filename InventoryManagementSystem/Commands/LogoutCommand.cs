using InventoryManagementSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    public class LogoutCommand : BaseCommand
    {
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
