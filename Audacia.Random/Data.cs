using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Audacia.Random
{
    internal static class Data
    {
        public static string[] Cities { get; } = List("Audacia.Random.Cities");

        public static string[] Counties { get; } = List("Audacia.Random.Counties");

        public static string[] MaleNames { get; } = List("Audacia.Random.Forenames.Male");

        public static string[] FemaleNames { get; } = List("Audacia.Random.Forenames.Female");

        public static string[] Surnames { get; } = List("Audacia.Random.Surnames");

        public static string[] Streets { get; } = List("Audacia.Random.Streets");

        public static string[] Companies { get; } = List("Audacia.Random.Companies");


        private static string[] List(string name)
        {
            using (var textStreamReader = Reader(name))
                return textStreamReader.ReadToEnd()
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                    .ToArray();
        }

        private static StreamReader Reader(string name) => new StreamReader(Resource(name));

        private static Stream Resource(string name) => Assembly.GetManifestResourceStream(name);

        private static Assembly Assembly => typeof(Data).GetTypeInfo().Assembly;
    }
}