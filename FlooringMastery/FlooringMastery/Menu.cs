using Flooring.BLL;
using Flooring.Models.Responses;
using FlooringMastery.Workflows;
using System;

namespace FlooringMastery
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                DisplayOptions();           
                ProcessUserInput();
            }            
        }

        public static void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Flooring Program");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("5. Quit");
            Console.WriteLine("=========================");
            Console.Write("\nEnter selection: ");
        }

        public static void ProcessUserInput()
        {
            string userinput = Console.ReadLine();
            FileLookupResponse retrievedOrders = new FileLookupResponse();
            FileManager manager = FileManagerFactory.Create();

            if (int.Parse(userinput) > 0 && int.Parse(userinput) < 5)
            {
                FileLookupWorkflow lookupWorkflow = new FileLookupWorkflow();
                retrievedOrders = lookupWorkflow.LookupFile();
            }

            if (int.Parse(userinput) > 2 && int.Parse(userinput) < 5)
            {
                if (retrievedOrders.Success == false)
                {
                    Console.WriteLine(retrievedOrders.Message);
                    Console.WriteLine("Press any button to continue...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    retrievedOrders.Orders = manager.RetrieveOrders(retrievedOrders.FilePath);
                }
            }

            switch (userinput)
            {
                case "1":
                    DisplayOrderWorkflow displayOrderWorkflow = new DisplayOrderWorkflow();
                    displayOrderWorkflow.Execute(retrievedOrders);
                    break;
                case "2":
                    AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                    addOrderWorkflow.Execute(retrievedOrders);
                    break;
                case "3":
                    EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                    editOrderWorkflow.Execute(retrievedOrders);
                    break;
                case "4":
                    RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                    removeOrderWorkflow.Execute(retrievedOrders);
                    break;
                case "5":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Please select a valid option 1-5.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
