using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AskerTracker.Web.TagHelpers;

public class EmailTagHelper : TagHelper
{
    public string Address { get; set; }
    public string Content { get; set; }

    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", $"mailto:{Address}");
        output.Content.SetContent(Content);
        return base.ProcessAsync(context, output);
    }
}