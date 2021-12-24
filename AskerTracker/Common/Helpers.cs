using System;
using System.Collections.Generic;
using AskerTracker.Data.Seed;
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

        public static void SeedDb(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    InitializeSeed.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
        }

        public static string GetConnectionString()
        {
            string connectionString = "";
            List<string> connectionSources = new() { };

            connectionSources.Add(Configuration.GetConnectionString("DefaultConnection"));
            connectionSources.Add(Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.User));
            connectionSources.Add(Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Machine));
            connectionSources.Add(Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Process));

            foreach (var source in connectionSources)
            {
                if (String.IsNullOrEmpty(source))
                    continue;

                connectionString = source;
                break;
            }

            return connectionString;
        }
    }
}
