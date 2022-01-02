using System.Linq;

namespace AskerTracker.Common.Extensions;

public static class StringExtensions
{
    public static string ToRelativePath(this string absolutePath, int skip = 3)
    {
        return string.Join("/", absolutePath.Split("/").Skip(skip).Prepend("~"));
    }

}