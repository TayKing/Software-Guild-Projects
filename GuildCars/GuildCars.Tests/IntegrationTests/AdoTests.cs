using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using NUnit.Framework;

namespace GuildVehicles.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void InitDB()
        {
            var repo = DataRepositoryFactory.GetRepository();
            repo.ResetToSampleData();
        }


        [Test]
        public void CanLoadStates()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var states = repo.GetAllStates();

            Assert.AreEqual(3, states.Count);
            Assert.AreEqual("MN", states[2].StateID);
            Assert.AreEqual("Minnesota", states[2].StateName);
        }
        [Test]
        public void CanSearchStates()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var state = repo.GetStateByID("MN");
            Assert.AreEqual("Minnesota", state.StateName);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllBodyStyles();

            Assert.AreEqual(4, data.Count);
            Assert.AreEqual("Car", data[0].Body);
        }
        [Test]
        public void CanSearchBodyTypes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetBodyStyleByID(1);

            Assert.AreEqual("Car", data.Body);
        }

        [Test]
        public void CanLoadTransmissionTypes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllTransmissionTypes();
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("Manual", data[0].TransmissionType);
        }
        [Test]
        public void CanSearchTransmissionTypes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetTransmissionTypeByID(1);
            Assert.AreEqual("Manual", data.TransmissionType);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllColors();
            Assert.AreEqual(8, data.Count);
            Assert.AreEqual("Black", data[0].VehicleColor);
        }
        [Test]
        public void CanSearchColors()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetColorByID(1);
            Assert.AreEqual("Black", data.VehicleColor);
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllMakes();
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual("Ford", data[0].MakeName);
        }
        [Test]
        public void CanSearchMakes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetMakeByID(1);
            Assert.AreEqual("Ford", data.MakeName);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllModels();
            Assert.AreEqual(6, data.Count);
            Assert.AreEqual(1, data[1].MakeID);
            Assert.AreEqual("Mustang", data[1].ModelName);
        }
        [Test]
        public void CanSearchModels()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetModelByID(2);
            Assert.AreEqual(1, data.MakeID);
            Assert.AreEqual("Mustang", data.ModelName);
        }
        [Test]
        public void CanSearchModelsByMake()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetModelsByMakeID(1);
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(1, data[1].MakeID);
            Assert.AreEqual("Mustang", data[1].ModelName);
        }

        [Test]
        public void CanLoadSalesTypes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllSalesTypes();
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual("Bank Finance", data[1].SalesTypeName);
        }
        [Test]
        public void CanSearchSalesTypes()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetSalesTypeByID(2);
            Assert.AreEqual("Bank Finance", data.SalesTypeName);
        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetAllSpecials();
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual("Cash Back", data[0].SpecialName);
            Assert.AreEqual("Get cash back on your purchuse!", data[0].SpecialDescription);
        }
        [Test]
        public void CanSearchSpecials()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetSpecialByID(1);
            Assert.AreEqual("Cash Back", data.SpecialName);
            Assert.AreEqual("Get cash back on your purchuse!", data.SpecialDescription);
        }
        
        [Test]
        public void CanSearchVehiclesByID()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetVehicleByID(2);
            Assert.AreEqual("TESTVIN", data.VIN);
        }

        [Test]
        public void CanSearchNewVehicles()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var data = repo.GetNewVehicles();
            Assert.AreEqual(1, data.Count);
        }
    }
}
