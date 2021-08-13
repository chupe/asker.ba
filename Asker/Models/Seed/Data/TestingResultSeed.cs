using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public class TestingResultSeed
    {
        public static List<TestingResult> Entries()
        {
            return new()
            {
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[0],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[0],
                    MaximumDeadliftWeight = 200,
                    StandingPowerThrow = 7.8,
                    HandReleasePushup = 60,
                    SprintDragCarry = new TimeSpan(0, 2, 0),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 18, 0)
                },
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[0],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[1],
                    MaximumDeadliftWeight = 220,
                    StandingPowerThrow = 6.5,
                    HandReleasePushup = 20,
                    SprintDragCarry = new TimeSpan(0, 2, 10),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 20, 0)
                },
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[0],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[2],
                    MaximumDeadliftWeight = 240,
                    StandingPowerThrow = 12,
                    HandReleasePushup = 30,
                    SprintDragCarry = new TimeSpan(0, 1, 50),
                    LegTuck = 1,
                    TwoMileRun = new TimeSpan(0, 21, 0)
                },
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[0],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[3],
                    MaximumDeadliftWeight = 340,
                    StandingPowerThrow = 4.5,
                    HandReleasePushup = 25,
                    SprintDragCarry = new TimeSpan(0, 1, 33),
                    LegTuck = 7,
                    TwoMileRun = new TimeSpan(0, 17, 0)
                },
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[0],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[4],
                    MaximumDeadliftWeight = 280,
                    StandingPowerThrow = 9.9,
                    HandReleasePushup = 30,
                    SprintDragCarry = new TimeSpan(0, 1, 45),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 16, 22)
                },
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[0],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[5],
                    MaximumDeadliftWeight = 210,
                    StandingPowerThrow = 5,
                    HandReleasePushup = 60,
                    SprintDragCarry = new TimeSpan(0, 2, 0),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 18, 0)
                },

                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[1],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[0],
                    MaximumDeadliftWeight = 200,
                    StandingPowerThrow = 7.8,
                    HandReleasePushup = 60,
                    SprintDragCarry = new TimeSpan(0, 2, 0),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 18, 0)
                },
                new TestingResult
                {
                    Event = TestingEventSeed.Entries()[1],
                    Member = TestingEventSeed.Entries()[0].Participants.List.ToList()[1],
                    MaximumDeadliftWeight = 200,
                    StandingPowerThrow = 7.8,
                    HandReleasePushup = 60,
                    SprintDragCarry = new TimeSpan(0, 2, 0),
                    LegTuck = 10,
                    TwoMileRun = new TimeSpan(0, 18, 0)
                },
            };
        }
    }
}
