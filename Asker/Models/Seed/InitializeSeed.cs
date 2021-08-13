using Asker.Data;
using Asker.Models;
using Asker.Models.Seed.Data;
using Asker.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Asker.Models.Seed
{
    public static class InitializeSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Member.Any())
                    return;
                else
                    context.Member.AddRange(MemberSeed.Entries);

                if (context.Item.Any())
                    return;
                else
                    context.Item.AddRange(ItemSeed.Entries);

                if (context.EventLocation.Any())
                    return;
                else
                    context.EventLocation.AddRange(EventLocationSeed.Entries);

                if (context.EventParticipation.Any())
                    return;
                else
                    context.EventParticipation.AddRange(EventParticipationSeed.Entries);

                if (context.Training.Any())
                    return;
                else
                    context.Training.AddRange(TrainingSeed.Entries());

                if (context.TestingEvent.Any())
                    return;
                else
                    context.TestingEvent.AddRange(TestingEventSeed.Entries());

                if (context.TestingResult.Any())
                    return;
                else
                    context.TestingResult.AddRange(TestingResultSeed.Entries());

                context.SaveChanges();
            }
        }
    }
}