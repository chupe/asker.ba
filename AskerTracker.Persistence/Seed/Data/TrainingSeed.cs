using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Types;
using Bogus;

namespace AskerTracker.Persistence.Seed.Data;

public static class TrainingSeed
{
    public static List<Training> FakeTrainings(List<Member> fakeMembers, List<EventLocation> fakeLocations)
    {
        var trainingsFaker = new Faker<Training>()
            .RuleFor(training => training.Id, new Guid())
            .RuleFor(training => training.CreatedDate, f => f.Date.Past(5))
            .RuleFor(training => training.DateHeld, f => f.Date.Past(5))
            .RuleFor(training => training.Location, f => f.PickRandom(fakeLocations))
            .RuleFor(training => training.Participants, f => f.PickRandom(fakeMembers, 15).ToHashSet())
            .RuleFor(training => training.TrainingType, f => f.PickRandom<TrainingType>());

        return trainingsFaker.Generate(100);
    }
}