using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.RepositoryTest;
using System;

namespace GuildCars.Data.Factories
{
    public static class AccountRepositoryFactory
    {
        public static AccountRepositoryTest _testRepo { get; set; }

        public static IAccountRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new AccountRepositoryADO();
                case "QA":
                    if (_testRepo == null)
                        _testRepo = new AccountRepositoryTest();
                    return _testRepo;
                default:
                    throw new Exception("Could not find valid RepositoryType setting in web.config");
            }
        }
    }
}
