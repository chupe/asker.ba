using System;
using System.Linq;

namespace AskerTracker.Web.Common.Extensions;

public static class StringExtensions
{
    public static string ToRelativePath(this string absolutePath, int skip = 3)
    {
        absolutePath = $"/{string.Join("/", absolutePath.Split("/").Skip(skip))}";
        return absolutePath;
    }
    
    public static Guid ToGuid(this string input)
    {
        return new Guid(input);
    }
}