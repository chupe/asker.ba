using AskerTracker.Domain.Entities;

namespace AskerTracker.Application.Contracts.Persistence;

public interface IItemRepository : IAsyncRepository<Item>
{
    Task<List<Member>> GetItemWithMembers(bool includePassedEvents);
}