using System;
using System.Collections.Generic;
using Asker.Types;

namespace Asker.Models.Seed.Data
{
    public static class ItemSeed
    {
        public static List<Item> Entries = new()
        {
            new Item
            {
                Name = "Suunto MS2G",
                Description = "Kompas",
                Comment = "Za snalazenje u prirodi",
                OwnerId = MemberSeed.Entries[0].Id,
                LenderId = MemberSeed.Entries[1].Id,
                Amount = 1,
                Value = 100.5,
                IsTeamProperty = false
            },
            new Item
            {
                Name = "Pentagon MSRP",
                Description = "Rusak, 65l",
                Comment = "U dobrom stanju",
                LenderId = MemberSeed.Entries[2].Id,
                Amount = 2,
                Value = 399.99,
                IsTeamProperty = true
            },
            new Item
            {
                Name = "WAS Recon plate carrier",
                Description = "Prsluk",
                Comment = "youtube.com",
                OwnerId = MemberSeed.Entries[3].Id,
                LenderId = MemberSeed.Entries[4].Id,
                Amount = 1,
                Value = 600.999,
                IsTeamProperty = false
            }
        };
    }
}
