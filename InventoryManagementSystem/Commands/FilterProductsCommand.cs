using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

            if ( this.CommandParameters.Count == 2 )
            {
                if (value.ToLower() == "price" ) 
                {
                    FilterProductsByPrice(value2, table);
                }

                else if (value.ToLower() == "name")// else filter by name
                {

                    FilterProductByName(value2, table);
                }
            }

            else if (this.CommandParameters.Count == 3) // Filter Products by cream, lipstick or perfume and show their price in descending order
            {
                var value3 = this.CommandParameters[2];

                FilterProductsByNameAndPrice(value2, value3, table);
            }

            // Table
            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine(tableString);

            return sb.ToString();
        }
        //----------------------------------Filter Product By Price And Name-------------------------------------------

        private void FilterProductsByNameAndPrice(string value, string value2, DataTable table)
        {
            var filter = this.Repository.Company
                             .SelectMany(x => x.Inventory)
                            .SelectMany(x => x.Products);

            if (value2 == "asc")
            {
                var filterAscending = filter
                    .Where(x => x.Name.ToLower().Contains(value))
                    .Select(product => new { product.Name, product.Quantity, product.Price })
                    .OrderBy(x => x.Price)
                    .ToList();

                foreach (var item in filterAscending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }

            else
            {
                var filterAscending = filter
                    .Where(x => x.Name.ToLower().Contains(value))
                    .Select(product => new { product.Name, product.Quantity, product.Price })
                    .OrderByDescending(x => x.Price)
                    .ToList();

                foreach (var item in filterAscending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }
        }

        //----------------------------------Filter Product By Price-------------------------------------------
        private void FilterProductsByPrice(string value, DataTable table)
        {
            var filter = this.Repository.Company
                             .SelectMany(x => x.Inventory)
                            .SelectMany(x => x.Products);

            if (value == "asc")
            {
                var filterAscending = filter
                    .Select(product => new { product.Name, product.Quantity, product.Price })
                    .OrderBy(x => x.Price)
                    .ToList();

                foreach (var item in filterAscending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }

            else
            {
                var filterDescending = filter
                        .Select(product => new { product.Name, product.Quantity, product.Price })
                        .OrderByDescending(x => x.Price)
                        .ToList();

                foreach (var item in filterDescending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }
        }
        //----------------------------------------Filter Product By Name--------------------------------------------
        private void FilterProductByName(string value, DataTable table)
        {
            var filter = this.Repository.Company
                        .SelectMany(x => x.Inventory)
                        .SelectMany(x => x.Products)
                        .Where(x => x.Name.ToLower().Contains(value))
                        .Select(product => new { product.Name, product.Quantity, product.Price })
                        .ToList();

            foreach (var item in filter) 
            {
                table.Rows.Add(item.Name, item.Quantity, item.Price);
            }
        }

        //ToDo implement the command for the clients, they can order the products by name, price or quantity (Asc or Desc)
        // Or Filter the product that contain: Cream, Lipstick or Perfume in their names and filter them by name, price or quantity (Asc or Desc)
    }
}
