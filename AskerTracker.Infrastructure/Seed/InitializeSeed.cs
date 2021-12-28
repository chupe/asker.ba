using System;
using System.Linq;
using AskerTracker.Infrastructure.Seed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AskerTracker.Infrastructure.Seed
{
    public static class InitializeSeed
    {
        public static void Initialize(AskerTrackerDbContext context)
        {
            if (!context.Users.Any())
                context.Users.Add(new IdentityUser
                {
                    UserName = "test@mail.com",
                    NormalizedUserName = "test@mail.com".ToUpper(),
                    Email = "test@mail.com",
                    NormalizedEmail = "test@mail.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEOTEyyOUzF9naa3SZ/NuS96pbcFnLkwlulh0u9VZFcidVKP8fGPZKLkRt/ZFyFpzjg=="
                });
                
            if (!context.Member.Any())
                context.Member.AddRange(MemberSeed.Entries);

            if (!context.Item.Any())
                context.Item.AddRange(ItemSeed.Entries);

            if (!context.EventLocation.Any())
                context.EventLocation.AddRange(EventLocationSeed.Entries);

            if (!context.Training.Any())
                context.Training.AddRange(TrainingSeed.Entries());

            if (!context.TestingEvent.Any())
                context.TestingEvent.AddRange(TestingEventSeed.Entries());

            if (!context.TestingResult.Any())
                context.TestingResult.AddRange(TestingResultSeed.Entries());

            context.SaveChanges();
        }
    }
}