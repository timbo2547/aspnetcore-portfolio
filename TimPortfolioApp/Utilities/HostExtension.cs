using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TimPortfolioApp.Repository;

namespace TimPortfolioApp.Utilities
{
    public static class HostExtension
    {
        public static IWebHost Migrate<T>(this IWebHost webHost) where T : PostgresDbContext
        {


            
            // using (var scope = webHost.Services.CreateScope())
            // {
            //     var services = scope.ServiceProvider;
            //     try
            //     {
            //         var db = services.GetRequiredService<T>();
            //         db.Database.Migrate();
            //     }
            //     catch (Exception ex)
            //     {
            //         var logger = services.GetRequiredService<ILogger<Program>>();
            //         logger.LogError(ex, "An error occurred while migrating the database.");
            //     }
            // }
            return webHost;
        }
    }
}