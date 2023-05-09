using InventoryManagementSystem.Core.Contracts;
using System.Data;
using System.Text;
using ConsoleTableExt;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    public class ShowInventoryStockCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1; // ToDo add validations for arguments
        public ShowInventoryStockCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ShowInventoryStock], Company name[Sky]

            // Original command form: ShowInventoryStock
            // Parameters:
            //  [0] - inventory name
            var companyName = this.CommandParameters[0];

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(decimal));
            table.Columns.Add("Product Value", typeof(string));



            var query = this.Repository.Companies
                         .FirstOrDefault(x => x.Name == companyName)?.Inventory
                         .SelectMany(company => company.Products)
                         .Select(product => new { product.Name, product.Quantity, product.Price, Value = product.Quantity*product.Price + " $" });


            foreach (var item in query)
            {
                table.Rows.Add(item.Name, item.Quantity, item.Price, item.Value);
            }

            // Use ConsoleTableExt to display the data in a tabular format
            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine($"Current inventory of the company ");
            sb.AppendLine(tableString);

            return sb.ToString();

            //a

        }
    }
}
