using GuildCars.Data.Factories;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Details(int id)
        {
            var repo = DataRepositoryFactory.GetRepository();
            var Model = repo.GetVehicleByID(id);

            return View(Model);
        }

        public ActionResult New()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var Model = repo.GetNewVehicles();
            return View(Model);
        }
        public ActionResult Used()
        {
            var repo = DataRepositoryFactory.GetRepository();
            var Model = repo.GetUsedVehicles();
            return View(Model);
        }
    }
 }