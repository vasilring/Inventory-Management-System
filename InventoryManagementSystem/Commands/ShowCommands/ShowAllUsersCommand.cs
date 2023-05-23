using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
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
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);
        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            //Input:
            //CommandName[ShowAllUsers]

            // Original command form: ShowAllUsers

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("User Name", typeof(string));

            var query = this.Repository.Company
                         .SelectMany(x =>x.Users)
                         .OrderBy(company => company.Username);

            foreach (var item in query)
            {
                table.Rows.Add(item.Username);
            }

            // Use ConsoleTableExt to display the data in a tabular format
            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine(tableString);

            return sb.ToString();
        }
    }
}