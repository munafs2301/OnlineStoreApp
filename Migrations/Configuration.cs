namespace BankerApp.Migrations
{
    using BankerApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BankerApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BankerApp.Models.ApplicationDbContext";
        }

        protected override void Seed(BankerApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var user = new ApplicationUser
            {
                Email = "muna@gmail.com",
                UserName = "muna@gmail.com",
                EmailConfirmed = true
            };

            var result = manager.Create(user, "muna.12345.FS");

            if (result.Succeeded)
            {
                if (!rolemanager.RoleExists("ADMIN"))
                {
                    var role = new IdentityRole();
                    role.Name = "ADMIN";
                    rolemanager.Create(role);

                    manager.AddToRole(user.Id, "ADMIN");
                }
                manager.AddToRole(user.Id, "ADMIN");
            }
        }
    }
}
