using AskerTracker.Domain.Entities;

namespace AskerTracker.Application.Contracts.Persistence;

public interface ITrainingRepository : IAsyncRepository<Training>
{
    Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
}