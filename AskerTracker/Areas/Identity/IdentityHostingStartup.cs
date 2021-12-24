using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AskerTracker.Areas.Identity.IdentityHostingStartup))]
namespace AskerTracker.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}