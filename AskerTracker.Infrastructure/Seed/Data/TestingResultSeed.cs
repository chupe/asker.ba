using System;
using System.Collections.Generic;
using System.Linq;
using AskerTracker.Domain;
using Bogus;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class TestingResultSeed
{
    public static List<TestingResult> FakeResults(List<TestingEvent> events)
    {
        var listOfResults = new List<TestingResult>();
        var faker = new Faker();

        foreach (var testingEvent in faker.PickRandom(events, 20))
        {
            foreach (var member in testingEvent.Participants)
            {
                var resultsFaker = new Faker<TestingResult>()
                    .RuleFor(result => result.Id, new Guid())
                    .RuleFor(result => result.Event, testingEvent)
                    .RuleFor(result => result.Member, member)
                    .RuleFor(result => result.CreatedDate, testingEvent.CreatedDate)
                    .RuleFor(result => result.LegTuck, f => f.Random.Int(0, 20))
                    .RuleFor(result => result.HandReleasePushup, f => f.Random.Int(0, 60))
                    .RuleFor(result => result.MaximumDeadliftWeight, f => f.Random.Int(100, 360))
                    .RuleFor(result => result.SprintDragCarry, f => f.Date.Timespan(new TimeSpan(0, 4, 0)))
                    .RuleFor(result => result.StandingPowerThrow, f => f.Random.Float(3, 13))
                    .RuleFor(result => result.TwoMileRun, f => f.Date.Timespan(new TimeSpan(0, 25, 0)));

                listOfResults.AddRange(resultsFaker.Generate(1));
            }
        }

        return listOfResults;
    }
}