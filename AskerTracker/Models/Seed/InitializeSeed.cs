﻿using AskerTracker.Data;
using AskerTracker.Models;
using AskerTracker.Models.Seed.Data;
using AskerTracker.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AskerTracker.Models.Seed
{
    public static class InitializeSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
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
}