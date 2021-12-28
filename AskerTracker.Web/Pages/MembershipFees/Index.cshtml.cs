using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Pages.MembershipFees
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<MembershipFee> _repository;

        public IndexModel(IRepository<MembershipFee> repository)
        {
            _repository = repository;
        }

        public IList<MembershipFee> MembershipFee { get; set; }
        
        [TempData] public string Message { get; set; }

        public SelectList Members { get; set; }

        [BindProperty(SupportsGet = true)] public string MemberName { get; set; }

        public async Task OnGetAsync()
        {
            var fees = (await _repository.All<MembershipFee>(m => m.Member)).ToList();
            
            if (!string.IsNullOrEmpty(MemberName))
                fees = fees.Where(x => x.Member.FullName == MemberName).ToList();
            
            var membersList = fees.OrderBy(m => m.Member.FullName).Select(n => n.Member.FullName);

            Members = new SelectList(membersList.Distinct().ToList());

            MembershipFee = fees;
        }
    }
}