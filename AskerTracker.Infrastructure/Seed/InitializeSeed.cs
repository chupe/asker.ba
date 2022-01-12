using System;
using System.Linq;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Seed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AskerTracker.Infrastructure.Seed;

public static class InitializeSeed
{
    public static void Initialize(AskerTrackerDbContext context, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Member>>();
        
        if (!context.Users.Any())
            context.Users.Add(new Member
            {
                Id = new Guid("77cab71a-cc5b-470d-b043-2e8533a184a2"),
                ConcurrencyStamp = "6f0e6778-37bd-47c5-8b32-2eeba9130e87",
                Email = "admin@mail.com",
                FirstName = "Admin",
                JMBG = "9876543210321",
                LastName = "Admin",
                NormalizedEmail = "ADMIN@MAIL.COM",
                NormalizedUserName = "ADMIN@MAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKV/90Z/YzwprNKMw43E9wWyG9I4a6tgqLKYnU6MLrddQp3EaSo5LMycf1n75/IbSQ==",
                PhoneNumber = "987654321",
                SecurityStamp = "O2KRY5BBIAX3RPO5OZBZWM7CRAKGHMZY",
                UserName = "admin@mail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            });

        if (!context.Members.Any())
        {
            var i = 0;
            async void Action(Member m)
            {
                m.Email = $"test{i++}@mail.com";
                m.UserName = m.FullName.Replace(" ", "");
                Console.WriteLine(m.UserName);
                await userManager.CreateAsync(m, "123qwE!");
            }

            MemberSeed.Entries.ForEach(Action);
        }
        // context.Members.AddRange(MemberSeed.Entries);

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