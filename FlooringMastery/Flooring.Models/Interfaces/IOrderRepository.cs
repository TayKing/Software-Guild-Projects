using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        string LoadFile(string orderDate);
        List<Order> List(string filePath);
        void AddOrder(Order order, string filePath);
        void EditOrder(FileLookupResponse fileInfo, Order order);
        void RemoveOrder(FileLookupResponse fileInfo, Order order);
    }
}
