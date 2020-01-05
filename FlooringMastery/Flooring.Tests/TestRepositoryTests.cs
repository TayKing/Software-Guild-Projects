using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Tests
{
    [TestFixture]
    public class TestRepositoryTests
    {
        private const string _filePath = @"C:\Coding\BitBucket\taylor-king-individual-work\FlooringMastery\SampleData\Orders_06012013.txt";
        private const string _originalData = @"C:\Coding\BitBucket\taylor-king-individual-work\FlooringMastery\SampleData\TestSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData, _filePath);
        }

        [Test]
        public void CanLoadOrderTestData()
        {
            FileManager manager = FileManagerFactory.Create();
            FileLookupResponse response = new FileLookupResponse();
            response = manager.LookupFile("06012013");
            response.Orders = manager.RetrieveOrders(_filePath);

            Assert.AreEqual(_filePath, response.FilePath);
            Assert.AreEqual(1, response.Orders.Count());
        }

        [Test]
        public void CanAddOrderToFile()
        {
            FileManager manager = FileManagerFactory.Create();
            FileLookupResponse lookup = new FileLookupResponse();
            AddOrderResponse addOrder = new AddOrderResponse();
            lookup = manager.LookupFile("06012013");
            lookup.Orders = manager.RetrieveOrders(_filePath);

            Order newOrder = new Order
            {
                CustomerName = "John",
                State = "ohio",
                ProductType = "wood",
                Area = 100
            };

            addOrder = manager.Add(newOrder, lookup);
            manager.SubmitNewOrder(newOrder, lookup.FilePath);
            lookup.Orders = manager.RetrieveOrders(_filePath);

            Order check = lookup.Orders[1];

            Assert.AreEqual(2, lookup.Orders.Count());
            Assert.AreEqual("John", check.CustomerName);
            Assert.AreEqual("OH", check.State);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(100, check.Area);
        }

        [Test]
        public void CanEditOrder()
        {
            FileManager manager = FileManagerFactory.Create();
            FileLookupResponse lookup = new FileLookupResponse();
            AddOrderResponse edit = new AddOrderResponse();
            lookup = manager.LookupFile("06012013");
            lookup.Orders = manager.RetrieveOrders(_filePath);

            Order editedOrder = lookup.Orders[0];
            editedOrder.Area = 200;


            edit = manager.Edit(editedOrder, lookup.Orders[0], lookup);
            manager.ProcessEditOrder(lookup, editedOrder);
            lookup.Orders = manager.RetrieveOrders(_filePath);

            Order check = lookup.Orders[0];

            Assert.AreEqual("Wise", check.CustomerName);
            Assert.AreEqual("OH", check.State);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(200m, check.Area);
        }

        [Test]
        public void CanRemoveOrder()
        {
            FileManager manager = FileManagerFactory.Create();
            FileLookupResponse lookup = new FileLookupResponse();
            AddOrderResponse edit = new AddOrderResponse();
            lookup = manager.LookupFile("06012013");
            lookup.Orders = manager.RetrieveOrders(_filePath);

            Order removeOrder = lookup.Orders[0];

            manager.ProcessRemoval(lookup, removeOrder);
            lookup.Orders = manager.RetrieveOrders(_filePath);

            Assert.AreEqual(0, lookup.Orders.Count());
        }
    }
}
