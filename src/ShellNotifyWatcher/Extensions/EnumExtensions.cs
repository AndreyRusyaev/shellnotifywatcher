using System.Collections.Generic;

namespace ShellSpy.Extensions
{
    internal static class EnumExtensions
    {
        public static bool IsOneOf<T>(this T item, params T[] cases)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            foreach (var @case in cases)
            {
                if (equalityComparer.Equals(item, @case))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
