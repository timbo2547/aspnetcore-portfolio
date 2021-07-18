using AspNetCorePostgreSQLDockerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public class SampleItemDbSeeder
    {
        readonly ILogger _logger;

        public SampleItemDbSeeder(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("SampleItemDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            //Based on EF team's example at https://github.com/aspnet/MusicStore/blob/dev/samples/MusicStore/Models/SampleData.cs
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<PostgresDbContext>();
                if (await db.Database.EnsureCreatedAsync())
                {
                    if (!await db.SampleItems.AnyAsync())
                    {
                        //await InsertSampleItemSampleData(customersDb);
                    }

                    if (!await db.Categories.AnyAsync())
                    {

                    }
                }
            }
        }
    }
}
