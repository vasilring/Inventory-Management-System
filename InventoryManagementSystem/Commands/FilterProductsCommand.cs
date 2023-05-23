using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    public class FilterProductsCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public FilterProductsCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
            //Helper.ValidateParameters(CommandParameters, ExpectedNumberOfArguments);

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            //Input:
            // CommandName[FilterProducts], Price or Name[Price/Name], Price and Name[Name]

            // Original command form: FilterProducts
            // Parameters:
            //  [0] - (optional) filter by Price or Name
            //  [1] - (optional) filter by Price and Name

            var sb = new StringBuilder();

            var value = this.CommandParameters[0]; // name or price

            var value2 = this.CommandParameters[1];// asc or descending or // price for the second way filter

            //var value3 = this.CommandParameters[2]; // asc or desc for the second way filter
            DataTable table = new();
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(decimal));
            table.Columns.Add("Product Value", typeof(string));

            if ( this.CommandParameters.Count == 2 )
            {
                if (value.ToLower() == "price" && value2.ToLower() == "desc") 
                { 
                    var filterDescending = this.Repository.Company.SelectMany(x => x.Inventory)
                        .SelectMany(x => x.Products)
                        .Select(product => new { product.Name, product.Quantity, product.Price})
                        .OrderByDescending(x => x.Price)
                        .ToList();

                    foreach( var item in filterDescending )
                    {
                        table.Rows.Add(item.Name, item.Quantity, item.Price);
                    }
                }

                else if (value.ToLower() == "price" && value2.ToLower() == "asc")
                {

                }

                else // else filter by name
                {

                }
            }

            else if (this.CommandParameters.Count == 2) // Filter Products by cream, lipstick or perfume and show their price in descending order
            {

            }

            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine(tableString);

            return sb.ToString();
        }

        //ToDo implement the command for the clients, they can order the products by name, price or quantity (Asc or Desc)
        // Or Filter the product that contain: Cream, Lipstick or Perfume in their names and filter them by name, price or quantity (Asc or Desc)
    }
}
