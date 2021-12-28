using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure;
using AskerTracker.Infrastructure.Interfaces;
using AskerTracker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        [TempData]
        public string Message { get; set; }
        public IList<Member> Members { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var members = _repository.All().Select(m => m);

            if (!string.IsNullOrEmpty(SearchString)) members = members.Where(s => s.FullName.Contains(SearchString));

            Members = members.ToList();
        }
    }
}