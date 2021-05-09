using System;
using System.Linq;

using Modulearn2A.Models;

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
                PasswordHash = null,
                Salt = new byte[16],
                RegistrationDate = DateTime.Now,
                AccountImage = new byte[0]
            };

            context.Users.Add(nullUser);
            context.SaveChanges();
        }
    }
}
