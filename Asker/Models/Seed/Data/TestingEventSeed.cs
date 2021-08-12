using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public class TestingEventSeed
    {
        public static List<TestingEvent> Entries = new()
        {
            new TestingEvent
            {
                DateHeld = new DateTime(2018, 10, 2),
                Location = EventLocationSeed.Entries[0],
                Participants = EventParticipationSeed.Entries[0]
            },
            new TestingEvent
            {
                DateHeld = new DateTime(2019, 1, 26),
                Location = EventLocationSeed.Entries[1],
                Participants = EventParticipationSeed.Entries[1]
            },
            new TestingEvent
            {
                DateHeld = new DateTime(2020, 12, 2),
                Location = EventLocationSeed.Entries[2],
                Participants = EventParticipationSeed.Entries[2]
            },
            new TestingEvent
            {
                DateHeld = new DateTime(2021, 6, 30),
                Location = EventLocationSeed.Entries[3],
                Participants = EventParticipationSeed.Entries[3]
            },
        };
    }
}
