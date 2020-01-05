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
    public class EditOrderRules
    {
        public AddOrderResponse EditOrder(Order editOrder, Order currentOrder, FileLookupResponse retrievedOrders)
        {
            string newInput;
            StateTax validStateTax = new StateTax();            
            FileManager manager = FileManagerFactory.Create();
            var stateTaxes = manager.GetStateTaxes();
            AddOrderResponse response = new AddOrderResponse();
            var products = manager.GetProducts();
            Product product = new Product();
            bool TaxIsValid = false;
            bool ProductIsValid = true;
            Regex namingRestrictions = new Regex(@"^[0-9a-zA-Z,\.]+$");

            if (string.IsNullOrEmpty(editOrder.CustomerName))
            {                
                editOrder.CustomerName = currentOrder.CustomerName;
            }
            else
            {
                if (!namingRestrictions.IsMatch(editOrder.CustomerName))
                {
                    response.Success = false;
                    response.Message = "Customer name may only be alphanumeric and use periods and commas.";
                    response.Fail = "name";
                    return response;
                }
            }

            if (string.IsNullOrEmpty(editOrder.State))
            {
                validStateTax.StateAbbreviation = currentOrder.State;
                validStateTax.TaxRate = currentOrder.TaxRate;
                TaxIsValid = true;
            }
            else
            {
                string inputToLower = editOrder.State.ToLower();
                string[] inputsplit = inputToLower.Split(' ');

                if (inputsplit.Length > 2)
                {
                    response.Success = false;
                    response.Message = $"Sorry we currently do not service {editOrder.State}.";
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
                            TaxIsValid = true;
                            break;
                        }
                        if (st.StateAbbreviation == newInput.ToUpper())
                        {
                            validStateTax = st;
                            TaxIsValid = true;
                            break;
                        }                        
                    }
                }
            }

            if (TaxIsValid == false)
            {
                response.Success = false;
                response.Message = $"Sorry we currently do not service {editOrder.State}.";
                response.Fail = "state";
                return response;
            }

            if (string.IsNullOrEmpty(editOrder.ProductType))
            {
                editOrder.ProductType = currentOrder.ProductType;
                editOrder.LaborCostPerSquareFoot = currentOrder.LaborCostPerSquareFoot;
                editOrder.CostPerSquareFoot = currentOrder.CostPerSquareFoot;
            }
            else
            {
                editOrder.ProductType = editOrder.ProductType.ToLower();
                editOrder.ProductType = editOrder.ProductType.First().ToString().ToUpper() + editOrder.ProductType.Substring(1);
            }

            foreach (var p in products)
            {
                if (p.ProductType == editOrder.ProductType)
                {
                    product = p;
                    ProductIsValid = true;
                    break;
                }
                ProductIsValid = false;
            }

            if (ProductIsValid == false)
            {
                response.Success = false;
                response.Message = "Please select an available product.";
                response.Fail = "product";
                return response;
            }

            if (editOrder.Area == 0)
            {
                editOrder.Area = currentOrder.Area;
            }
            else
            {
                if (editOrder.Area < 100)
                {
                    response.Success = false;
                    response.Message = "Minimum order size must be 100 or more.";
                    response.Fail = "area";
                    return response;
                }
            }            

            response.Success = true;
            response.Order = editOrder;

            response.Order.OrderNumber = currentOrder.OrderNumber;

            response.Order.State = validStateTax.StateAbbreviation;
            response.Order.TaxRate = validStateTax.TaxRate;

            response.Order.ProductType = product.ProductType;
            response.Order.CostPerSquareFoot = product.CostPerSquareFoot;
            response.Order.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

            response.Order.MaterialCost = response.Order.Area * response.Order.CostPerSquareFoot;
            response.Order.LaborCost = response.Order.Area * response.Order.LaborCostPerSquareFoot;
            response.Order.Tax = (response.Order.MaterialCost + response.Order.LaborCost) * (response.Order.TaxRate / 100);
            response.Order.Total = response.Order.MaterialCost + response.Order.LaborCost + response.Order.Tax;

            response.FilePath = retrievedOrders.FilePath;            
            
            return response;
        }
    }
}
