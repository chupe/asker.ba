using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asker.Common.Extensions;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public class MembershipFeesSeed
    {
        public static List<Guid> FeeId = new List<Guid>()
        {
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3310"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3311"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3312"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3313"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3314"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3315"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3316"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3317"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3318"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3319"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3320"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3321"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3322"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3323"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3324"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3325"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3326"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3327"),
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3328"),
        };

        public static List<MembershipFee> Entries()
        {
            return new()
            {
                new MembershipFee
                {
                    Id = FeeId[0],
                    TransactionDate = new DateTime(2018, 10, 2),
                    Member = MemberSeed.Entries[0],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[1],
                    TransactionDate = new DateTime(2018, 11, 2),
                    Member = MemberSeed.Entries[0],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[2],
                    TransactionDate = new DateTime(2018, 12, 2),
                    Member = MemberSeed.Entries[0],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[3],
                    TransactionDate = new DateTime(2019, 1, 2),
                    Member = MemberSeed.Entries[0],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[4],
                    TransactionDate = new DateTime(2018, 10, 2),
                    Member = MemberSeed.Entries[1],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[5],
                    TransactionDate = new DateTime(2018, 11, 2),
                    Member = MemberSeed.Entries[1],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[6],
                    TransactionDate = new DateTime(2018, 12, 2),
                    Member = MemberSeed.Entries[1],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[7],
                    TransactionDate = new DateTime(2019, 1, 2),
                    Member = MemberSeed.Entries[1],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[8],
                    TransactionDate = new DateTime(2021, 4, 2),
                    Member = MemberSeed.Entries[2],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[9],
                    TransactionDate = new DateTime(2021, 5, 2),
                    Member = MemberSeed.Entries[2],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[10],
                    TransactionDate = new DateTime(2021, 6, 2),
                    Member = MemberSeed.Entries[2],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[11],
                    TransactionDate = new DateTime(2021, 7, 2),
                    Member = MemberSeed.Entries[2],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[12],
                    TransactionDate = new DateTime(2020, 10, 2),
                    Member = MemberSeed.Entries[3],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[13],
                    TransactionDate = new DateTime(2020, 11, 2),
                    Member = MemberSeed.Entries[3],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[14],
                    TransactionDate = new DateTime(2020, 12, 2),
                    Member = MemberSeed.Entries[3],
                    Amount = 10
                },
                new MembershipFee
                {
                    Id = FeeId[15],
                    TransactionDate = new DateTime(2021, 1, 2),
                    Member = MemberSeed.Entries[3],
                    Amount = 100
                },
                new MembershipFee
                {
                    Id = FeeId[16],
                    TransactionDate = new DateTime(2018, 10, 2),
                    Member = MemberSeed.Entries[4],
                    Amount = 100
                },
                new MembershipFee
                {
                    Id = FeeId[17],
                    TransactionDate = new DateTime(2018, 10, 2),
                    Member = MemberSeed.Entries[4],
                    Amount = 200
                },
            };
        }
    }
}
