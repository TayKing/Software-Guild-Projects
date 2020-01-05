using Flooring.BLL;
using Flooring.BLL.Rules;
using Flooring.Models.Responses;
using System;

namespace FlooringMastery.Workflows
{
    public class FileLookupWorkflow
    {
        public FileLookupResponse LookupFile()
        {
            FileLookupResponse response = new FileLookupResponse();
            FileManager manager = FileManagerFactory.Create();
            FileLookupRules lookupRules = new FileLookupRules();

            Console.Clear();
            Console.WriteLine("Load Order List");
            Console.WriteLine("===============================");
            Console.Write("Enter an order date(Must be in MMDDYYYY format): ");
            string orderDate = Console.ReadLine();

            response = lookupRules.LookupFile(orderDate);

            return response;

        }
    }
}
