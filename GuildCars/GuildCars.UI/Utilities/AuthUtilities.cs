using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Utilities
{
    public class AuthUtilities
    {
        public static ApplicationUser GetCurrentUser(Controller c)
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return userMgr.FindById(c.User.Identity.GetUserId());
        }

        public static string GetCurrentUserID(Controller c)
        {
            var currentUser = GetCurrentUser(c);
            return currentUser.Id;
        }
        public static string GetCurrentUserRole(Controller c)
        {
            var currentUser = GetCurrentUser(c);
            return currentUser.UserRole;
        }
        public static string GetCurrentUserEmail(Controller c)
        {
            var currentUser = GetCurrentUser(c);
            return currentUser.Email;
        }

        public static bool HasPermissions(string permLevel, Controller c)
        {
            var currentUser = GetCurrentUser(c);

            if (permLevel == "Sales")
            {
                return currentUser.UserRole == "Sales" || currentUser.UserRole == "Admin";
            }
            if (permLevel == "Admin")
            {
                return currentUser.UserRole == "Admin";
            }
            return false;
        }
    }
}