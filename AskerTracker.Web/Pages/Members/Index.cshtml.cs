using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskerTracker.Pages.Members
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IRepository<Member> _repository;

        public IndexModel(IRepository<Member> repository)
        {
            _repository = repository;
        }

        [TempData] public string Message { get; set; }
        public IList<Member> Members { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var members = await _repository.All();
            members = members.Select(m => m);

            if (!string.IsNullOrEmpty(SearchString)) members = members.Where(s => s.FullName.Contains(SearchString));

            Members = members.ToList();
        }
    }
}