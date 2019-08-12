using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;

namespace FlooringMastery
{
    public class ConsoleIO
    {      
        public static void DisplayOrders(FileLookupResponse fileInfo)
        {
            foreach (var o in fileInfo.Orders)
            {
                PrintOrderInfo(o, fileInfo.OrderDate);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static decimal GetDecimalFromUser(string prompt)
        {            
                Console.Write(prompt);
                string input = Console.ReadLine();
                if(decimal.TryParse(input, out decimal output))
                    {
                        return output;                             
                    }

            return output = 0;
        }

        public static Order GetEditOrderInfoFromUser(Order currentOrder)
        {
            StateTax stateTax = new StateTax();
            Product product = new Product();
            
            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.WriteLine("=====================");
            Console.WriteLine();


            Order editOrder = new Order();

            editOrder.CustomerName = GetStringFromUser($"Please enter customer name({currentOrder.CustomerName}): ");            
            editOrder.State = GetStringFromUser($"Please enter your state({currentOrder.State}): ");            
            editOrder.ProductType = GetStringFromUser($"Please select a product type from the list({currentOrder.ProductType}): ");
            editOrder.Area = GetDecimalFromUser($"Please enter required square footage(min 100 sq ft)({currentOrder.Area}): ");
           
            return editOrder;
        }

        public static Order GetAddOrderInfoFromUser()
        {
            FileManager manager = FileManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Add Order");
            Console.WriteLine("=====================");
            Console.WriteLine();


            Order newOrder = new Order();

            newOrder.CustomerName = GetStringFromUser("Please enter customer name: ");
            newOrder.State = GetStringFromUser("Please enter your state: ");
            PrintProductInfo(manager.GetProducts());
            newOrder.ProductType = GetStringFromUser("Please select a product type from the list: ");           
            newOrder.Area = GetDecimalFromUser("Please enter required square footage(min 100 sq ft): ");

            return newOrder;
        }
        
        public static void PrintOrderInfo(Order o, string orderDate)
        {
            Console.WriteLine(o.OrderNumber + "|" + orderDate);
            Console.WriteLine(o.CustomerName);
            Console.WriteLine(o.State);
            Console.WriteLine($"Product: {o.ProductType}");
            Console.WriteLine($"Materials: {o.MaterialCost:c}");
            Console.WriteLine($"Labor: {o.LaborCost:c}");
            Console.WriteLine($"Tax: {o.Tax:c}");
            Console.WriteLine($"Total: {o.Total:c}");
        }

        public static string GetYesNoFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return input;
                }
            }
        }

        public static Order GetOrderIndex(string prompt, List<Order> orders)
        {
            Order requestedOrder = new Order();

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter a valid order number");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

                for (int i = 0; i < orders.Count; i++)
                    {
                    if (int.Parse(input) == orders[i].OrderNumber)
                        {
                        requestedOrder = orders[i];
                        return requestedOrder;
                        }
                    }
                    
                        Console.WriteLine("You must enter a valid order number");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();                    
            }
        }

        public static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            return input;
        }

        public static void PrintProductInfo(List<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(p.ProductType);
                Console.WriteLine("================");
                Console.WriteLine($"Cost per square foot: {p.CostPerSquareFoot}");
                Console.WriteLine($"Labor cost per square foot: {p.LaborCostPerSquareFoot}");
                Console.WriteLine();
            }
        }

        public static void ConfirmNewOrder(AddOrderResponse response)
        {
            FileManager manager = FileManagerFactory.Create();
            Console.WriteLine();
            if (ConsoleIO.GetYesNoFromUser("Would you like to submit this order?") == "Y")
            {
                manager.SubmitNewOrder(response.Order, response.FilePath);
                Console.WriteLine("Order Added!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Order Cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void ConfirmEdit(FileLookupResponse retrievedOrders, AddOrderResponse response)
        {
            FileManager manager = FileManagerFactory.Create();

            Console.WriteLine();
            if (ConsoleIO.GetYesNoFromUser("Would you like to submit this order?") == "Y")
            {
                manager.ProcessEditOrder(retrievedOrders, response.Order);
                Console.WriteLine("Order Edited!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Edit Order Cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void ConfirmRemoval(FileLookupResponse fileInfo, Order order)
        {
            FileManager manager = FileManagerFactory.Create();
            Console.WriteLine();
            if (ConsoleIO.GetYesNoFromUser("Are you sure you want to remove this file?") == "Y")
            {
                manager.ProcessRemoval(fileInfo, order);
                Console.WriteLine("Order removed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Remove Cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
