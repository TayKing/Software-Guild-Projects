using Flooring.BLL;
using Flooring.Models.Responses;
using System;

namespace FlooringMastery.Workflows
{
    public class DisplayOrderWorkflow
    {
        FileManager manager = FileManagerFactory.Create();

        public void Execute(FileLookupResponse retrievedOrders)
        {
            if (retrievedOrders.Success)
            {
                retrievedOrders.Orders = manager.RetrieveOrders(retrievedOrders.FilePath);
                ConsoleIO.DisplayOrders(retrievedOrders);
            }
            else
            {
                Console.WriteLine(retrievedOrders.Message);
                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
        }
    }        
}
