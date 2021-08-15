using System;
using System.Collections.Generic;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public static class MemberSeed
    {
        public static List<Guid> MemberIds = new List<Guid>()
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
            new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3319")
        };

        public static List<Member> Entries = new()
            {
                new Member
                {
                    Id = MemberIds[0],
                    FirstName = "Adi",
                    LastName = "Pandžić",
                    Nickname = "Pax",
                    PhoneNumber = "+38761205345",
                    JMBG = "2301990170069",
                    BirthDate = new DateTime(1990, 1, 23),
                    BloodType = BloodType.BPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = true,
                    Fees = new HashSet<MembershipFee>() {
                        MembershipFeesSeed.Entries[0],
                        MembershipFeesSeed.Entries[1],
                        MembershipFeesSeed.Entries[2],
                        MembershipFeesSeed.Entries[3],
                }
                },
                new Member
                {
                    Id = MemberIds[1],
                    FirstName = "Vahid",
                    LastName = "Avdić",
                    Nickname = "Vaha",
                    PhoneNumber = "+38761908478",
                    JMBG = "1811985120015",
                    BirthDate = new DateTime(1985, 11, 18),
                    BloodType = BloodType.OPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = false,
                    Fees = new HashSet<MembershipFee>() {
                        MembershipFeesSeed.Entries[4],
                        MembershipFeesSeed.Entries[5],
                        MembershipFeesSeed.Entries[6],
                        MembershipFeesSeed.Entries[7],
                }
                },
                new Member
                {
                    Id = MemberIds[2],
                    FirstName = "Adnan",
                    LastName = "Zukanović",
                    Nickname = "Zuka",
                    PhoneNumber = "+38762704712",
                    JMBG = "2505995180032",
                    BirthDate = new DateTime(1995, 5, 25),
                    BloodType = BloodType.OPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = false,
                    Fees = new HashSet<MembershipFee>() {
                        MembershipFeesSeed.Entries[8],
                        MembershipFeesSeed.Entries[9],
                        MembershipFeesSeed.Entries[10],
                        MembershipFeesSeed.Entries[11],
                }
                },
                new Member
                {
                    Id = MemberIds[3],
                    FirstName = "Amar",
                    LastName = "Begluk",
                    PhoneNumber = "+38761564937",
                    JMBG = "1610990170009",
                    BirthDate = new DateTime(1990, 1, 16),
                    BloodType = BloodType.BPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = true,
                    Fees = new HashSet<MembershipFee>() {
                        MembershipFeesSeed.Entries[12],
                        MembershipFeesSeed.Entries[13],
                        MembershipFeesSeed.Entries[14],
                        MembershipFeesSeed.Entries[15],
                }
                },
                new Member
                {
                    Id = MemberIds[4],
                    FirstName = "Eldar",
                    LastName = "Alić",
                    Nickname = "Ibn Huso",
                    PhoneNumber = "+38762369857",
                    JMBG = "2905990192197",
                    BirthDate = new DateTime(1990, 5, 29),
                    BloodType = BloodType.APositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = false,
                    Fees = new HashSet<MembershipFee>() {
                        MembershipFeesSeed.Entries[16],
                        MembershipFeesSeed.Entries[17],}
                },
                new Member
                {
                    Id = MemberIds[5],
                    FirstName = "Adnan",
                    LastName = "Šupić",
                    Nickname = "chupe",
                    PhoneNumber = "+38761355800",
                    JMBG = "0110990170029",
                    BirthDate = new DateTime(1990, 10, 1),
                    BloodType = BloodType.BPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = true
                },
                new Member
                {
                    Id = MemberIds[6],
                    FirstName = "Abudim",
                    LastName = "Šurković",
                    Nickname = "Romantic",
                    PhoneNumber = "+38761444434",
                    JMBG = "0109983100040",
                    BirthDate = new DateTime(1993, 9, 1),
                    BloodType = BloodType.OPositive,
                    DateJoined = new DateTime(2018, 4, 20),
                    Active = true
                },
                new Member
                {
                    Id = MemberIds[7],
                    FirstName = "Emir",
                    LastName = "Ribić",
                    Nickname = "Riba",
                    PhoneNumber = "+38761927027",
                    JMBG = "1511991102009",
                    BirthDate = new DateTime(1991, 11, 15),
                    DateJoined = new DateTime(2020, 6, 23),
                    Active = true
                },
                new Member
                {
                    Id = MemberIds[8],
                    FirstName = "Damir",
                    LastName = "Prljača",
                    Nickname = "Shumar",
                    PhoneNumber = "+38761408293",
                    JMBG = "1704992174995",
                    BirthDate = new DateTime(1992, 4, 17),
                    BloodType = BloodType.APositive,
                    DateJoined = new DateTime(2020, 5, 29),
                    Active = true
                },
                new Member
                {
                    Id = MemberIds[9],
                    FirstName = "Muhamed",
                    LastName = "Kalajdžisalihović",
                    PhoneNumber = "+38761257903",
                    JMBG = "2404986170120",
                    BirthDate = new DateTime(1986, 4, 24),
                    BloodType = BloodType.BPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = true
                }
            };
    }
}
