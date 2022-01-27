using System;
using System.Collections.Generic;
using System.Linq;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using Bogus;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class TestingEventSeed
{
    public static List<TestingEvent> FakeTestingEvent(List<Member> fakeMembers, List<EventLocation> eventLocations)
    {
        var testingEventFaker = new Faker<TestingEvent>()
            .RuleFor(test => test.Id, new Guid())
            .RuleFor(test => test.Location, f => f.PickRandom(eventLocations))
            .RuleFor(test => test.Participants, f => f.PickRandom(fakeMembers, 15).ToHashSet())
            .RuleFor(test => test.CreatedDate, f => f.Date.Past(5))
            .RuleFor(test => test.DateHeld, f => f.Date.Past(4));

        return testingEventFaker.Generate(20);
    }
}