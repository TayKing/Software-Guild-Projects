using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var outOfStock = from product in DataLoader.LoadProducts()
                             where product.UnitsInStock <= 0
                             select product;

            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var inStock = from product in DataLoader.LoadProducts()
                          where product.UnitsInStock > 0 & product.UnitPrice > 3
                          select product;

            PrintProductInformation(inStock);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
           var washingtonRegion = from customer in DataLoader.LoadCustomers()
                                   where customer.Region == "WA"
                                   select customer;

            PrintCustomerInformation(washingtonRegion);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var productName = from product in DataLoader.LoadProducts()
                              select new {Name = product.ProductName};

            Console.WriteLine("Product Name");
            Console.WriteLine("-----------------");

            foreach(var product in productName)
            {
                Console.WriteLine(product.Name);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var productPriceIncrease = from p in DataLoader.LoadProducts()
                                       select new { p.ProductID, p.ProductName, p.Category, UnitPrice = (p.UnitPrice + (p.UnitPrice * .25M)), p.UnitsInStock };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in productPriceIncrease)
            {
                Console.Write("{0,-5}", product.ProductID);
                Console.WriteLine("{0,-35} {1,-15} {2,6:c} {3,6}", product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var ProductAndCategory = from product in DataLoader.LoadProducts()
                                     select new { NameUpper = product.ProductName.ToUpper(), CategoryUpper = product.Category.ToUpper() };

            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("=================================================");

            foreach (var product in ProductAndCategory)
            {
                Console.WriteLine(line, product.NameUpper, product.CategoryUpper);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var Reorder = from p in DataLoader.LoadProducts()
                          select new { p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, ReOrder = (p.UnitsInStock < 3) ? true : false };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder");
            Console.WriteLine("==============================================================================");

            foreach (var product in Reorder)
            {
                Console.Write("{0,-5}", product.ProductID);
                Console.WriteLine("{0,-35} {1,-15} {2,6:c} {3,6} {4,6}", product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var stockValue = from p in DataLoader.LoadProducts()
                                       select new { p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, StockValue = (p.UnitsInStock*p.UnitPrice) };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,8:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("====================================================================================");

            foreach (var product in stockValue)
            {
                Console.Write("{0,-5}", product.ProductID);
                Console.WriteLine("{0,-35} {1,-15} {2,6:c} {3,6} {4,8:c}", product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var Evens = from numbers in DataLoader.NumbersA
                       where numbers % 2 == 0
                       select numbers;

            foreach(var num in Evens)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            string lastCustomer = null;

            var OrderLessThanFive = from custs in DataLoader.LoadCustomers()
                                    from ord in custs.Orders
                                    where ord.Total < 500
                                    select custs;

            foreach (var customer in OrderLessThanFive)
            {
                var currentCustomer = customer.CompanyName;

                if (currentCustomer != lastCustomer)
                {
                    Console.WriteLine(customer.CompanyName);
                    Console.WriteLine();
                    lastCustomer = currentCustomer;
                }
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var FirstThreeOdds = (from numbers in DataLoader.NumbersC
                                  where numbers % 2 == 1
                                  select numbers).Take(3);

            foreach (var num in FirstThreeOdds)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var RemoveFirstThree = (from numbers in DataLoader.NumbersB
                                  select numbers).Skip(3);

            foreach (var num in RemoveFirstThree)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var RecentOrdersWashington = from company in DataLoader.LoadCustomers()
                                         where company.Region == "WA"
                                         select new { RecentOrder = company.Orders.Max(d => d.OrderDate) , company.CompanyName };

            Console.WriteLine("{0, -40} {1, 10}", "Company Name", "Recent Order");
            Console.WriteLine("===============================================================");

            foreach(var c in RecentOrdersWashington)
            {
                Console.WriteLine("{0, -40} {1, 10}", c.CompanyName, c.RecentOrder);
            }

            Console.WriteLine("===============================================================");
            Console.WriteLine();
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var NumbersLessThanSix = DataLoader.NumbersC.TakeWhile(x=> x < 6);

            foreach (var num in NumbersLessThanSix)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var numbers = DataLoader.NumbersC;

            var AfterDivisibleThree = numbers.SkipWhile(n => n % 3 != 0).Skip(1);

            foreach (var num in AfterDivisibleThree)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var ProductsByName = from product in DataLoader.LoadProducts()
                                 orderby product.ProductName
                                 select product;

            Console.WriteLine("Product");
            Console.WriteLine("==================");

            foreach(var p in ProductsByName)
            {
                Console.WriteLine(p.ProductName);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var UnitsInStockDescending = DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock);

            PrintProductInformation(UnitsInStockDescending);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var CategoryAndPrice = DataLoader.LoadProducts().OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            PrintProductInformation(CategoryAndPrice);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var Reverse = DataLoader.NumbersB.Reverse();

            foreach (var num in Reverse)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var CategoryGroups = from category in DataLoader.LoadProducts()
                                 group category by category.Category;

            foreach (var category in CategoryGroups)
            {
                Console.WriteLine(category.Key);
                Console.WriteLine("===============");
                foreach(var product in category)
                {
                    Console.WriteLine(product.ProductName);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();

            var OrdersbyYearMonth = from customer in customers
                                    group customer by customer.CompanyName into custgroup
                                    from ordergroup in
                                        (from orders in custgroup
                                         from order in orders.Orders
                                         orderby order.OrderDate ascending
                                         group order by order.OrderDate.Year)
                                    group ordergroup by custgroup.Key;

            foreach(var CustomerGroup in OrdersbyYearMonth)
            {
                Console.WriteLine(CustomerGroup.Key);

                foreach(var OrderGroup in CustomerGroup)
                {
                    Console.WriteLine(OrderGroup.Key);

                    foreach(var Month in OrderGroup)
                    {
                        Console.WriteLine("\t{0}", Month.OrderDate.Month + "-" + Month.Total);
                    }
                }
            }
                                        
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var Products = DataLoader.LoadProducts();

            var UniqueProductCategories = Products.GroupBy(p => p.Category).Select(g => g.First());

            foreach(var category in UniqueProductCategories)
            {
                Console.WriteLine(category.Category);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts();

            var CheckExistance = products.Any(p => p.ProductID == 789);

            if (CheckExistance)
                Console.WriteLine("Item 789 exists");
            else
                Console.WriteLine("Item does not exist");
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var products = DataLoader.LoadProducts();

            var HasOutofStock = products.Where(p => p.UnitsInStock == 0).Select(p => p.Category).Distinct();

            foreach(var category in HasOutofStock)
            {
                Console.WriteLine(category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts();

            var NotOutofStock = (from product in products
                                 group product by product.Category into newgroup
                                where newgroup.All(p => p.UnitsInStock > 0)
                                select newgroup).Distinct();

            foreach(var group in NotOutofStock)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numbers = DataLoader.NumbersA;

            var OddCount = numbers.Where(n => n % 2 == 0);

            Console.WriteLine($"There are {OddCount.Count()} odd numbers.");
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();

            var OrderCount = from customer in customers
                             select new
                             {
                                 CustomerId = customer.CustomerID,
                                 OrderCount = customer.Orders.Count()
                             };

            foreach(var cust in OrderCount)
            {
                Console.WriteLine("{0,-15} {1,-15}", "Customer ID", "Number of Orders");
                Console.WriteLine("========================================");
                Console.WriteLine("{0,8} {1,15}", cust.CustomerId, cust.OrderCount);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var products = DataLoader.LoadProducts();

            var CategoryProductCount = from product in products
                                       group product by product.Category into newgroup
                                       select new
                                       {
                                           Category = newgroup.Key,
                                           ProductCount = newgroup.Count()
                                       };

            foreach(var grp in CategoryProductCount)
            {
                Console.WriteLine("{0,10} {1,20}", "Category", "Product Count");
                Console.WriteLine("=================================");
                Console.WriteLine("{0,-15} {1,10}",grp.Category, grp.ProductCount);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var products = DataLoader.LoadProducts();

            var CategoryTotalStock = from product in products
                                     group product by product.Category into newgroup
                                     select new
                                     {
                                         Category = newgroup.Key,
                                         TotalUnits = newgroup.Sum(u => u.UnitsInStock)
                                     };

            foreach (var grp in CategoryTotalStock)
            {
                Console.WriteLine("{0,10} {1,20}", "Category", "Total Units");
                Console.WriteLine("=================================");
                Console.WriteLine("{0,-15} {1,10}", grp.Category, grp.TotalUnits);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = DataLoader.LoadProducts();

            var CategoryTotalStock = from product in products
                                     group product by product.Category into newgroup
                                     select new
                                     {
                                         Category = newgroup.Key,
                                         LowestPrice = newgroup.Min(p => p.UnitPrice)
                                     };

            foreach (var grp in CategoryTotalStock)
            {
                Console.WriteLine("{0,10} {1,20}", "Category", "Total Units");
                Console.WriteLine("=================================");
                Console.WriteLine("{0,-15} {1,12:c}", grp.Category, grp.LowestPrice);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts();

            var TopCategoriesByAveragePrice = (from product in products
                                              group product by product.Category into newgroup
                                              select new
                                              {
                                                  Category = newgroup.Key,
                                                  AveragePrice = newgroup.Average(p => p.UnitPrice)
                                              }
                                              into CategoryAverages
                                              orderby CategoryAverages.AveragePrice descending
                                              select CategoryAverages).Take(3);

            foreach (var grp in TopCategoriesByAveragePrice)
            {
                Console.WriteLine("{0,10} {1,25}", "Category", "Average Unit Price");
                Console.WriteLine("======================================");
                Console.WriteLine("{0,-15} {1,12:c}", grp.Category, grp.AveragePrice);
                Console.WriteLine();
            }

        }
    }
}
