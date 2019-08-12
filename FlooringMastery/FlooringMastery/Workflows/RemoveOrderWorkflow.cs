using Flooring.BLL;
using Flooring.Models.Responses;

namespace FlooringMastery.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute(FileLookupResponse retrievedOrders)
        {            
            retrievedOrders.Order = ConsoleIO.GetOrderIndex("Please enter order number you would like to remove: ", retrievedOrders.Orders);
            ConsoleIO.PrintOrderInfo(retrievedOrders.Order, retrievedOrders.OrderDate);
            ConsoleIO.ConfirmRemoval(retrievedOrders, retrievedOrders.Order);
        }       
    }
}
