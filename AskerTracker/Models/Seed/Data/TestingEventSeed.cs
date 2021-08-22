using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Common.Extensions;
using AskerTracker.Types;

namespace AskerTracker.Models.Seed.Data
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
                    Participants = new HashSet<Member>()
                    {
                        MemberSeed.Entries[3],
                        MemberSeed.Entries[4],
                        MemberSeed.Entries[5],
                        MemberSeed.Entries[6],
                        MemberSeed.Entries[7],
                        MemberSeed.Entries[8]
                    }
                },
                new TestingEvent
                {
                    Id = TestingIds[1],
                    DateHeld = new DateTime(2019, 1, 26),
                    Location = EventLocationSeed.Entries[1],
                    Participants = new HashSet<Member>()
                    {
                        MemberSeed.Entries[1],
                        MemberSeed.Entries[2],
                        MemberSeed.Entries[3],
                        MemberSeed.Entries[4]
                    }
                },
                new TestingEvent
                {
                    Id = TestingIds[2],
                    DateHeld = new DateTime(2020, 12, 2),
                    Location = EventLocationSeed.Entries[2],
                    Participants = new HashSet<Member>()
                    {
                        MemberSeed.Entries[0],
                        MemberSeed.Entries[1],
                        MemberSeed.Entries[2],
                        MemberSeed.Entries[3],
                        MemberSeed.Entries[4],
                        MemberSeed.Entries[5],
                        MemberSeed.Entries[6],
                        MemberSeed.Entries[7],
                        MemberSeed.Entries[8],
                        MemberSeed.Entries[9]
                    }
                }
            };
        }
    }
}
