using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Tests.TestData
{
    public class VehicleDataRepositoryTest : IVehicleRepository
    {

        public List<Vehicle> _Vehicles { get; set; }
        public List<Sales> _Sales { get; set; }
        public List<Transmission> _transmissionTypes { get; set; }
        public List<State> _states { get; set; }
        public List<BodyStyle> _BodyStyles { get; set; }
        public List<Color> _colors { get; set; }
        public List<Make> _makes { get; set; }
        public List<Model> _models { get; set; }
        public List<SalesType> _SalesTypes { get; set; }
        public List<Special> _specials { get; set; }
        public List<Contact> _Contact { get; set; }


        public int AddVehicle(Vehicle toAdd)
        {
            List<Vehicle> Vehicles = new List<Vehicle>();
            foreach (VehicleViewModel c in GetAllVehicles())
            {
                Vehicles.Add(ConvertToDataModel(c.VehicleID));
            }
            toAdd.VehicleID = GetNextVehicleID();
            Vehicles.Add(toAdd);
            _Vehicles = Vehicles;

            return toAdd.VehicleID;
        }

        int GetNextVehicleID()
        {
            int nextID = 1;
            foreach (VehicleViewModel c in GetAllVehicles())
            {
                if (c.VehicleID >= nextID)
                    nextID = c.VehicleID + 1;
            }
            return nextID;
        }
        Vehicle ConvertToDataModel(int Id)
        {
            return GetVehicleDataByID(Id);
        }

        public void AddContact(Contact toAdd)
        {
            if (_Contact == null)
            {
                _Contact = new List<Contact>();
            }
            _Contact.Add(toAdd);
        }

        public void AddMake(Make toAdd)
        {
            List<Make> m = GetAllMakes();

            m.Add(toAdd);
            _makes = m;
        }

        public void AddModel(Model toAdd)
        {
            List<Model> m = GetAllModels();

            m.Add(toAdd);
            _models = m;
        }

        public void AddSale(Sales toAdd)
        {
            if (_Sales == null)
            {
                _Sales = new List<Sales>();
            }
            _Sales.Add(toAdd);
        }

        public void AddSpecial(Special toAdd)
        {
            List<Special> s = GetAllSpecials();
            s.Add(toAdd);
            _specials = s;
        }

        public void DeleteVehicle(int Id)
        {
            Vehicle toDelete = GetVehicleDataByID(Id);
            _Vehicles.Remove(toDelete);
        }

        public void DeleteSpecial(int Id)
        {
            Special toDelete = GetSpecialByID(Id);
            _specials.Remove(toDelete);
        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            if (_BodyStyles == null)
            {
                _BodyStyles = new List<BodyStyle>();
                _BodyStyles.Add(new BodyStyle() { BodyStyleID = 1, Body = "Vehicle" });
                _BodyStyles.Add(new BodyStyle() { BodyStyleID = 2, Body = "Truck" });
                _BodyStyles.Add(new BodyStyle() { BodyStyleID = 3, Body = "SUV" });
                _BodyStyles.Add(new BodyStyle() { BodyStyleID = 4, Body = "Van" });
            }
            return _BodyStyles;
        }

        public VehicleViewModel ConvertToViewModel(Vehicle c)
        {
            return new VehicleViewModel()
            {
                VehicleID = c.VehicleID,
                VehicleYear = c.VehicleYear,
                Make = GetMakeByID(c.MakeID).MakeName,
                Model = GetModelByID(c.ModelID).ModelName,
                BodyStyle = GetBodyStyleByID(c.BodyStyleID).Body,
                Transmission = GetTransmissionTypeByID(c.TransmissionID).TransmissionType,
                Color = GetColorByID(c.ColorID).VehicleColor,
                Interior = GetColorByID(c.ColorID).VehicleColor,
                Mileage = c.Mileage,
                VIN = c.VIN,
                Price = c.Price,
                MSRP = c.MSRP,
                IsFeatured = c.IsFeatured,
                IsNew = c.IsNew,
                IsSold = c.IsSold,
                VehicleDescription = c.VehicleDescription
            };
        }

        public List<VehicleViewModel> GetAllVehicles()
        {
            if (_Vehicles == null)
            {
                _Vehicles = new List<Vehicle>();
                _Vehicles.Add(new Vehicle()
                {
                    VehicleID = 1,
                    VehicleYear = 2001,
                    MakeID = 1,
                    ModelID = 1,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 1,
                    InteriorID = 1,
                    Mileage = 1000,
                    VIN = "TESTVIN",
                    Price = 100,
                    MSRP = 100,
                    IsFeatured = false,
                    IsNew = false,
                    IsSold = false,
                    VehicleDescription = "VehicleDescription here"
                });
                _Vehicles.Add(new Vehicle()
                {
                    VehicleID = 2,
                    VehicleYear = 2001,
                    MakeID = 1,
                    ModelID = 1,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 1,
                    InteriorID = 1,
                    Mileage = 1000,
                    VIN = "TESTVIN",
                    Price = 100,
                    MSRP = 100,
                    IsFeatured = false,
                    IsNew = false,
                    IsSold = false,
                    VehicleDescription = "VehicleDescription here"
                });
                _Vehicles.Add(new Vehicle()
                {
                    VehicleID = 3,
                    VehicleYear = 2001,
                    MakeID = 1,
                    ModelID = 1,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 1,
                    InteriorID = 1,
                    Mileage = 1000,
                    VIN = "TESTVIN",
                    Price = 100,
                    MSRP = 100,
                    IsFeatured = false,
                    IsNew = false,
                    IsSold = false,
                    VehicleDescription = "VehicleDescription here"
                });
            }
            List<VehicleViewModel> l = new List<VehicleViewModel>();
            foreach (Vehicle c in _Vehicles)
            {
                l.Add(ConvertToViewModel(c));
            }
            return l;
        }

        public List<Color> GetAllColors()
        {
            if (_colors == null)
            {
                _colors = new List<Color>();
                _colors.Add(new Color() { ColorID = 1, VehicleColor = "Black" });
                _colors.Add(new Color() { ColorID = 2, VehicleColor = "White" });
                _colors.Add(new Color() { ColorID = 3, VehicleColor = "Red" });
                _colors.Add(new Color() { ColorID = 4, VehicleColor = "Yellow" });
                _colors.Add(new Color() { ColorID = 5, VehicleColor = "Green" });
                _colors.Add(new Color() { ColorID = 6, VehicleColor = "Blue" });
                _colors.Add(new Color() { ColorID = 7, VehicleColor = "Pink" });
                _colors.Add(new Color() { ColorID = 8, VehicleColor = "Other" });
            }
            return _colors;
        }

        public List<Make> GetAllMakes()
        {
            if (_makes == null)
            {
                _makes = new List<Make>();
                _makes.Add(new Make() { MakeID = 1, MakeName = "Ford", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });
                _makes.Add(new Make() { MakeID = 2, MakeName = "Toyota", UserCreated = "test2@user.com", DateCreated = "2-1-2018" });
                _makes.Add(new Make() { MakeID = 3, MakeName = "Kia", UserCreated = "test3@user.com", DateCreated = "3-1-2018" });
            }
            return _makes;
        }

        public List<Model> GetAllModels()
        {
            if (_models == null)
            {
                _models = new List<Model>();
                _models.Add(new Model() { ModelID = 1, MakeID = 1, ModelName = "Explorer", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });
                _models.Add(new Model() { ModelID = 2, MakeID = 1, ModelName = "Mustang", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });
                _models.Add(new Model() { ModelID = 3, MakeID = 2, ModelName = "Prius", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });
                _models.Add(new Model() { ModelID = 4, MakeID = 2, ModelName = "Camry", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });
                _models.Add(new Model() { ModelID = 5, MakeID = 3, ModelName = "Sorento", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });
                _models.Add(new Model() { ModelID = 6, MakeID = 3, ModelName = "Optima", UserCreated = "test1@user.com", DateCreated = "1-1-2018" });

            }
            return _models;
        }

        public List<SalesType> GetAllSalesTypes()
        {
            if (_SalesTypes == null)
            {
                _SalesTypes = new List<SalesType>();
                _SalesTypes.Add(new SalesType() { SalesTypeID = 1, SalesTypeName = "Dealer Finance" });
                _SalesTypes.Add(new SalesType() { SalesTypeID = 2, SalesTypeName = "Bank Finance" });
                _SalesTypes.Add(new SalesType() { SalesTypeID = 3, SalesTypeName = "Cash" });
            }
            return _SalesTypes;
        }

        public List<Special> GetAllSpecials()
        {
            if (_specials == null)
            {
                _specials = new List<Special>();
                _specials.Add(new Special() { SpecialID = 1, SpecialName = "Special1", SpecialDescription = "Special1Desc" });
                _specials.Add(new Special() { SpecialID = 2, SpecialName = "Special2", SpecialDescription = "Special2Desc" });
                _specials.Add(new Special() { SpecialID = 3, SpecialName = "Special3", SpecialDescription = "Special3Desc" });
            }
            return _specials;
        }

        public List<State> GetAllStates()
        {
            if (_states == null)
            {
                _states = new List<State>();
                _states.Add(new State() { StateID = "TX", StateName = "Texas" });
                _states.Add(new State() { StateID = "OH", StateName = "Ohio" });
                _states.Add(new State() { StateID = "MN", StateName = "Minnesota" });
            }
            return _states;
        }

        public List<Transmission> GetAllTransmissionTypes()
        {
            if (_transmissionTypes == null)
            {
                _transmissionTypes = new List<Transmission>();
                _transmissionTypes.Add(new Transmission() { TransmissionID = 1, TransmissionType = "Manual" });
                _transmissionTypes.Add(new Transmission() { TransmissionID = 2, TransmissionType = "Automatic" });
            }
            return _transmissionTypes;
        }

        public BodyStyle GetBodyStyleByID(int SearchID)
        {
            foreach (BodyStyle current in GetAllBodyStyles())
            {
                if (current.BodyStyleID == SearchID)
                    return current;
            }
            return null;
        }

        public VehicleViewModel GetVehicleByID(int SearchID)
        {
            foreach (VehicleViewModel current in GetAllVehicles())
            {
                if (current.VehicleID == SearchID)
                    return current;
            }
            return null;
        }

        public Vehicle GetVehicleDataByID(int SearchID)
        {
            return ConvertToDataModel(SearchID);
        }

        public Color GetColorByID(int SearchID)
        {
            foreach (Color current in GetAllColors())
            {
                if (current.ColorID == SearchID)
                    return current;
            }
            return null;
        }

        public List<VehicleViewModel> GetFeaturedVehicles()
        {
            List<VehicleViewModel> found = new List<VehicleViewModel>();
            foreach (VehicleViewModel current in GetAllVehicles())
            {
                if (current.IsFeatured)
                    found.Add(current);
            }
            return found;
        }

        public List<InventoryReport> GetInventoryReport(bool SearchNew)
        {
            List<InventoryReport> report = new List<InventoryReport>();
            foreach (VehicleViewModel c in GetAllVehicles())
            {
                bool needToAdd = true;
                foreach (InventoryReport r in report)
                {
                    if (r.Make == c.Make && r.VehicleYear == c.VehicleYear && r.Model == c.Model)
                    {
                        r.Count++;
                        r.StockValue += c.Price;
                        needToAdd = false;
                    }
                }
                if (needToAdd)
                {
                    report.Add(new InventoryReport()
                    {
                        VehicleYear = c.VehicleYear,
                        Make = c.Make,
                        Model = c.Model,
                        Count = 1,
                        StockValue = c.Price
                    });
                }
            }

            return report;
        }

        public Make GetMakeByID(int SearchID)
        {
            foreach (Make current in GetAllMakes())
            {
                if (current.MakeID == SearchID)
                    return current;
            }
            return null;
        }

        public Model GetModelByID(int SearchID)
        {
            foreach (Model current in GetAllModels())
            {
                if (current.ModelID == SearchID)
                    return current;
            }
            return null;
        }

        public List<Model> GetModelsByMakeID(int SearchID)
        {
            List<Model> found = new List<Model>();

            foreach (Model current in GetAllModels())
            {
                if (current.MakeID == SearchID)
                    found.Add(current);
            }
            return found;
        }

        public List<VehicleViewModel> GetNewVehicles()
        {
            List<VehicleViewModel> found = new List<VehicleViewModel>();
            foreach (VehicleViewModel current in GetAllVehicles())
            {
                if (current.IsNew)
                    found.Add(current);
            }
            return found;
        }

        public SalesType GetSalesTypeByID(int SearchID)
        {
            foreach (SalesType current in GetAllSalesTypes())
            {
                if (current.SalesTypeID == SearchID)
                    return current;
            }
            return null;
        }

        public List<SalesReport> GetSalesReport(string UserID, string StartDate, string EndDate)
        {
            List<SalesReport> reports = new List<SalesReport>();
            foreach (Sales p in _Sales)
            {
                if (!string.IsNullOrEmpty(UserID))
                    if (p.UserID != UserID)
                        continue;

                if (!string.IsNullOrEmpty(StartDate))
                    if (DateTime.Parse(StartDate) > DateTime.Parse(p.SaleDate))
                        continue;

                if (!string.IsNullOrEmpty(EndDate))
                    if (DateTime.Parse(EndDate) < DateTime.Parse(p.SaleDate))
                        continue;

                var repo = AccountRepositoryFactory.GetRepository();

                string currentUser = repo.GetUserByID(UserID).FirstName + " " + repo.GetUserByID(UserID).LastName;
                bool needToAdd = true;
                foreach (SalesReport r in reports)
                {
                    if (r.Name == currentUser)
                    {
                        r.TotalVehicles++;
                        r.TotalSales += p.SalePrice;
                        needToAdd = false;
                    }
                }
                if (needToAdd)
                {
                    reports.Add(new SalesReport()
                    {
                        Name = currentUser,
                        TotalSales = p.SalePrice,
                        TotalVehicles = 1
                    });
                }
            }
            return reports;
        }

        public Special GetSpecialByID(int SearchID)
        {
            foreach (Special current in GetAllSpecials())
            {
                if (current.SpecialID == SearchID)
                    return current;
            }
            return null;
        }

        public State GetStateByID(string SearchID)
        {
            foreach (State current in GetAllStates())
            {
                if (current.StateID == SearchID)
                    return current;
            }
            return null;
        }

        public Transmission GetTransmissionTypeByID(int SearchID)
        {
            foreach (Transmission current in GetAllTransmissionTypes())
            {
                if (current.TransmissionID == SearchID)
                    return current;
            }
            return null;
        }

        public List<VehicleViewModel> GetUsedVehicles()
        {
            List<VehicleViewModel> found = new List<VehicleViewModel>();
            foreach (VehicleViewModel current in GetAllVehicles())
            {
                if (!current.IsNew)
                    found.Add(current);
            }
            return found;
        }

        public List<VehicleViewModel> SearchVehicles(QuickSearchParameters searchParams)
        {
            List<VehicleViewModel> search = GetAllVehicles();

            for (int i = 0; i < search.Count; i++)
            {
                if (!string.IsNullOrEmpty(searchParams.QueryString))
                {
                    if (!searchParams.QueryString.Contains(search[i].VehicleYear.ToString()) &&
                        !searchParams.QueryString.Contains(search[i].Make) &&
                        !searchParams.QueryString.Contains(search[i].Model))
                    {
                        search.RemoveAt(i);
                        i--;
                        continue;
                    }

                }
                if (searchParams.MinPrice != null)
                {
                    if (search[i].MSRP < searchParams.MinPrice)
                    {
                        search.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
                if (searchParams.MaxPrice != null)
                {
                    if (search[i].MSRP > searchParams.MaxPrice)
                    {
                        search.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
                if (searchParams.MinYear != null)
                {
                    if (search[i].VehicleYear < searchParams.MinYear)
                    {
                        search.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
                if (searchParams.MaxYear != null)
                {
                    if (search[i].VehicleYear < searchParams.MaxYear)
                    {
                        search.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
            }
            return search;
        }

        public int UpdateVehicle(Vehicle toUpdate)
        {
            for (int i = 0; i < _Vehicles.Count; i++)
            {
                if (_Vehicles[i].VehicleID == toUpdate.VehicleID)
                    _Vehicles[i] = toUpdate;
            }
            return toUpdate.VehicleID;
        }

        public void ResetToSampleData()
        {
            _Vehicles = null;
            _Sales = null;
            _transmissionTypes = null;
            _states = null;
            _BodyStyles = null;
            _colors = null;
            _makes = null;
            _models = null;
            _SalesTypes = null;
            _specials = null;
            _Contact = null;
        }
    }
}
