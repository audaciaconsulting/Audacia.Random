using System;
using System.Linq;
using Audacia.Random.Extensions;
using MarkovSharp.TokenisationStrategies;

namespace Audacia.Random.Markov
{
    public static class RandomExtensions
    {
        private static StringMarkov StringMarkov => LazyStringMarkov.Value;
        private static readonly Lazy<StringMarkov> LazyStringMarkov = new Lazy<StringMarkov>(() =>
        {
            var value = new StringMarkov(1);
            value.Learn(Data.Sentences);
            return value;
        });

        public static string Words(this System.Random random) => StringMarkov.Walk().Single();
    }
}
