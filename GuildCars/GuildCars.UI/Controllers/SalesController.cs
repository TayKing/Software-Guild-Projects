using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [Authorize]
        public ActionResult Index()
        {
            if (!AuthUtilities.HasPermissions("Sales", this))
                return RedirectToAction("Index", "Home");

            return View();
        }


        [Authorize]
        public ActionResult Purchase(int id)
        {
            if (!AuthUtilities.HasPermissions("Sales", this))
                return RedirectToAction("Index", "Home");

            var repo = DataRepositoryFactory.GetRepository();
            var Model = new SalesViewModel();
            Model.Sales = new Sales();
            Model.Vehicle = repo.GetVehicleByID(id);
            Model.States = repo.GetAllStates();
            Model.Types = repo.GetAllSalesTypes();

            return View(Model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SavePurchase(SalesViewModel Model)
        {
            var repo = DataRepositoryFactory.GetRepository();

            Model.Sales.VehicleID = Model.Vehicle.VehicleID;
            Model.Sales.UserID = AuthUtilities.GetCurrentUserID(this);
            Model.Sales.SalesDate = DateTime.Now.Date.ToString("MM'-'dd'-'yyyy");

            repo.AddSale(Model.Sales);

            return RedirectToAction("Index");
        }

    }
}