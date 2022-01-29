using System;

namespace AskerTracker.Infrastructure.Extensions;

static class GuidExtensions
{
    private static readonly int[] GuidByteOrder =
        new[] { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };
    public static Guid Increment(this Guid guid)
    {
        var bytes = guid.ToByteArray();
        bool carry = true;
        for (int i = 0; i < GuidByteOrder.Length && carry; i++)
        {
            int index = GuidByteOrder[i];
            byte oldValue = bytes[index]++;
            carry = oldValue > bytes[index];
        }
        return new Guid(bytes);
    }
}