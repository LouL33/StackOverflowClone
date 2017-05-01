namespace StackOverflowClone.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StackOverflowClone.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StackOverflowClone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StackOverflowClone.Models.ApplicationDbContext context)
        {
            var AuthenticatedUserRole = "AuthenticatedUser";
            var ModeratorRole = "Moderator";

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == AuthenticatedUserRole))
            {
                var role = new IdentityRole { Name = AuthenticatedUserRole };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == ModeratorRole))
            {
                var role = new IdentityRole { Name = ModeratorRole };
                manager.Create(role);
            }


            var defaultModerator = "Moderator@gmail.com";
            var password = "Password1!";

            if (!context.Users.Any(a => a.UserName == defaultModerator))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultModerator };

                userManager.Create(user, password);
                userManager.AddToRole(user.Id, ModeratorRole);
            }
        }

    }
}
