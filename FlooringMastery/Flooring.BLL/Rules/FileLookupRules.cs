using Flooring.Models.Responses;
using System.IO;
using System.Text.RegularExpressions;

namespace Flooring.BLL.Rules
{
    public class FileLookupRules
    {
        public FileLookupResponse LookupFile(string orderDate)
        {
            FileManager manager = FileManagerFactory.Create();
            FileLookupResponse response = new FileLookupResponse();
            response.OrderDate = orderDate;
            response.FilePath = manager.LoadFile(orderDate);
            Regex dateRestriction = new Regex(@"^(0?[1-9]|1[0-2])(0?[1-9]|[12]\d|3[01])(19|20)\d{2}$");

            if (string.IsNullOrEmpty(orderDate))
            {
                response.Success = false;
                response.Message = "Date is required in MMDDYYY format.";
                return response;
            }

            if (!dateRestriction.IsMatch(orderDate))
            {
                response.Success = false;
                response.Message = "Please enter date in MMDDYYYY format.";
                return response;
            }            

            if (!File.Exists(response.FilePath))
            {
                response.Success = false;
                response.Message = $"File does not exist for {orderDate}.";
                return response;
            }

            response.Success = true;
            
            return response;
        }
    }
}
