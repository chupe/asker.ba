using System;
using System.Collections.Generic;
using AskerTracker.Data;
using AskerTracker.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AskerTracker.Common
{
    public class Helpers
    {
        private readonly ILogger _logger;

        public Helpers(IConfiguration configuration = null, ILogger logger = null)
        {
            _logger = logger;
            Configuration = configuration;
        }

        private static IConfiguration Configuration { get; set; }

        public void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AskerTrackerDbContext>();
            db.Database.Migrate();
        }

        public void SeedDb(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                InitializeSeed.Initialize(services);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "An error occurred seeding the DB");
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