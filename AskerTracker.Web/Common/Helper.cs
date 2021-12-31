using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Common
{
    public static class Helper
    {
        public static async Task<IEnumerable<SelectListItem>> GetMemberSelectList(AskerTrackerDbContext context,
            string dataValueField = "Id", string dataTextField = "FullName", bool selectedValue = false)
        {
            var list = await context.Members.ToListAsync();

            var membersList = list.OrderBy(m => m.FullName).GroupBy(x => x.FullName)
                .Select(y => y.First()).ToList();

            return new SelectList(membersList, dataValueField, dataTextField, selectedValue);
        }

        public static IEnumerable<SelectListItem> AppendItem(this IEnumerable<SelectListItem> list, SelectListItem item)
        {
            return list.Append(item);
        }

        public static IEnumerable<SelectListItem> AppendTeamPropertyItem(this IEnumerable<SelectListItem> list)
        {
            return list.Append(new SelectListItem("Team property", "", true));
        }
    }
}