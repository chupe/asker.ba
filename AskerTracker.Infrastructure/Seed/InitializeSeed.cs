using System;
using System.Linq;
using AskerTracker.Infrastructure.Seed.Data;
using Microsoft.AspNetCore.Identity;

namespace AskerTracker.Infrastructure.Seed;

public static class InitializeSeed
{
    public static void Initialize(AskerTrackerDbContext context)
    {
        if (!context.Users.Any())
            context.Users.Add(new IdentityUser
            {
                Id = "77cab71a-cc5b-470d-b043-2e8533a184a2",
                UserName = "test@mail.com",
                NormalizedUserName = "test@mail.com".ToUpper(),
                Email = "test@mail.com",
                NormalizedEmail = "test@mail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash =
                    "AQAAAAEAACcQAAAAEOTEyyOUzF9naa3SZ/NuS96pbcFnLkwlulh0u9VZFcidVKP8fGPZKLkRt/ZFyFpzjg=="
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