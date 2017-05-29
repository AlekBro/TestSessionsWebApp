using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestSessionsWebApp.Models;

[assembly: OwinStartupAttribute(typeof(TestSessionsWebApp.Startup))]
namespace TestSessionsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateMainRolesAndUsers();

            app.MapSignalR();
        }



        /// <summary>
        /// Primary initialization for test Admin and test User users
        /// </summary>
        private void CreateMainRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Creating Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // Creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }

            ApplicationUser resultAdmin = UserManager.FindByEmail("MasterUserSessionsWebApp@yopmail.com");
            if (resultAdmin == null)
            {
                //Here we create a Admin user
                var user = new ApplicationUser();
                user.UserName = "MasterUserSessionsWebApp@yopmail.com";
                user.Email = "MasterUserSessionsWebApp@yopmail.com";

                string userPassword = "1234Qwer!";

                var сreatingUserResult = UserManager.Create(user, userPassword);

                //Add default User to Role Admin and User  
                if (сreatingUserResult.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                    UserManager.AddToRole(user.Id, "User");
                }
            }

            ApplicationUser resultUser1 = UserManager.FindByEmail("User1SessionsWebApp@yopmail.com");
            if (resultUser1 == null)
            {
                var user = new ApplicationUser();
                user.UserName = "User1SessionsWebApp@yopmail.com";
                user.Email = "User1SessionsWebApp@yopmail.com";

                string userPassword = "1234Qwer!";

                var сreatingUserResult = UserManager.Create(user, userPassword);
                if (сreatingUserResult.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "User");
                }
            }

            ApplicationUser resultUser2 = UserManager.FindByEmail("User2SessionsWebApp@yopmail.com");
            if (resultUser2 == null)
            {
                var user = new ApplicationUser();
                user.UserName = "User2SessionsWebApp@yopmail.com";
                user.Email = "User2SessionsWebApp@yopmail.com";

                string userPassword = "1234Qwer!";

                var сreatingUserResult = UserManager.Create(user, userPassword);
                if (сreatingUserResult.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "User");
                }
            }
        }

    }
}
