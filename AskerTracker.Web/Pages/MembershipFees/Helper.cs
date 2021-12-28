using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AskerTracker.Pages.MembershipFees
{
    public static class Helper
    {
        public static async Task<SelectList> GetSelectList(IRepository<MembershipFee> repository)
        {
            var fees = (await repository.All<MembershipFee>(m => m.Member)).ToList();

            var membersList = fees.OrderBy(m => m.Member.FullName).Select(n => n.Member).GroupBy(x => x.FullName)
                .Select(y => y.First()).ToList();

            return new SelectList(membersList, "Id", "FullName");
        }
    }
}