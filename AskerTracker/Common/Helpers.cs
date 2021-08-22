﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker;
using AskerTracker.Models.Seed;
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

        public IConfiguration Configuration { get; }

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

        public string GetConnectionString()
        {
            string connectionString = "";
            List<string> connectionSources = new() { };

            connectionSources.Add(Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.User));
            connectionSources.Add(Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Machine));
            connectionSources.Add(Environment.GetEnvironmentVariable("ASKER_DBCONNECTION", EnvironmentVariableTarget.Process));
            connectionSources.Add(Configuration.GetConnectionString("AzureDB"));

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
