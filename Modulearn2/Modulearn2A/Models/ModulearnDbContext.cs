using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            modelBuilder.Entity<AdminAccounts>().ToTable("Admins");

            modelBuilder.Entity<ContentModel>().ToTable("Contents");
            modelBuilder.Entity<ContentMetaModel>().ToTable("ContentMetas");
            modelBuilder.Entity<ContentJointModel>().ToTable("ContentJoints");
        }

        //Users
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserModel> Admins { get; set; }

        //Content
        public DbSet<ContentJointModel> ContentJoints { get; set; }
        public DbSet<ContentModel> Content { get; set; }
        public DbSet<ContentMetaModel> ContentMeta { get; set; }

    }
}
