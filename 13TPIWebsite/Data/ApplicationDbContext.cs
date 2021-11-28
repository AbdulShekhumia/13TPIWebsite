using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalDatabase.Models;

namespace _13TPIWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GlobalDatabase.Models.Department> Department { get; set; }

        public DbSet<GlobalDatabase.Models.Job> Job { get; set; }

        public DbSet<GlobalDatabase.Models.Pollution> Pollution { get; set; }

        public DbSet<GlobalDatabase.Models.Staff> Staff { get; set; }

        public DbSet<GlobalDatabase.Models.User> User { get; set; }

        public DbSet<GlobalDatabase.Models.Workspaces> Workspaces { get; set; }
    }
}
