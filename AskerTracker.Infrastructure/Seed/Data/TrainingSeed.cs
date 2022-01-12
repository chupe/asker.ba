using System;
using System.Collections.Generic;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;

namespace AskerTracker.Infrastructure.Seed.Data;

public static class TrainingSeed
{
    private static readonly List<Guid> TrainingIds = new()
    {
        new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3300"),
        new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
        new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3302"),
        new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3303")
    };

    public static List<Training> Entries()
    {
        return new List<Training>
        {
            new()
            {
                Id = TrainingIds[0],
                DateHeld = new DateTime(2018, 10, 2),
                TrainingType = TrainingType.Internal,
                Location = EventLocationSeed.Entries[0],
                Participants = new HashSet<Member>
                {
                    MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                    MemberSeed.Entries[5],
                    MemberSeed.Entries[6],
                    MemberSeed.Entries[7],
                    MemberSeed.Entries[8]
                }
            },
            new()
            {
                Id = TrainingIds[1],
                DateHeld = new DateTime(2019, 1, 26),
                Location = EventLocationSeed.Entries[1],
                TrainingType = TrainingType.Cooperation,
                Participants = new HashSet<Member>
                {
                    MemberSeed.Entries[0],
                    MemberSeed.Entries[1],
                    MemberSeed.Entries[2],
                    MemberSeed.Entries[4],
                    MemberSeed.Entries[5],
                    MemberSeed.Entries[6],
                    MemberSeed.Entries[8],
                    MemberSeed.Entries[9]
                }
            },
            new()
            {
                Id = TrainingIds[2],
                DateHeld = new DateTime(2020, 12, 2),
                Location = EventLocationSeed.Entries[2],
                TrainingType = TrainingType.Hiking,
                Participants = new HashSet<Member>
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
            new()
            {
                Id = TrainingIds[3],
                DateHeld = new DateTime(2021, 7, 30),
                Location = EventLocationSeed.Entries[3],
                TrainingType = TrainingType.Match,
                Participants = new HashSet<Member>
                {
                    MemberSeed.Entries[1],
                    MemberSeed.Entries[2],
                    MemberSeed.Entries[3],
                    MemberSeed.Entries[4],
                    MemberSeed.Entries[5]
                }
            }
        };
    }
}