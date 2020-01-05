using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.RepositoryTest;
using GuildVehicles.Data.ADO;
using System;

namespace GuildCars.Data.Factories
{
    public static class DataRepositoryFactory
    {
        public static VehicleRepositoryTest _testRepo { get; set; }
        public static IVehicleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new VehicleRepositoryADO();
                case "QA":
                    if (_testRepo == null)
                        _testRepo = new VehicleRepositoryTest();
                    return _testRepo;
                default:
                    throw new Exception("Could not find valid RepositoryType setting in web.config");
            }
        }
    }
}
