using Flooring.Models;
using Flooring.Models.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Flooring.Data
{
    public class ProductTestRepository : IProductRepository
    {
        public List<Product> Products()
        {            
                string path = ConfigurationManager.AppSettings["product"].ToString() + "Test.txt";
                string[] allLines = File.ReadAllLines(path);
                Product selectedProduct = new Product();
                List<Product> products = new List<Product>();

                for (int i = 1; i < allLines.Length; i++)
                {
                    string[] columns = allLines[i].Split(',');

                    Product p = new Product()
                    {
                        ProductType = columns[0],
                        CostPerSquareFoot = decimal.Parse(columns[1]),
                        LaborCostPerSquareFoot = decimal.Parse(columns[2])
                    };

                    products.Add(p);
                }

                return products;

        }
    }
}
