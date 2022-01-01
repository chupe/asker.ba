using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages;

public class AboutModel : PageModel
{
    public string Message { get; set; }

    public void OnGet()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        Message = $"ASPNETCORE_ENVIRONMENT = {env}";
    }
}