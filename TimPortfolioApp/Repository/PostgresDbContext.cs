using Microsoft.EntityFrameworkCore;
using TimPortfolioApp.Models;

namespace TimPortfolioApp.Repository
{
    public class PostgresDbContext : DbContext
    {
        // add db models
        public DbSet<SampleItem> SampleItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

    }
}
