﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskerTracker.Models.Seed.Data
{
    public class EventLocationSeed
    {
        public static List<EventLocation> Entries = new()
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
            },
        };
    }
}