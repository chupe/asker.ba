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