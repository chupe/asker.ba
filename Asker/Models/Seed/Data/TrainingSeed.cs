using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker.Common.Extensions;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public class TrainingSeed
    {
        public static List<Guid> TrainingIds = new List<Guid>()
        {
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3300"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3302"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3303"),
        };

        public static List<Training> Entries()
        {
            return new()
            {
                new Training
                {
                    Id = TrainingIds[0],
                    DateHeld = new DateTime(2018, 10, 2),
                    TrainingType = TrainingType.Internal,
                    Participants = EventParticipationSeed.Entries[0],
                    Location = EventLocationSeed.Entries[0],
                },
                new Training
                {
                    Id = TrainingIds[1],
                    DateHeld = new DateTime(2019, 1, 26),
                    Location = EventLocationSeed.Entries[1],
                    TrainingType = TrainingType.Cooperation,
                    Participants = EventParticipationSeed.Entries[1]
                },
                new Training
                {
                    Id = TrainingIds[2],
                    DateHeld = new DateTime(2020, 12, 2),
                    Location = EventLocationSeed.Entries[2],
                    TrainingType = TrainingType.Hiking,
                    Participants = EventParticipationSeed.Entries[2]
                },
                new Training
                {
                    Id = TrainingIds[3],
                    DateHeld = new DateTime(2021, 4, 30),
                    Location = EventLocationSeed.Entries[3],
                    TrainingType = TrainingType.Match,
                    Participants = EventParticipationSeed.Entries[3]
                },
            };
        }
    }
}
