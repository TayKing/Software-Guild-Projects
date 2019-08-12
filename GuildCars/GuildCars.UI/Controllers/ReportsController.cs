using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        [Authorize]
        public ActionResult Index()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");
            return View();
        }
        [Authorize]
        public ActionResult Sales()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var repo = AccountRepositoryFactory.GetRepository();
            var Model = new SalesReportViewModel();

            Model.Users = new List<SelectListItem>();
            SelectListItem temp = new SelectListItem
            {
                Value = "",
                Text = "All Users"
            };
            Model.Users.Add(temp);

            foreach (var u in repo.GetAllUsers())
            {
                temp = new SelectListItem();
                temp.Value = u.UserID;
                temp.Text = u.FirstName + " " + u.LastName;
                Model.Users.Add(temp);
            }

            return View(Model);
        }
        [Authorize]
        public ActionResult Inventory()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var repo = DataRepositoryFactory.GetRepository();
            var Model = new InventoryViewModel();
            Model.NewReports = repo.GetInventoryReport(true);
            Model.UsedReports = repo.GetInventoryReport(false);
            return View(Model);
        }
    }
}