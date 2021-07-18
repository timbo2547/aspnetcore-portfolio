using AspNetCorePostgreSQLDockerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public class PostgresDbContext : DbContext
    {
        // add db models
        public DbSet<SampleItem> SampleItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

    }
}
