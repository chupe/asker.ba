using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Web.Common.Extensions;
using AskerTracker.Web.Common;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Web.Areas.Domain.Pages.MembershipFees;

public class CreateModel : AskerTrackerPageModel
{
    private readonly AskerTrackerDbContext _context;

    public CreateModel(AskerTrackerDbContext context)
    {
        _context = context;
    }

    [BindProperty] public MembershipFee MembershipFee { get; set; }

    public IEnumerable<SelectListItem> MembersSelectList { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }
    public Member PreselectedMember { get; set; }

    public async Task<IActionResult> OnGet()
    {
        MembersSelectList = Helper.GetSelectList<Member>(_context, m => m.FullName).Result;
        ReturnUrl = Request.Headers["Referer"].ToString();

        var queryString = new System.Uri(ReturnUrl).Query;
        var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);

        if (!string.IsNullOrEmpty(queryDictionary["memberfilter"]))
            PreselectedMember = await _context.Members.FindAsync(queryDictionary["memberfilter"].ToGuid());

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