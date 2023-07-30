using System;
using System.Collections.Generic;
using System.Linq;
using Audacia.Random.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Audacia.Random.Tests
{
    public class RandomExtensionsTests
    {
        public RandomExtensionsTests(ITestOutputHelper output) => Output = output;

        protected ITestOutputHelper Output { get; }
        protected System.Random Random { get; } = new System.Random();
        
        [Fact]
        public void Word()
        {
            var word = Random.Word();
            Output.WriteLine("Word: " + word);
            
            Assert.NotEmpty(word);
        }
        
        [Fact]
        public void Words()
        {
            var words = Random.Words(3);
            Output.WriteLine("Words: " + words);
            
            Assert.True(words.Count(c => c == ' ') == 2);
            Assert.NotEmpty(words);
        }
        
        [Fact]
        public void Postcode()
        {
            var postCode = Random.PostCode();
            Output.WriteLine("Postcode: " + postCode);
            
            Assert.True(postCode.Count(c => c == ' ') == 1);
            Assert.NotEmpty(postCode);
        }
        
        [Fact]
        public void EmailAddress()
        {
            var emailAddress = Random.EmailAddress();
            Output.WriteLine("Email address: " + emailAddress);

            Assert.NotEmpty(emailAddress);
        }

        [Fact]
        public void TimeSpan()
        {
            var timeSpan = Random.TimeSpan(System.TimeSpan.Zero, System.TimeSpan.FromMinutes(1));
            Output.WriteLine("Timespan: " + timeSpan);

            Assert.InRange(timeSpan, System.TimeSpan.Zero, System.TimeSpan.FromMinutes(1));
        }

        [Fact]
        public void NextGaussian()
        {
            const int mu = 100;
            const double sigma = 5;
            
            // Generated 1000 normally-distributed numbers
            var numbers = Enumerable.Range(0, 1000).Select(_ => Random.NextGaussian(mu, sigma)).ToList();

            var actualMu = numbers.Average();
            var actualSigma = numbers.Average(number => Math.Abs(number - mu));
            Output.WriteLine($"Average: {actualMu}");
            Output.WriteLine($"Standard deviation: {actualSigma}");

            // Since normally distributed, there will always be a small error
            var tolerance = 0.1d * sigma;
            Assert.True(actualMu - mu <= tolerance);
            Assert.True(actualSigma - sigma <= tolerance);
        }
    }
}