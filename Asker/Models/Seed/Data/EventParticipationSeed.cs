using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asker.Models.Seed.Data
{
    public class EventParticipationSeed
    {
        private static HashSet<Member> list = new()
        {
            MemberSeed.Entries[3],
            MemberSeed.Entries[4],
            MemberSeed.Entries[5],
            MemberSeed.Entries[6],
            MemberSeed.Entries[7],
            MemberSeed.Entries[8]
        };

        public static List<EventParticipation> Entries = new()
        {
            new EventParticipation
            {
                EventId = TrainingSeed.TrainingIds[0],
                List = list
            },
            new EventParticipation
            {
                EventId = TrainingSeed.TrainingIds[1],
                List = new ()
                {
                    MemberSeed.Entries[1],
                    MemberSeed.Entries[2],
                    MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                }
            },
            new EventParticipation
            {
                EventId = TrainingSeed.TrainingIds[2],
                List = new ()
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
                EventId = TrainingSeed.TrainingIds[3],
                List = new ()
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
            new EventParticipation
            {
                EventId = TestingEventSeed.TestingIds[0],
                List = new ()
                {
                    new Member() { Id = MemberSeed.Entries[3].Id },
                    //MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                    MemberSeed.Entries[5],
                    MemberSeed.Entries[6],
                    MemberSeed.Entries[7],
                    MemberSeed.Entries[8]
                }
            },
            new EventParticipation
            {
                EventId = TestingEventSeed.TestingIds[1],
                List = new ()
                {
                    MemberSeed.Entries[1],
                    MemberSeed.Entries[2],
                    MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                }
            },
            new EventParticipation
            {
                EventId = TestingEventSeed.TestingIds[2],
                List = new ()
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
        };
    }
}
