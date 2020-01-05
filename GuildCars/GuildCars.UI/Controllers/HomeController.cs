using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Model = new GuildCars.Models.Queries.IndexViewModel();
            Model.Vehicles = DataRepositoryFactory.GetRepository().GetFeaturedVehicles();
            Model.Specials = DataRepositoryFactory.GetRepository().GetAllSpecials();

            return View(Model);
        }
        
        [HttpPost]
        public ActionResult AddContact(Contact Model)
        {
            if (ModelState.IsValid)
            {
                var repo = DataRepositoryFactory.GetRepository();

                try
                {
                    repo.AddContact(Model);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Specials()
        {
            var Model = DataRepositoryFactory.GetRepository().GetAllSpecials();
            return View(Model);
        }

        public ActionResult Contact(string VIN)
        {
            var Model = new Contact();

            if (!string.IsNullOrEmpty(VIN))
                Model.ContactReason = "I am contacting you about the car with VIN#: " + VIN;

            return View(Model);
        }
    }
}