using AskerTracker.Domain.Entities;

namespace AskerTracker.Application.Contracts.Persistence;

public interface IFeesRepository: IAsyncRepository<MembershipFee>
{
    Task<List<MembershipFee>> GetPagedFeesForMonth(DateTime date, int page, int size);
    Task<int> GetTotalCountOfFeesForMonth(DateTime date);
}