using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;

namespace AskerTracker.Persistence.Repositories;

public class FeeRepository : BaseRepository<MembershipFee>, IFeesRepository
{
    public FeeRepository(AskerTrackerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<MembershipFee>> GetPagedFeesForMonth(DateTime date, int page, int size)
    {
        return (await GetPagedResponseAsync(page, size)).Where(fee => fee.TransactionDate.Month == date.Month).ToList();
    }

    public async Task<float> GetSumOfFeesForMonth(DateTime date)
    {
        return (await ListAllAsync()).Where(fee => fee.TransactionDate.Month == date.Month).Select(fee => fee.Amount).Sum();
    }
}