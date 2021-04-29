using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulearn2A.Models
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        //Users
        public DbSet<UserModel> Users { get; set; }

        //Content
        public DbSet<ContentJointTable> ContentJoints { get; set; }
        public DbSet<ContentModel> Content { get; set; }
        public DbSet<ContentMetaModel> ContentMeta { get; set; }

    }
}
