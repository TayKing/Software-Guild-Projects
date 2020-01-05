using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flooring.BLL.Rules
{
    public class AddOrderRules
    {
        public AddOrderResponse AddOrder(Order orderToAdd, FileLookupResponse retrievedOrders)
        {
            string newInput;
            StateTax validStateTax = new StateTax();
            validStateTax = null;
            FileManager manager = FileManagerFactory.Create();
            var stateTaxes = manager.GetStateTaxes();
            AddOrderResponse response = new AddOrderResponse();
            var products = manager.GetProducts();
            Product product = new Product();
            Regex namingRestrictions = new Regex(@"^[0-9a-zA-Z,\.\s]+$");

            if (string.IsNullOrEmpty(orderToAdd.CustomerName))
            {
                response.Success = false;
                response.Message = "Customer name may not be blank.";
                response.Fail = "name";
                return response;
            }
            else
            {
                if (!namingRestrictions.IsMatch(orderToAdd.CustomerName))
                {
                    response.Success = false;
                    response.Message = "Customer name may only be alphanumeric and use periods and commas.";
                    response.Fail = "name";
                    return response;
                }
            }

            if (string.IsNullOrEmpty(orderToAdd.State))
            {
                response.Success = false;
                response.Message = ("You must enter valid state name.");
                response.Fail = "state";
                return response;
            }
            else
            {
                string inputToLower = orderToAdd.State.ToLower();
                string[] inputsplit = inputToLower.Split(' ');

                if (inputsplit.Length > 2)
                {
                    response.Success = false;
                    response.Message = $"Sorry we currently do not service {orderToAdd.State}.";
                    response.Fail = "state";
                    return response;
                }
                else
                {
                    for (int i = 0; i < inputsplit.Length; i++)
                    {
                        inputsplit[i] = inputsplit[i].First().ToString().ToUpper() + inputsplit[i].Substring(1);
                    }

                    if (inputsplit.Length == 1)
                    {
                        newInput = inputsplit[0];
                    }
                    else
                    {
                        newInput = inputsplit[0] + " " + inputsplit[1];
                    }

                    foreach (var st in stateTaxes)
                    {
                        if (st.StateName == newInput)
                        {
                            validStateTax = st;
                            break;
                        }
                        if (st.StateAbbreviation == newInput.ToUpper())
                        {
                            validStateTax = st;
                            break;
                        }                        
                    }                    
                }
            }

            if(validStateTax == null)
            {
                response.Success = false;
                response.Message = $"Sorry we currently do not service {orderToAdd.State}.";
                response.Fail = "state";
                return response;
            }

            if (string.IsNullOrEmpty(orderToAdd.ProductType))
            {
                response.Success = false;
                response.Message = "Product type may not be blank.";
                response.Fail = "product";
                return response;
            }
            else
            {
                orderToAdd.ProductType = orderToAdd.ProductType.ToLower();
                orderToAdd.ProductType = orderToAdd.ProductType.First().ToString().ToUpper() + orderToAdd.ProductType.Substring(1);
            }

            foreach (var p in products)
            {
                if (p.ProductType == orderToAdd.ProductType)
                {
                    product = p;
                    break;
                }
                product = null;
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "Please select an available product.";
                response.Fail = "product";
                return response;
            }

            if (orderToAdd.Area < 100)
            {
                response.Success = false;
                response.Message = ("Minimum order size must be 100 or more.");
                response.Fail = "area";
                return response;
            }

            if(retrievedOrders.Orders.Count > 0)
            {
                orderToAdd.OrderNumber = retrievedOrders.Orders.Max(n => n.OrderNumber);
            }            

            response.Success = true;
            response.Order = orderToAdd;
            
            response.Order.OrderNumber = orderToAdd.OrderNumber + 1;

            response.Order.State = validStateTax.StateAbbreviation;
            response.Order.TaxRate = validStateTax.TaxRate;

            response.Order.ProductType = product.ProductType;
            response.Order.CostPerSquareFoot = product.CostPerSquareFoot;
            response.Order.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

            response.Order.MaterialCost = response.Order.Area * response.Order.CostPerSquareFoot;
            response.Order.LaborCost = response.Order.Area * response.Order.LaborCostPerSquareFoot;
            response.Order.Tax = (response.Order.MaterialCost + response.Order.LaborCost) * (orderToAdd.TaxRate / 100);
            response.Order.Total = response.Order.MaterialCost + response.Order.LaborCost + response.Order.Tax;

            response.FilePath = retrievedOrders.FilePath;

            return response;
        }
    }
}
