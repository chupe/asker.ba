using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asker.Models.Seed.Data
{
    public class EventParticipationSeed
    {
        private static HashSet<Guid> list = new()
        {
            MemberSeed.Entries[3].Id,
            MemberSeed.Entries[4].Id,
            MemberSeed.Entries[5].Id,
            MemberSeed.Entries[6].Id,
            MemberSeed.Entries[7].Id,
            MemberSeed.Entries[8].Id
        };

        public static List<EventParticipation> Entries = new()
        {
            new EventParticipation
            {
                List = list
            },
            new EventParticipation
            {
                List = new ()
                {
                    MemberSeed.Entries[1].Id,
                    MemberSeed.Entries[2].Id,
                    MemberSeed.Entries[3].Id,
                    MemberSeed.Entries[4].Id,
                }
            },
            new EventParticipation
            {
                List = new ()
                {
                    MemberSeed.Entries[0].Id,
                    MemberSeed.Entries[1].Id,
                    MemberSeed.Entries[2].Id,
                    MemberSeed.Entries[3].Id,
                    MemberSeed.Entries[4].Id,
                    MemberSeed.Entries[5].Id,
                    MemberSeed.Entries[6].Id,
                    MemberSeed.Entries[7].Id,
                    MemberSeed.Entries[8].Id,
                    MemberSeed.Entries[9].Id
                }
            },
            new EventParticipation
            {
                List = new ()
                {
                    MemberSeed.Entries[1].Id,
                    MemberSeed.Entries[2].Id,
                    MemberSeed.Entries[3].Id,
                    MemberSeed.Entries[4].Id,
                    MemberSeed.Entries[5].Id,
                    MemberSeed.Entries[6].Id,
                    MemberSeed.Entries[7].Id,
                    MemberSeed.Entries[8].Id,
                    MemberSeed.Entries[9].Id
                }
            },
            new EventParticipation
            {
                List = new ()
                {
                    MemberSeed.Entries[3].Id,
                    MemberSeed.Entries[4].Id,
                    MemberSeed.Entries[5].Id,
                    MemberSeed.Entries[6].Id,
                    MemberSeed.Entries[7].Id,
                    MemberSeed.Entries[8].Id
                }
            },
            new EventParticipation
            {
                List = new ()
                {
                    MemberSeed.Entries[1].Id,
                    MemberSeed.Entries[2].Id,
                    MemberSeed.Entries[3].Id,
                    MemberSeed.Entries[4].Id,
                }
            },
            new EventParticipation
            {
                List = new ()
                {
                    MemberSeed.Entries[0].Id,
                    MemberSeed.Entries[1].Id,
                    MemberSeed.Entries[2].Id,
                    MemberSeed.Entries[3].Id,
                    MemberSeed.Entries[4].Id,
                    MemberSeed.Entries[5].Id,
                    MemberSeed.Entries[6].Id,
                    MemberSeed.Entries[7].Id,
                    MemberSeed.Entries[8].Id,
                    MemberSeed.Entries[9].Id
                }
            },
        };
    }
}
