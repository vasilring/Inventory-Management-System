using InventoryManagementSystem.Commands.Contracts;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core
{
    public class Engine : IEngine
    {

        private const string TerminationCommand = "exit";
        private const string EmptyCommandError = "Command cannot be empty.";
        private const string ReportSeparator = "####################\n";

        private readonly ICommandFactory commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine().Trim();

                    if (inputLine == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }

                    if (inputLine.ToLower() == TerminationCommand)
                    {
                        break;
                    }

                    ICommand command = commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.WriteLine(result.Trim());
                    Console.WriteLine(ReportSeparator);
                }
                catch (AuthorizationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ReportSeparator);
                }

                catch (EntityNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ReportSeparator);
                }

                catch (InvalidUserInputException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ReportSeparator);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ReportSeparator);
                }
            }
        }
    }
}
