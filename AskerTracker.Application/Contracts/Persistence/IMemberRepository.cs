using AskerTracker.Domain.Entities;

namespace AskerTracker.Application.Contracts.Persistence;

public interface IMemberRepository : IAsyncRepository<Member>
{
    Task<bool> IsMemberNameAndJmbgUnique(string fullName, string jmbg);
    Task<IReadOnlyList<Member>> ListAllAsync(bool includeInactive);
}