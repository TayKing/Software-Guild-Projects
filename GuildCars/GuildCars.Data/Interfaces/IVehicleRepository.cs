using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        void ResetToSampleData();


        List<BodyStyle> GetAllBodyStyles();
        BodyStyle GetBodyStyleByID(int SearchID);

        List<Color> GetAllColors();
        Color GetColorByID(int SearchID);

        List<Make> GetAllMakes();
        Make GetMakeByID(int SearchID);

        List<Model> GetAllModels();
        Model GetModelByID(int SearchID);
        List<Model> GetModelsByMakeID(int SearchID);

        List<SalesType> GetAllSalesTypes();
        SalesType GetSalesTypeByID(int SearchID);

        List<Special> GetAllSpecials();
        Special GetSpecialByID(int SearchID);

        List<State> GetAllStates();
        State GetStateByID(string SearchID);

        List<Transmission> GetAllTransmissionTypes();
        Transmission GetTransmissionTypeByID(int SearchID);

        List<VehicleViewModel> GetAllVehicles();
        List<VehicleViewModel> GetNewVehicles();
        List<VehicleViewModel> GetUsedVehicles();
        List<VehicleViewModel> GetFeaturedVehicles();
        VehicleViewModel GetVehicleByID(int SearchID);
        Vehicle GetVehicleDataByID(int SearchID);





        List<VehicleViewModel> SearchVehicles(QuickSearchParameters searchParams);

        void AddSpecial(Special toAdd);
        void DeleteSpecial(int ID);
        void AddMake(Make toAdd);
        void AddModel(Model toAdd);
        void AddContact(Contact toAdd);

        int AddVehicle(Vehicle toAdd);
        int UpdateVehicle(Vehicle toUpdate);
        void DeleteVehicle(int ID);

        void AddSale(Sales toAdd);

        List<InventoryReport> GetInventoryReport(bool SearchNew);
        List<SalesReport> GetSalesReport(string UserID, string StartDate, string EndDate);
    }
}
