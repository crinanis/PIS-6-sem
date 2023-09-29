using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "employer" };
            var role3 = new IdentityRole { Name = "guest" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "admin@belstu.by", UserName= "admin@belstu.by" };
            string password = "werwer";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
            }

            var employer = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };
            result = userManager.Create(employer, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(employer.Id, role2.Name);
            }

            var guest = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            result= userManager.Create(guest, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(guest.Id, role3.Name);
            }

            var super = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };
            result = userManager.Create(super, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(super.Id, role1.Name);
                userManager.AddToRole(super.Id, role2.Name);
                userManager.AddToRole(super.Id, role3.Name);
            }

            base.Seed(context);
        }
    }
}