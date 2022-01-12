using System;
using System.IO;
using System.Text.Json.Serialization;
using AskerTracker.Web.Common;
using AskerTracker.Infrastructure;
using AskerTracker.Web.Services.Mail;
using AskerTracker.Web.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace AskerTracker.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var helpers = new DbHelpers(Configuration);
        var connectionString = helpers.GetConnectionString();
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (!string.Equals(env, "production", StringComparison.OrdinalIgnoreCase))
            services.AddDbContext<AskerTrackerDbContext>(options =>
                options.UseInMemoryDatabase("Temp")
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        else
            services.AddDbContext<AskerTrackerDbContext>(options =>
                options.UseSqlServer(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
        services.AddTransient<IEmailSender, MailService>();

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AskerTrackerDbContext>()
            .AddDefaultTokenProviders();

        services.AddLocalization(options => options.ResourcesPath = "Resources");

        services.AddRazorPages(
                options => { options.Conventions.AuthorizeFolder("/"); }
            )
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

        services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });

        services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(999);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.Use(SayHelloMiddleware);

        var supportedCultures = new[] {"bs-BA"};
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        app.UseHttpsRedirection();

        // this will serve up wwwroot
        app.UseFileServer();

        // this will serve up node_modules
        app.UseFileServer(new FileServerOptions
        {
            RequestPath = "/node_modules",
            StaticFileOptions =
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "node_modules")
                )
            },
            EnableDirectoryBrowsing = true
        });

        app.UseCookiePolicy();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });
    }

    private RequestDelegate SayHelloMiddleware(RequestDelegate next)
    {
        return async context =>
        {
            if (context.Request.Path.StartsWithSegments("/hello"))
            {
                var test = Environment.GetEnvironmentVariable("ASKER_DBCONNECTION");
                await context.Response.WriteAsync($"Hello from middleware! {test}");
            }
            else
            {
                await next(context);

                if (context.Response.StatusCode == 404)
                    await context.Response.WriteAsync("404 intercepted from middleware");
            }
        };
    }
}