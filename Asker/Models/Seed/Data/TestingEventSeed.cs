using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker.Common.Extensions;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public class TestingEventSeed
    {
        public static List<Guid> TestingIds { get; set; } = new List<Guid>()
        {
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3304"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3305"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3306"),
        };

        public static List<TestingEvent> Entries()
        {
            return new()
            {
                new TestingEvent
                {
                    Id = TestingIds[0],
                    DateHeld = new DateTime(2018, 10, 2),
                    Location = EventLocationSeed.Entries[0],
                    Participants = EventParticipationSeed.Entries[4]
                },
                new TestingEvent
                {
                    Id = TestingIds[1],
                    DateHeld = new DateTime(2019, 1, 26),
                    Location = EventLocationSeed.Entries[1],
                    Participants = EventParticipationSeed.Entries[5]
                },
                new TestingEvent
                {
                    Id = TestingIds[2],
                    DateHeld = new DateTime(2020, 12, 2),
                    Location = EventLocationSeed.Entries[2],
                    Participants = EventParticipationSeed.Entries[6]
                }
            };
        }
    }
}
