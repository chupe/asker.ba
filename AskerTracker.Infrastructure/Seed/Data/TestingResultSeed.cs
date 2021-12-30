using System;
using System.Collections.Generic;
using System.Linq;
using AskerTracker.Domain;

namespace AskerTracker.Infrastructure.Seed.Data
{
    public static class TestingResultSeed
    {
        public static List<TestingResult> Entries()
        {
            return new List<TestingResult>
            {
                new()
                {
                    EventId = TestingEventSeed.TestingIds[0],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[0].Id,
                    MaximumDeadliftWeight = 340,
                    StandingPowerThrow = 12.5,
                    HandReleasePushup = 60,
                    SprintDragCarry = new TimeSpan(0, 1, 33),
                    LegTuck = 20,
                    TwoMileRun = new TimeSpan(0, 13, 30)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[0],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[1].Id,
                    MaximumDeadliftWeight = 200,
                    StandingPowerThrow = 8.0,
                    HandReleasePushup = 30,
                    SprintDragCarry = new TimeSpan(0, 2, 10),
                    LegTuck = 5,
                    TwoMileRun = new TimeSpan(0, 18, 0)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[0],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[2].Id,
                    MaximumDeadliftWeight = 180,
                    StandingPowerThrow = 6.5,
                    HandReleasePushup = 20,
                    SprintDragCarry = new TimeSpan(0, 2, 30),
                    LegTuck = 3,
                    TwoMileRun = new TimeSpan(0, 19, 0)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[0],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[3].Id,
                    MaximumDeadliftWeight = 140,
                    StandingPowerThrow = 4.5,
                    HandReleasePushup = 10,
                    SprintDragCarry = new TimeSpan(0, 3, 00),
                    LegTuck = 1,
                    TwoMileRun = new TimeSpan(0, 21, 0)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[0],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[4].Id,
                    MaximumDeadliftWeight = 130,
                    StandingPowerThrow = 4.3,
                    HandReleasePushup = 8,
                    SprintDragCarry = new TimeSpan(0, 3, 10),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 21, 18)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[0],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[5].Id,
                    MaximumDeadliftWeight = 90,
                    StandingPowerThrow = 3.5,
                    HandReleasePushup = 1,
                    SprintDragCarry = new TimeSpan(0, 3, 30),
                    LegTuck = 1,
                    TwoMileRun = new TimeSpan(0, 22, 30)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[1],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[0].Id,
                    MaximumDeadliftWeight = 201,
                    StandingPowerThrow = 8.1,
                    HandReleasePushup = 31,
                    SprintDragCarry = new TimeSpan(0, 2, 09),
                    LegTuck = 6,
                    TwoMileRun = new TimeSpan(0, 17, 58)
                },
                new()
                {
                    EventId = TestingEventSeed.TestingIds[1],
                    MemberId = TestingEventSeed.Entries()[0].Participants.ToList()[1].Id,
                    MaximumDeadliftWeight = 339,
                    StandingPowerThrow = 12.4,
                    HandReleasePushup = 59,
                    SprintDragCarry = new TimeSpan(0, 1, 36),
                    LegTuck = 19,
                    TwoMileRun = new TimeSpan(0, 13, 32)
                }
            };
        }
    }
}