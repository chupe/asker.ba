using AskerTracker.Domain.Entities;

namespace AskerTracker.Application.Contracts.Persistence;

public interface IMemberRepository : IAsyncRepository<Member>
{
    Task<bool> IsMemberNameAndJmbgUnique(string name, string jmbg);
}