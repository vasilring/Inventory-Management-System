using InventoryManagementSystem.Core;
using InventoryManagementSystem.Core.Contracts;

namespace InventoryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository(); 
            ICommandFactory commandFactory = new CommandFactory(repository); 
            IEngine engine = new Engine(commandFactory);  
                                                               
            engine.Start();
        }
    }
}