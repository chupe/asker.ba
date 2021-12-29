using System;
using System.Collections.Generic;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AskerTracker.Common
{
    public class DbHelpers
    {
        private readonly ILogger _logger;
        private static IConfiguration Configuration { get; set; }

        public DbHelpers(IConfiguration configuration = null, ILogger logger = null)
        {
            _logger = logger;
            Configuration = configuration;
        }
        
        public async void MigrateAndSeedDatabase(IHost host)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AskerTrackerDbContext>();
            await context.Database.MigrateAsync();

            if (!string.Equals(env, "production", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    InitializeSeed.Initialize(context);
                    _logger.LogInformation("Finished seeding database");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred seeding the DB");
                }
            }
        }

        public string GetConnectionString()
        {
            var connectionString = "";
            List<string> connectionSources = new()
            {
                Configuration.GetConnectionString("DefaultConnection"),
                Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.User),
                Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Machine),
                Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Process)
            };

            foreach (var source in connectionSources)
            {
                if (string.IsNullOrEmpty(source))
                    continue;

                connectionString = source;
                break;
            }

            if (string.IsNullOrEmpty(connectionString))
                _logger?.LogWarning("Connection string can not be found in specified files");

            return connectionString;
        }
    }
}