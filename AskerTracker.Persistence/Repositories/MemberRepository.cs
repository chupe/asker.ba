using System.Collections.Immutable;
using AskerTracker.Application.Contracts.Persistence;
using AskerTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AskerTracker.Persistence.Repositories;

public class MemberRepository : BaseRepository<Member>, IMemberRepository
{
    private readonly AskerTrackerDbContext _dbContext;

    public MemberRepository(AskerTrackerDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsMemberNameAndJmbgUnique(string fullName, string jmbg)
    {
        return !(await ListAllAsync()).Any(member => member.FullName == fullName && member.Jmbg == jmbg);
    }

    public async Task<IReadOnlyList<Member>> ListAllAsync(bool includeInactive)
    {
        if (includeInactive)
            return await _dbContext.Set<Member>().ToListAsync();

        return await ListAllAsync();
    }

    public new async Task<IReadOnlyList<Member>> ListAllAsync()
    {
        return await _dbContext.Set<Member>().Where(member => member.Active).ToListAsync();
    }
}