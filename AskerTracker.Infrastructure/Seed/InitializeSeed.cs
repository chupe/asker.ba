using System;
using System.Linq;
using AskerTracker.Domain;
using AskerTracker.Domain.Types;
using AskerTracker.Infrastructure.Seed.Data;
using Microsoft.AspNetCore.Identity;

namespace AskerTracker.Infrastructure.Seed
{
    public static class InitializeSeed
    {
        public static void Initialize(AskerTrackerDbContext context)
        {
            if (!context.Users.Any())
                context.Users.Add(new Member
                {
                    Id = new Guid("3F2504E0-4F89-11D3-1111-0305E82C3310"),
                    SecurityStamp = new Guid("3F2504E0-4F89-11D3-1111-0305E82C3310").ToString(),
                    UserName = "test@mail.com",
                    NormalizedUserName = "test@mail.com".ToUpper(),
                    Email = "test@mail.com",
                    NormalizedEmail = "test@mail.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEOTEyyOUzF9naa3SZ/NuS96pbcFnLkwlulh0u9VZFcidVKP8fGPZKLkRt/ZFyFpzjg==",
                    FirstName = "Test",
                    LastName = "Test",
                    PhoneNumber = "+38761205350",
                    JMBG = "2301990170070",
                    BirthDate = new DateTime(1990, 1, 23),
                    BloodType = BloodType.BPositive,
                    DateJoined = new DateTime(2016, 10, 19),
                    Active = true
                });

            if (!context.Members.Any())
                context.Members.AddRange(MemberSeed.Entries);
            
            if (!context.MembershipFees.Any())
                context.MembershipFees.AddRange(MembershipFeeSeed.Entries);
            
            if (!context.Items.Any())
                context.Items.AddRange(ItemSeed.Entries);

            if (!context.EventLocations.Any())
                context.EventLocations.AddRange(EventLocationSeed.Entries);

            if (!context.Trainings.Any())
                context.Trainings.AddRange(TrainingSeed.Entries());

            if (!context.TestingEvents.Any())
                context.TestingEvents.AddRange(TestingEventSeed.Entries());

            if (!context.TestingResults.Any())
                context.TestingResults.AddRange(TestingResultSeed.Entries());

            context.SaveChanges();
        }
    }
}