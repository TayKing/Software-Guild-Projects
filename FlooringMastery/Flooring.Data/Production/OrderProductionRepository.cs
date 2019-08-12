using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Flooring.Data
{
    public class OrderProductionRepository : IOrderRepository
    {
        private string _filePath;

        public void AddOrder(Order order, string filePath)
        {
            _filePath = filePath;
            
                using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCSVForOrder(order);

                sw.WriteLine(line);
            }
        }

        public void EditOrder(FileLookupResponse fileInfo, Order editedOrder)
        {
            var orders = fileInfo.Orders;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderNumber == editedOrder.OrderNumber)
                {
                    orders[i] = editedOrder;
                }
            }

            CreateOrderFile(orders, fileInfo.FilePath);
        }

        public string LoadFile(string orderDate)
        {
            string filePath = ConfigurationManager.AppSettings["orders"].ToString() + $"Orders_{ orderDate}.txt";

            _filePath = filePath;

            return _filePath;
        }

        public List<Order> List(string filePath)
        {
            List<Order> orders = new List<Order>();
            _filePath = filePath;

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order neworder = new Order();

                    string[] colomns = line.Split(',');

                    neworder.OrderNumber = int.Parse(colomns[0]);
                    neworder.CustomerName = colomns[1];
                    neworder.State = colomns[2];
                    neworder.TaxRate = decimal.Parse(colomns[3]);
                    neworder.ProductType = colomns[4];
                    neworder.Area = decimal.Parse(colomns[5]);
                    neworder.CostPerSquareFoot = decimal.Parse(colomns[6]);
                    neworder.LaborCostPerSquareFoot = decimal.Parse(colomns[7]);
                    neworder.MaterialCost = decimal.Parse(colomns[8]);
                    neworder.LaborCost = decimal.Parse(colomns[9]);
                    neworder.Tax = decimal.Parse(colomns[10]);
                    neworder.Total = decimal.Parse(colomns[11]);

                    orders.Add(neworder);
                }
            }

            return orders;
        }

        public void RemoveOrder(FileLookupResponse fileInfo, Order order)
        {
            fileInfo.Orders.Remove(order);

            CreateOrderFile(fileInfo.Orders, fileInfo.FilePath);
        }

        private void CreateOrderFile(List<Order> orders, string filePath)
        {

            _filePath = filePath;

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);                
            }

            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    sw.WriteLine(CreateCSVForOrder(order));
                }
            }
        }

        private string CreateCSVForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State,
                    order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost,
                    order.Tax, order.Total);
        }        
    }
}
