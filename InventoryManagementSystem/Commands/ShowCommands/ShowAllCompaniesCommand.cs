using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using System.Data;
using System.Text;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    public class ShowAllCompaniesCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0; 
        public ShowAllCompaniesCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ShowAllCompanies]

            // Original command form: ShowAllCompanies

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("Company Name", typeof(string));

            var query = this.Repository.Company
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
