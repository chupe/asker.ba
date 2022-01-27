using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Seed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AskerTracker.Infrastructure.Seed;

public static class InitializeSeed
{
    public static async Task Initialize(AskerTrackerDbContext context, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Member>>();

        if (!context.Members.Any())
            context.Members.Add(new Member
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
            var fakeMembers = MemberSeed.FakeMembers();
            var fakeFees = MembershipFeeSeed.FakeFees(fakeMembers);
            var fakeItems = ItemSeed.FakeItems(fakeMembers);
            var fakeLocations = EventLocationSeed.FakeLocations();
            var fakeTestingEvents = TestingEventSeed.FakeTestingEvent(fakeMembers, fakeLocations);
            var fakeTrainings = TrainingSeed.FakeTrainings(fakeMembers, fakeLocations);
            var fakeTestingResults = TestingResultSeed.FakeResults(fakeTestingEvents);

            async Task Action(Member m) => await userManager.CreateAsync(m, "123qwE!");
            fakeMembers.ForEach(m => Action(m).Wait());

            if (!context.EventLocations.Any())
                context.EventLocations.AddRange(fakeLocations);

            if (!context.MembershipFees.Any())
                context.MembershipFees.AddRange(fakeFees);

            if (!context.Items.Any())
                context.Items.AddRange(fakeItems);

            if (!context.Trainings.Any())
                context.Trainings.AddRange(fakeTrainings);

            if (!context.TestingEvents.Any())
                context.TestingEvents.AddRange(fakeTestingEvents);

            if (!context.TestingResults.Any())
                context.TestingResults.AddRange(fakeTestingResults);
        }

        await context.SaveChangesAsync();
    }
}