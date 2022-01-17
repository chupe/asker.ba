using System;

namespace AskerTracker.Infrastructure.Seed;

public class BogusConfiguration
{
    public static DateTime MinDate = new DateTime(1990, 1, 1);
    public static DateTime MaxDate = new DateTime(2022, 1, 1);

    public static Random Random = new Random(123456);
    public static Guid StartId = new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3310");
}