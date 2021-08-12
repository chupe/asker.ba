using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public class TrainingSeed
    {
        public static List<Training> Entries = new()
        {
            new Training
            {
                DateHeld = new DateTime(2018, 10, 2),
                Location = EventLocationSeed.Entries[0],
                TrainingType = TrainingType.Internal,
                Participants = EventParticipationSeed.Entries[0]
            },
            new Training
            {
                DateHeld = new DateTime(2019, 1, 26),
                Location = EventLocationSeed.Entries[1],
                TrainingType = TrainingType.Cooperation,
                Participants = EventParticipationSeed.Entries[1]
            },
            new Training
            {
                DateHeld = new DateTime(2020, 12, 2),
                Location = EventLocationSeed.Entries[2],
                TrainingType = TrainingType.Hiking,
                Participants = EventParticipationSeed.Entries[2]
            },
            new Training
            {
                DateHeld = new DateTime(2021, 4, 30),
                Location = EventLocationSeed.Entries[3],
                TrainingType = TrainingType.Match,
                Participants = EventParticipationSeed.Entries[3]
            },
        };
    }
}
