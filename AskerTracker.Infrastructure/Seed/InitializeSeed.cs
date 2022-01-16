using System;
using System.Linq;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Infrastructure.Seed.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AskerTracker.Infrastructure.Seed;

public static class InitializeSeed
{
    public static async Task Initialize(AskerTrackerDbContext context, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Member>>();

        if (!context.Members.Any())
        {
            var i = 0;
            async Task Action(Member m)
            {
                m.Email = $"test{i++}@mail.com";
                m.UserName = m.Email;
                m.EmailConfirmed = true;
                m.PhoneNumberConfirmed = true;
                Console.WriteLine(m.UserName);
                await userManager.CreateAsync(m, "123qwE!");
            }

            MemberSeed.Entries.ForEach(m => Action(m).Wait());
        }

        // if (!context.MembershipFees.Any())
        //     context.MembershipFees.AddRange(MembershipFeeSeed.Entries);

        // if (!context.Items.Any())
        //     context.Items.AddRange(ItemSeed.Entries);
        
        // if (!context.EventLocations.Any())
        //     context.EventLocations.AddRange(EventLocationSeed.Entries);
        //
        // if (!context.Trainings.Any())
        //     context.Trainings.AddRange(TrainingSeed.Entries());
        //
        // if (!context.TestingEvents.Any())
        //     context.TestingEvents.AddRange(TestingEventSeed.Entries());
        //
        // if (!context.TestingResults.Any())
        //     context.TestingResults.AddRange(TestingResultSeed.Entries());

        await context.SaveChangesAsync();
    }
}