using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common;
using AskerTracker.Common.Extensions;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Areas.Domain.Pages.MembershipFees;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    public IEnumerable<SelectListItem> MembersSelectList { get; set; }

    public string ReturnUrl { get; set; }
    public Member PreselectedMember { get; set; }

    public async Task<IActionResult> OnGet()
    {
        MembersSelectList = Helper.GetSelectList<Member>(_context, m => m.FullName).Result;
        ReturnUrl = Request.Headers["Referer"].ToString();

        var queryString = new System.Uri(ReturnUrl).Query;
        var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);

        PreselectedMember = await _context.Members.FindAsync(queryDictionary["id"].ToGuid());
        if (PreselectedMember != null)
            MembersSelectList = new List<SelectListItem>
            {
                MembersSelectList.First(m => m.Value == PreselectedMember.Id.ToString())
            };
        
        ReturnUrl = ReturnUrl.ToRelativePath();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(string returnUrl)
    {
        MembersSelectList = Helper.GetSelectList<Member>(_context, m => m.FullName).Result;
        returnUrl ??= Url.Content("~/");
        
        if (!ModelState.IsValid) return Page();

        _context.MembershipFees.Add(MembershipFee);
        await _context.Entry(MembershipFee).Reference(m => m.Member).LoadAsync();
        await _context.SaveChangesAsync();
        TempData["Message"] = $"Added fee for {MembershipFee.Member.FullName} successfully!";

        return LocalRedirect(returnUrl);
    }
}