using System;
using System.Collections.Generic;
using AskerTracker.Core;

namespace AskerTracker.Data.Seed.Data
{
    public class MembershipFeesSeed
    {
        public static List<MembershipFee> Entries = new()
        {
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 10, 2),
                MemberId = MemberSeed.MemberIds[0],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 11, 2),
                MemberId = MemberSeed.MemberIds[0],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 12, 2),
                MemberId = MemberSeed.MemberIds[0],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2019, 1, 2),
                MemberId = MemberSeed.MemberIds[0],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 10, 2),
                MemberId = MemberSeed.MemberIds[1],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 11, 2),
                MemberId = MemberSeed.MemberIds[1],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 12, 2),
                MemberId = MemberSeed.MemberIds[1],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2019, 1, 2),
                MemberId = MemberSeed.MemberIds[1],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2021, 4, 2),
                MemberId = MemberSeed.MemberIds[2],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2021, 5, 2),
                MemberId = MemberSeed.MemberIds[2],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2021, 6, 2),
                MemberId = MemberSeed.MemberIds[2],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2021, 7, 2),
                MemberId = MemberSeed.MemberIds[2],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2020, 10, 2),
                MemberId = MemberSeed.MemberIds[3],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2020, 11, 2),
                MemberId = MemberSeed.MemberIds[3],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2020, 12, 2),
                MemberId = MemberSeed.MemberIds[3],
                Amount = 10
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2021, 1, 2),
                MemberId = MemberSeed.MemberIds[3],
                Amount = 100
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 10, 2),
                MemberId = MemberSeed.MemberIds[4],
                Amount = 100
            },
            new MembershipFee
            {
                TransactionDate = new DateTime(2018, 10, 2),
                MemberId = MemberSeed.MemberIds[4],
                Amount = 200
            }
        };
    }
}