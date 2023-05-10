using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    internal class ShowProductByIdCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1; // ToDo add validations for arguments
        public ShowProductByIdCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            //Input:
            //CommandName[ShowProductById], Product id[1]

            // Original command form: ShowProductById
            // Parameters:
            //  [0] - product id

            var id = ParseIntParameter(this.CommandParameters[0], "Id");

            var query = this.Repository.ShowProductById(id);

            return query.ToString();

        }
    }
}
