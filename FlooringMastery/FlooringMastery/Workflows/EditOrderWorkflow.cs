using Flooring.BLL;
using Flooring.BLL.Rules;
using Flooring.Models;
using Flooring.Models.Responses;
using System;

namespace FlooringMastery.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute(FileLookupResponse retrievedOrders)
        {
            FileManager manager = FileManagerFactory.Create();
            EditOrderRules editRules = new EditOrderRules();
            AddOrderResponse response = new AddOrderResponse();
            var retrievedOrder = ConsoleIO.GetOrderIndex("Please enter order number you would like to edit: ", retrievedOrders.Orders);
            Order editedOrder = ConsoleIO.GetEditOrderInfoFromUser(retrievedOrder);

            while (response.Success == false)
            {
                response = editRules.EditOrder(editedOrder, retrievedOrder, retrievedOrders);

                if (response.Success == false)
                {
                    Console.Clear();
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();


                    switch (response.Fail)
                    {
                        case "name":
                            editedOrder.CustomerName = ConsoleIO.GetStringFromUser("Please Enter Customer Name: ");
                            break;
                        case "state":
                            editedOrder.State = ConsoleIO.GetStringFromUser("Please Enter State: ");
                            break;
                        case "product":
                            ConsoleIO.PrintProductInfo(manager.GetProducts());
                            editedOrder.ProductType = ConsoleIO.GetStringFromUser("Please Enter Product Type: ");
                            break;
                        case "area":
                            editedOrder.Area = ConsoleIO.GetDecimalFromUser("Please Enter Area: ");
                            break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("=======================");
            ConsoleIO.PrintOrderInfo(response.Order, retrievedOrders.OrderDate);
            ConsoleIO.ConfirmEdit(retrievedOrders, response);
        }                
    }
}
