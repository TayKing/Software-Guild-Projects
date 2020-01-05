using Flooring.Data;
using Flooring.Data.Test;
using System;
using System.Configuration;

namespace Flooring.BLL
{
    public static class FileManagerFactory
    {
        public static FileManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Test":
                    return new FileManager(new OrderTestRepository(), new ProductTestRepository(), new StateTaxTestRepository());
                case "Prod":
                    return new FileManager(new OrderProductionRepository(), new ProductProductionRespository(), new StateTaxProductionRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
