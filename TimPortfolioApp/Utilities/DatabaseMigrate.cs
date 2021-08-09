using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimPortfolioApp.Repository;

namespace TimPortfolioApp.Utilities
{
    public class DatabaseMigrate
    {
        public async Task ApplyMigrationsAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<PostgresDbContext>();
                if (db.Database.GetPendingMigrationsAsync().Result.Any()) {
                    await db.Database.MigrateAsync();
                }  
            }
        }
    }
}