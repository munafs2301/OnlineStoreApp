using BankerApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(BankerApp.Startup))]
namespace BankerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // createRolesandUsers();
        }

        //private void createRolesandUsers()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //    var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        //    var user = new ApplicationUser
        //    {
        //        Email = "muna@gmail.com",
        //        UserName = "muna@gmail.com",
        //        EmailConfirmed = true
        //    };

        //    var result = manager.Create(user, "muna.12345.FS");

        //    if (result.Succeeded)
        //    {
        //        if (!rolemanager.RoleExists("ADMIN"))
        //        {
        //            var role = new IdentityRole();
        //            role.Name = "ADMIN";
        //            rolemanager.Create(role);

        //            manager.AddToRole(user.Id, "ADMIN");
        //        }
        //        manager.AddToRole(user.Id, "ADMIN");
        //    }


        //}
    }
}
