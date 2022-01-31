using AskerTracker.Domain.Entities;
using Bogus;

namespace AskerTracker.Persistence.Seed.Data;

public static class EventLocationSeed
{
    public static List<EventLocation> FakeLocations()
    {
        var locationsFaker = new Faker<EventLocation>()
            .RuleFor(location => location.Id, new Guid())
            .RuleFor(location => location.CreatedDate, f => f.Date.Past(5))
            .RuleFor(location => location.Location, f => f.Address.County());

        return locationsFaker.Generate(20);
    }
}