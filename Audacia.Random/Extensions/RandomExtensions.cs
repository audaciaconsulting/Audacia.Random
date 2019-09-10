using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Audacia.Random.Extensions
{
    [SuppressMessage("ReSharper", "CA1720")]
    public static class RandomExtensions
    {
        public static bool Boolean(this System.Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            return random.Next(0, 2).Equals(0);
        }

        public static DateTime DateTime(this System.Random random)
            => random.DateTime(
                System.DateTime.Now.AddYears(-1),
                System.DateTime.Now.AddYears(1));

        public static DateTime DateTimeFrom(this System.Random random, DateTime from) =>
            random.DateTime(from, from.AddYears(1));
        
        public static DateTime DateTimeTo(this System.Random random, DateTime to) =>
            random.DateTime(to.AddYears(-1), to);

        public static DateTime DateTime(this System.Random random, DateTime from, DateTime to)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var totalSeconds = (to - from).TotalSeconds;
            var randomSeconds = random.Next(Convert.ToInt32(totalSeconds));
            return from.AddSeconds(randomSeconds);
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> items, int count) =>
            items.OrderBy(x => Guid.NewGuid()).Take(count);

        public static IEnumerable<T> ShuffleElements<T>(this System.Random random, IEnumerable<T> items)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var list = items.ToList();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static T Enum<T>(this System.Random random)
        {
            var values = System.Enum.GetValues(typeof(T)).OfType<object>().ToList();
            var value = random.Element(values);
            return (T)value;
        }

        public static IEnumerable<T> Elements<T>(this System.Random random, IList<T> items, int count)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var list = new List<T>(items);
            for (var i = count; i > 0; i--)
            {
                var index = random.Next(0, list.Count);
                yield return list[index];
                list.RemoveAt(index);
            }
        }

        public static IEnumerable<T> Elements<T>(this System.Random random, IList<T> items, int min, int max)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var count = random.Next(min, max);
            return random.Elements(items, count);

        }

        public static string String(this System.Random random, int length)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var chars = random.Chars(length);
            return new string(chars);
        }

        public static char[] Chars(this System.Random random, int count)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            return Enumerable.Range(0, count)
                .Select(_ => random.Char())
                .ToArray();
        }

        public static char Char(this System.Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var num = random.Next(0, 26); // Zero to 25
            return (char)('a' + num);
        }

        public static string Digits(this System.Random random, int count)
        {
            var chars = Enumerable.Range(0, count)
                .Select(_ => random.Digit())
                .ToArray();

            return new string(chars);
        }

        public static string MobileNumber(this System.Random random)
        {
            return $"07{random.Digits(9)}";
        }

        public static char Digit(this System.Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            return random.Next(0, 10)
                .ToString(NumberFormatInfo.InvariantInfo)
                .ToCharArray()
                .Single();
        }

        public static DateTime Birthday(this System.Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            return System.DateTime.Now.AddYears(-18).AddDays(-random.Next(0, 30000));
        }
        
        public static T Element<T>(this System.Random random, ICollection<T> items)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            if (items == null) throw new ArgumentNullException(nameof(items));

            var index = random.Next(0, items.Count - 1);
            return items.ElementAt(index);
        }

        public static long Long(System.Random rand)
        {
            if (rand == null) throw new ArgumentNullException(nameof(rand));
            return rand.Long(0, long.MaxValue);
        }

        public static long Long(this System.Random rand, long max)
        {
            if (rand == null) throw new ArgumentNullException(nameof(rand));
            return rand.Long(0, max);
        }

        public static long Long(this System.Random rand, long min, long max)
        {
            if (rand == null) throw new ArgumentNullException(nameof(rand));
            
            var buf = new byte[8];
            rand.NextBytes(buf);
            var longRand = BitConverter.ToInt64(buf, 0);
            return Math.Abs(longRand % (max - min)) + min;
        }

        public static string PostCode(this System.Random random) =>
            $"{new string(random.Chars(2))}{random.Digits(2)} {random.Digit()}{new string(random.Chars(2))}"
                .ToUpperInvariant();

        /// <summary>Organises the specified collection into multiple smaller collections of variable size.</summary>
        public static IEnumerable<IEnumerable<T>> Chunks<T>(this System.Random random, IEnumerable<T> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            var chunks = Enumerable.Range(0, count).Select(_ => new List<T>()).ToList();

            foreach (var element in source)
                random.Element(chunks).Add(element);

            return chunks;
        }
        
        /// <summary>Splits the specified integer into a collection of smaller integers who's total sum equals the source value.</summary>
        public static IEnumerable<int> Chunks(this System.Random random, int source, int count)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            
            var chunks = Enumerable.Range(0, count).Select(_ => 0).ToList();

            for (var i = 0; i < source; i++)
            {
                var index = random.Next(0, chunks.Count - 1);
                chunks[index]++;
            }
            
            return chunks;
        }
            
        public static string City(this System.Random random) => random.Element(TestData.Cities);

        public static string County(this System.Random random) => random.Element(TestData.Counties);

        public static string MaleForename(this System.Random random) => random.Element(TestData.MaleNames);

        public static string FemaleForename(this System.Random random) => random.Element(TestData.FemaleNames);

        public static string Surname(this System.Random random) => random.Element(TestData.Surnames);

        public static string Street(this System.Random random) => random.Element(TestData.Streets);

        public static string Company(this System.Random random) => random.Element(TestData.Companies);

        public static string Sentence(this System.Random random) => random.Element(TestData.Sentences);

        public static string Word(this System.Random random) => random.Element(TestData.Nouns);
        
        public static string Words(this System.Random random,  int count)
        {
            var words = Enumerable.Range(0, count).Select(_ => random.Element(TestData.Nouns));
            return string.Join(" ", words);
        }
    }
}
