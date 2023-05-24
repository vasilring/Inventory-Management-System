using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;
using System.Data;
using System.Text;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    public class ShowProductByIdCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
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
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            //CommandName[ShowProductById], Product id[1]

            // Original command form: ShowProductById
            // Parameters:
            //  [0] - product id

            var id = ParseIntParameter(this.CommandParameters[0], "Id");

            var companyName = this.CommandParameters[0];

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(decimal));
            
            var product = this.Repository.Company
                .SelectMany(x => x.Inventory)
                .SelectMany(x => x.Products)
                .Select(product => new { product.Id , product.Name, product.Brand, product.Quantity, product.Price })
                .Where(x => x.Id == id);

            if (!product.Any())
            {
                throw new EntityNotFoundException("No product was found with the given ID.");
            }

            foreach (var item in product)
            {
                table.Rows.Add(item.Id, item.Name, item.Brand, item.Quantity, item.Price);
            }

            // Use ConsoleTableExt to display the data in a tabular format
            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();
           
            sb.AppendLine(tableString);

            return sb.ToString();

        }
    }
}
