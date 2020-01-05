using Flooring.BLL;
using Flooring.BLL.Rules;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Globalization;
using System.IO;

namespace FlooringMastery.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute(FileLookupResponse retrievedOrders)
        {
            FileManager manager = FileManagerFactory.Create();
            AddOrderResponse response = new AddOrderResponse();            
            AddOrderRules addRules = new AddOrderRules();
            DateTime today = DateTime.Now;

            while (retrievedOrders.Success == false)
            {
                if (DateTime.ParseExact(retrievedOrders.OrderDate, "MMddyyyy", CultureInfo.InvariantCulture) <= today)
                {
                    Console.WriteLine($"Order date must be at least one day in the future.");
                    Console.ReadKey();
                    FileLookupWorkflow lookupWorkflow = new FileLookupWorkflow();
                    retrievedOrders = lookupWorkflow.LookupFile();
                }

                else
                {
                    if (!File.Exists(retrievedOrders.OrderDate))
                    {
                        Console.WriteLine(response.Message);
                        var addFileResponse = ConsoleIO.GetYesNoFromUser("Would you like to create new order for this date?: ");
                        if (addFileResponse == "Y")
                        {
                            retrievedOrders.Success = true;
                            File.WriteAllText(retrievedOrders.FilePath, "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total" + System.Environment.NewLine);
                        }
                        else
                        {
                            Console.WriteLine("Order Cancelled");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            retrievedOrders.Success = false;
                            return;
                        }
                    }
                }
            }

                retrievedOrders.Orders = manager.RetrieveOrders(retrievedOrders.FilePath);
            Order newOrder = ConsoleIO.GetAddOrderInfoFromUser();

            while (response.Success == false)
            {
                Console.Clear();
                response = addRules.AddOrder(newOrder, retrievedOrders);

                if (response.Success == false)
                {
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();


                    switch (response.Fail)
                    {
                        case "name":
                            newOrder.CustomerName = ConsoleIO.GetStringFromUser("Please Enter Customer Name: ");
                            break;
                        case "state":
                            newOrder.State = ConsoleIO.GetStringFromUser("Please Enter State: ");
                            break;
                        case "product":
                            ConsoleIO.PrintProductInfo(manager.GetProducts());
                            newOrder.ProductType = ConsoleIO.GetStringFromUser("Please Enter Product Type: ");
                            break;
                        case "area":
                            newOrder.Area = ConsoleIO.GetDecimalFromUser("Please Enter Area: ");
                            break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("=======================");
            ConsoleIO.PrintOrderInfo(response.Order, retrievedOrders.OrderDate);
            ConsoleIO.ConfirmNewOrder(response);
        }



}
}
