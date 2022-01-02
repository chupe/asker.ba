using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Areas.Domain.Pages;

public class AskerTrackerPageModel : PageModel
{
    [TempData]
    public string Message { get; set; }
}