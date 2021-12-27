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
        public Helpers(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static IConfiguration Configuration { get; set; }

        public static void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AskerTrackerDbContext>();
            db.Database.Migrate();
        }

        public static void SeedDb(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                InitializeSeed.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB");
            }
        }

        public static string GetConnectionString()
        {
            var connectionString = "";
            List<string> connectionSources = new();

            connectionSources.Add(Configuration.GetConnectionString("DefaultConnection"));
            connectionSources.Add(
                Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.User));
            connectionSources.Add(
                Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Machine));
            connectionSources.Add(
                Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Process));

            foreach (var source in connectionSources)
            {
                if (string.IsNullOrEmpty(source))
                    continue;

                connectionString = source;
                break;
            }

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection string can not be found in specified files.");

            return connectionString;
        }
    }
}