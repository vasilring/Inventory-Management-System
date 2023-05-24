using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    internal class ShowAllUsersCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        public ShowAllUsersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            //CommandName[ShowAllUsers]

            // Original command form: ShowAllUsers

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("Role", typeof(string));

            var query = this.Repository.Company
                         .SelectMany(x => x.Users)
                         .Select(users => new
                         {
                             users.Username,
                             Role = users.Role == Role.Manager ? "Manager" : "Client"
                         })
                         .OrderBy(user => user.Username);

            foreach (var item in query)
            {
                table.Rows.Add(item.Username, item.Role);
            }

            // Use ConsoleTableExt to display the data in a tabular format
            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine(tableString);

            return sb.ToString();
        }
    }
}