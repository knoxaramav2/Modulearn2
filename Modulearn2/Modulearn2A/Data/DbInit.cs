using Modulearn2A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulearn2A.Data
{
    public class DbInit
    {
        public static void InitializeDatabase(ModulearnDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            //Force invalid user non-admin user
            var nullUser = new UserModel()
            {
                UserName = "NULLUSER",
                Email = "",
                PasswordHash = ""
            };

            context.Users.Add(nullUser);
            context.SaveChanges();
        }
    }
}
