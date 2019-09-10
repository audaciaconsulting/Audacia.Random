using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Audacia.Random
{
    public static class TestData
    {
        public static ICollection<string> Cities { get; } = List("Audacia.Random.Cities");

        public static ICollection<string> Counties { get; } = List("Audacia.Random.Counties");

        public static ICollection<string> MaleNames { get; } = List("Audacia.Random.Forenames.Male");

        public static ICollection<string> FemaleNames { get; } = List("Audacia.Random.Forenames.Female");

        public static ICollection<string> Surnames { get; } = List("Audacia.Random.Surnames");

        public static ICollection<string> Streets { get; } = List("Audacia.Random.Streets");

        public static ICollection<string> Companies { get; } = List("Audacia.Random.Companies");

        public static ICollection<string> Sentences { get; } = List("Audacia.Random.Sentences");
        
        public static ICollection<string> Nouns { get; } = List("Audacia.Random.Nouns");

        private static ICollection<string> List(string name)
        {
            using (var textStreamReader = Reader(name))
            {
                return textStreamReader.ReadToEnd()
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
            }
        }

        private static StreamReader Reader(string name) => new StreamReader(Resource(name));

        private static Stream Resource(string name) => Assembly.GetManifestResourceStream(name);

        private static Assembly Assembly => typeof(TestData).GetTypeInfo().Assembly;
    }
}