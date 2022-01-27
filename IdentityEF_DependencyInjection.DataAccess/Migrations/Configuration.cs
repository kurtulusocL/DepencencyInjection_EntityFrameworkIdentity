namespace IdentityEF_DependencyInjection.DataAccess.Migrations
{
    using IdentityEF_DependencyInjection.Core.CrossCuttingConcert.Identities.Microsoft.Users;
    using IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework.Context;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IdentityEF_DependencyInjection.DataAccess.Concrete.EntityFramework.Context.ApplicationDbContext context)
        {
            //CreateRoles(context);
            //CreateAdmin(context);
        }

        private void CreateAdmin(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = userManager.FindByNameAsync("Admin").Result;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "ocL.1972",
                    NameLastname = "Kurtuluş Öcal",
                    Email = "kurtulusocal@protonmail.com",
                    Country = "Turkey",
                    Gender = "Man",
                    Birthdate = DateTime.Now.ToLocalTime(),
                    City = "Ankara",
                    Province = "Ankara",
                    IsConfirm = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now.ToLocalTime(),
                    PhoneNumber = "+905444939494",                   
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                userManager.Create(user, "ocL_123");
                userManager.AddToRole(user.Id, "Admin");
            }
            var userInRole = userManager.IsInRole(user.Id, "Admin");
            if (!userInRole)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void CreateRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleName = { "Admin", "Helpers", "Asistants", "Users" };
            foreach (var role in roleName)
            {
                if (roleManager.RoleExists(role) == false)
                {
                    var newRole = new IdentityRole { Name = role };
                    roleManager.Create(newRole);
                }
            }
        }
    }
}
