using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asker.Models.Seed.Data
{
    public class EventParticipationSeed
    {
        public static List<EventParticipation> Entries = new()
        {
            new EventParticipation
            {
                EventId = TrainingSeed.Entries[0].Id,
                List = new List<Member>()
                {
                    MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                    MemberSeed.Entries[5],
                    MemberSeed.Entries[6],
                    MemberSeed.Entries[7],
                    MemberSeed.Entries[8]
                }
            },
            new EventParticipation
            {
                EventId = TrainingSeed.Entries[0].Id,
                List = new List<Member>()
                {
                    MemberSeed.Entries[1],
                    MemberSeed.Entries[2],
                    MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                }
            },
            new EventParticipation
            {
                EventId = TrainingSeed.Entries[0].Id,
                List = new List<Member>()
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
            },
            new EventParticipation
            {
                EventId = TrainingSeed.Entries[0].Id,
                List = new List<Member>()
                {
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
            },
        };
    }
}
