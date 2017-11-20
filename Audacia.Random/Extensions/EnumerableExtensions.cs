using System;
using System.Collections.Generic;

namespace Audacia.Random.Extensions
{
    public static class EnumerableExtensions
    {
        // Prevent concurrency issues
        private static Lazy<System.Random> _random = new Lazy<System.Random>();

        public static T Random<T>(this ICollection<T> source) => _random.Value.Element(source);

        public static IEnumerable<T> Random<T>(this IList<T> source, int count) => _random.Value.Elements(source, count);

        public static IEnumerable<T> Random<T>(this IList<T> source, int min, int max) => _random.Value.Elements(source, min, max);
    }
}
