using System;
using System.Collections.Generic;
using System.Linq;

namespace Audacia.Random.Extensions
{
    public static class EnumerableExtensions
    {
        // Prevent concurrency issues
        private static Lazy<System.Random> _random = new Lazy<System.Random>();
        
        public static T Random<T>(this IEnumerable<T> source) => source.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

        public static IEnumerable<T> Random<T>(this IEnumerable<T> source, int count) => source.OrderBy(x => Guid.NewGuid()).Take(count);
        
        public static IEnumerable<T> Random<T>(this IList<T> source, int min, int max) => _random.Value.Elements(source, min, max);
    }
}
