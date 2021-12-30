﻿using System.Collections.Generic;
using AskerTracker.Domain;

namespace AskerTracker.Infrastructure.Seed.Data
{
    public static class EventLocationSeed
    {
        public static readonly List<EventLocation> Entries = new()
        {
            new EventLocation
            {
                Location = "Igman Hotel"
            },
            new EventLocation
            {
                Location = "Kovacki stan"
            },
            new EventLocation
            {
                Location = "Prenj"
            },
            new EventLocation
            {
                Location = "Lasicki stan"
            },
            new EventLocation
            {
                Location = "centar Safet Zajko"
            },
            new EventLocation
            {
                Location = "Zenica, Lastavica"
            }
        };
    }
}