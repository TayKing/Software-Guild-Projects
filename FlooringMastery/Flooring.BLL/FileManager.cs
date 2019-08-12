using Flooring.BLL.Rules;
using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Flooring.BLL
{
    public class FileManager
    {
        private IOrderRepository _orderRepository;
        private IStateTaxRepository _stateTaxRepository;
        private IProductRepository _productRepository;

        public FileManager(IOrderRepository orderRepository, IProductRepository productRepository, IStateTaxRepository stateTaxRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _stateTaxRepository = stateTaxRepository;
        }
        
        public List<Order> RetrieveOrders(string filePath)
        {
            List<Order> orders = new List<Order>();

            orders = _orderRepository.List(filePath);

            return orders;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            products = _productRepository.Products();

            return products;
        }

        public string LoadFile(string orderDate)
        {
           string filepath = _orderRepository.LoadFile(orderDate);

            return filepath;
        }

        public List<StateTax> GetStateTaxes()
        {
            List<StateTax> stateTaxes = new List<StateTax>();

            stateTaxes = _stateTaxRepository.StateTaxes();

            return stateTaxes;
        }

        public void SubmitNewOrder(Order orderToAdd, string filePath)
        {
            _orderRepository.AddOrder(orderToAdd, filePath);
        }

        public void ProcessEditOrder(FileLookupResponse fileInfo, Order order)
        {
            _orderRepository.EditOrder(fileInfo, order);
        }

        public void ProcessRemoval(FileLookupResponse fileInfo, Order order)
        {
            _orderRepository.RemoveOrder(fileInfo, order);
        }        

        
    }
}
