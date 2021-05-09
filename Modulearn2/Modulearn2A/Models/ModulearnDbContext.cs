using Microsoft.EntityFrameworkCore;

namespace Modulearn2A.Models
{
    public class ModulearnDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ModulearnDbContext(DbContextOptions<ModulearnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<AdminModel>().ToTable("Admins");

            modelBuilder.Entity<ContentModel>().ToTable("Contents");
        }

        //Users
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdminModel> Admins { get; set; }

        //Content
        public DbSet<ContentModel> Content { get; set; }

    }
}
