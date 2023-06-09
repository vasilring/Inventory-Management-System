﻿using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using System.Data;
using System.Text;

namespace InventoryManagementSystem.Commands.ProductCommands
{
    public class FilterProductsCommand : BaseCommand
    {
        public FilterProductsCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }
        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {

            //Input:
            // CommandName[FilterProducts], Price or Name[Price/Name], Price or Name[ACS||DESC/CREAM||LIPSTICK], ASC or DESC [ACS/DESC]

            //FilterProductsBy, price, desc
            //FilterProductsBy, price, asc

            //FilterProductsBy, name, cream

            //FilterProductsBy, name, perfume, asc
            //FilterProductsBy, name, perfume, desc

            // Original command form: FilterProducts
            // Parameters:
            //  [0] - (optional) filter by Price or Name
            //  [1] - (optional) filter by Price - ASC or DESC || filter by name of the product
            //  [2] - (optional) filter by name, with price ASC or DESC

            var sb = new StringBuilder();

            if (CommandParameters.Count < 2 || CommandParameters.Count > 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2 or 3 command parameters");
            }

            var value = CommandParameters[0]; // name or price

            var value2 = CommandParameters[1];// asc or descending or // price for the second way filter

            //var value3 = this.CommandParameters[2]; // asc or desc for the second way filter
            DataTable table = new();
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(decimal));

            if (CommandParameters.Count == 2)
            {
                if (value.ToLower() == "price")
                {
                    FilterProductsByPrice(value2, table);
                }

                else if (value.ToLower() == "name")// else filter by name
                {

                    FilterProductByName(value2, table);
                }

                else
                {
                    throw new InvalidUserInputException("Wrong parameter, please enter 'name' or 'price'");
                }
            }

            else if (CommandParameters.Count == 3) // Filter Products by cream, lipstick or perfume and show their price in descending order
            {
                var value3 = CommandParameters[2];

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
            var filter = Repository.Company
                             .SelectMany(x => x.Inventory)
                             .SelectMany(x => x.Products)
                             .Where(x => x.Name.ToLower().Contains(value))
                             .Select(product => new { product.Name, product.Quantity, product.Price })
                             .ToList();

            if (!filter.Any())
            {
                throw new InvalidUserInputException("Product doesn't exist");
            }

            if (value2 != "asc" && value2 != "desc")
            {
                throw new InvalidUserInputException("Invalid sort order specified.");
            }

            if (value2 == "asc")
            {
                var filterAscending = filter.OrderBy(x => x.Price).ToList();

                foreach (var item in filterAscending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }

            else if (value2 == "desc")
            {
                var filterAscending = filter.OrderByDescending(x => x.Price).ToList();

                foreach (var item in filterAscending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }
        }

        //----------------------------------Filter Product By Price-------------------------------------------
        private void FilterProductsByPrice(string value, DataTable table)
        {
            if (value != "asc" && value != "desc")
            {
                throw new InvalidUserInputException("Invalid sort order specified.");
            }

            var filter = Repository.Company
                             .SelectMany(x => x.Inventory)
                             .SelectMany(x => x.Products)
                             .Select(product => new { product.Name, product.Quantity, product.Price });

            if (value == "asc")
            {
                var filterAscending = filter.OrderBy(x => x.Price).ToList();

                foreach (var item in filterAscending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }

            else if (value == "desc")
            {
                var filterDescending = filter.OrderByDescending(x => x.Price).ToList();

                foreach (var item in filterDescending)
                {
                    table.Rows.Add(item.Name, item.Quantity, item.Price);
                }
            }
        }
        //----------------------------------------Filter Product By Name--------------------------------------------
        private void FilterProductByName(string value, DataTable table)
        {
            var filter = Repository.Company
                        .SelectMany(x => x.Inventory)
                        .SelectMany(x => x.Products)
                        .Where(x => x.Name.ToLower().Contains(value))
                        .Select(product => new { product.Name, product.Quantity, product.Price })
                        .ToList();

            if (!filter.Any())
            {
                throw new InvalidUserInputException("Product doesn't exist");
            }

            foreach (var item in filter)
            {
                table.Rows.Add(item.Name, item.Quantity, item.Price);
            }
        }

        //The command for the clients, they can order the products by name, price or quantity (Asc or Desc)
        // Or Filter the product that contain: Cream, Lipstick or Perfume in their names and filter them by name, price or quantity (Asc or Desc)
    }
}
