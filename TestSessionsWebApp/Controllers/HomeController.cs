using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSessionsWebApp.Identity;
using TestSessionsWebApp.Models;

using Microsoft.AspNet.Identity;
using TestSessionsWebApp.Utils;

namespace TestSessionsWebApp.Controllers
{
    public class HomeController : MainController
    {
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorizeAttribute(Roles = "User, Admin")]
        public ActionResult Welcome()
        {
            return View();
        }

        [CustomAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Admin()
        {
            var context = new ApplicationDbContext();

            List<ApplicationUser> allUsers = new List<ApplicationUser>();
            foreach (var userId in SignalRUserHub.UserIds)
            {
                var foundUser = context.Users.Where(user => user.Id == userId).FirstOrDefault();
                if (foundUser != null)
                {
                    bool isAdmin = UserManager.IsInRole<ApplicationUser, string>(foundUser.Id, "Admin");
                    if (isAdmin == false)
                    {
                        allUsers.Add(foundUser);
                    }
                }
            }

            return View(allUsers);
        }

    }
}