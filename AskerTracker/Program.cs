using System;
using AskerTracker.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AskerTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Helpers.MigrateDatabase(host);
            
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            if (!string.Equals(env, "production", StringComparison.OrdinalIgnoreCase))
                Helpers.SeedDb(host);

            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}