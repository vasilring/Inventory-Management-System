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
    internal class ShowAllCompaniesCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = -1; // ToDo add validations for arguments
        public ShowAllCompaniesCommand(IRepository repository)
            : base(repository)
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
            //CommandName[ShowAllCompanies]

            // Original command form: ShowAllCompanies

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("Company Name", typeof(string));

            var query = this.Repository.Companies
                         .Select(company => new { company.Name })
                         .OrderBy(company => company.Name);
                  
            foreach (var item in query)
            {
                table.Rows.Add(item.Name);
            }

            // Use ConsoleTableExt to display the data in a tabular format
            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine(tableString);

            return sb.ToString();

        }
    }
}
