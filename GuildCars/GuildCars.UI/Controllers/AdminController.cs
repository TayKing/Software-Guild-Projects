using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildVehicles.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {

        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        [Authorize]
        public ActionResult Users()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var repo = AccountRepositoryFactory.GetRepository();
            var Model = repo.GetAllUsers();

            return View(Model);
        }


        [Authorize]
        public ActionResult AddUser()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, UserRole = model.Role };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Users", "Admin");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [Authorize]
        public ActionResult EditUser(string UserID)
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var repo = AccountRepositoryFactory.GetRepository();
            var Model = repo.GetUserByID(UserID);

            return View(Model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(model.UserID);
                if (!string.IsNullOrEmpty(model.Password))
                {
                    string passwordResetToken = UserManager.GeneratePasswordResetToken(user.Id);
                    var pwResult = await UserManager.ResetPasswordAsync(user.Id, passwordResetToken, model.Password);
                    if (!pwResult.Succeeded)
                    {
                        AddErrors(pwResult);
                        return View(model);
                    }
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserRole = model.Role;
                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Users", "Admin");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        [Authorize]
        public ActionResult Index()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [Authorize]
        public ActionResult Vehicles()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [Authorize]
        public ActionResult AddVehicle()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var repo = DataRepositoryFactory.GetRepository();
            var Model = new AddVehicleViewModel();
            Model.VehicleToAdd = new Vehicle();
            Model.ListBody = repo.GetAllBodyStyles();
            Model.ListColor = repo.GetAllColors();
            Model.ListMake = repo.GetAllMakes();
            Model.ListModel = repo.GetAllModels();
            Model.ListTransmission = repo.GetAllTransmissionTypes();
            Model.ListTypeOptions = new Dictionary<string, bool>() { { "New", true }, { "Used", false } };

            return View(Model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel model)
        {
            int NewVehicleID = 0;
            if (ModelState.IsValid)
            {
                var repo = DataRepositoryFactory.GetRepository();

                try
                {
                    NewVehicleID = repo.AddVehicle(model.VehicleToAdd);
                    if (model.ImageUpload != null)
                    {
                        var savePath = Server.MapPath("~/Images");
                        var fileName = "Inventory-" + NewVehicleID + ".png";
                        var filePath = Path.Combine(savePath, fileName);

                        model.ImageUpload.SaveAs(filePath);
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                if (NewVehicleID != 0)
                    return RedirectToAction("EditVehicle", "Admin", new { Id = NewVehicleID });
            }
            return View(model);
        }


        [Authorize]
        public ActionResult EditVehicle(int id)
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var repo = DataRepositoryFactory.GetRepository();
            var Model = new AddVehicleViewModel();
            Model.VehicleToAdd = repo.GetVehicleDataByID(id);
            Model.ListBody = repo.GetAllBodyStyles();
            Model.ListColor = repo.GetAllColors();
            Model.ListMake = repo.GetAllMakes();
            Model.ListModel = repo.GetAllModels();
            Model.ListTransmission = repo.GetAllTransmissionTypes();
            Model.ListTypeOptions = new Dictionary<string, bool>() { { "New", true }, { "Used", false } };

            return View(Model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditVehicle(AddVehicleViewModel model)
        {
            int NewVehicleID = 0;
            if (ModelState.IsValid)
            {
                var repo = DataRepositoryFactory.GetRepository();

                try
                {
                    NewVehicleID = repo.UpdateVehicle(model.VehicleToAdd);
                    if (model.ImageUpload != null)
                    {
                        var savePath = Server.MapPath("~/Images");
                        var fileName = "Inventory-" + NewVehicleID + ".png";
                        var filePath = Path.Combine(savePath, fileName);

                        model.ImageUpload.SaveAs(filePath);
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                if (NewVehicleID != 0)
                    return RedirectToAction("Vehicles", "Admin");
            }
            return View(model);
        }
        public ActionResult DeleteVehicle(int Id)
        {
            var repo = DataRepositoryFactory.GetRepository();
            return RedirectToAction("Vehicles");
        }

        [Authorize]
        public ActionResult Makes()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var Model = new MakeViewModel();
            var repo = DataRepositoryFactory.GetRepository();

            Model.CurrentMakes = repo.GetAllMakes();
            Model.MakeToAdd = new Make();

            return View(Model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddMake(MakeViewModel Model)
        {
            var accountRepo = AccountRepositoryFactory.GetRepository();
            var currentUser = accountRepo.GetUserByID(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                var repo = DataRepositoryFactory.GetRepository();

                try
                {
                    Model.MakeToAdd.UserCreated = AuthUtilities.GetCurrentUserEmail(this);
                    Model.MakeToAdd.DateCreated = DateTime.Now.Date.ToString("MM'-'dd'-'yyyy");
                    repo.AddMake(Model.MakeToAdd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Makes");
        }

        [Authorize]
        public ActionResult Models()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var Model = new ModelViewModel();
            var repo = DataRepositoryFactory.GetRepository();

            Model.CurrentModels = repo.GetAllModels();
            Model.CurrentMakes = repo.GetAllMakes();
            Model.ModelToAdd = new Model();

            return View(Model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddModel(ModelViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var repo = DataRepositoryFactory.GetRepository();

                try
                {
                    Model.ModelToAdd.UserCreated = AuthUtilities.GetCurrentUserEmail(this);
                    Model.ModelToAdd.DateCreated = DateTime.Now.Date.ToString("MM'-'dd'-'yyyy");
                    repo.AddModel(Model.ModelToAdd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Models");
        }


        [Authorize]
        public ActionResult Specials()
        {
            if (!AuthUtilities.HasPermissions("Admin", this))
                return RedirectToAction("Index", "Home");

            var Model = new SpecialsViewModel();
            var repo = DataRepositoryFactory.GetRepository();

            Model.CurrentSpecials = repo.GetAllSpecials();
            Model.SelectedSpecial = new Special();

            return View(Model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddSpecial(SpecialsViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var repo = DataRepositoryFactory.GetRepository();

                try
                {
                    repo.AddSpecial(Model.SelectedSpecial);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            return RedirectToAction("Specials");
        }
        [Authorize]
        public ActionResult DeleteSpecial(int Id)
        {
            var repo = DataRepositoryFactory.GetRepository();
            repo.DeleteSpecial(Id);
            return RedirectToAction("Specials");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}