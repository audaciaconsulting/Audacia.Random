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
        public void NextGaussian()
        {
            var mu = new System.Random().Next();
            var sigma = new System.Random().NextDouble();
            
            var numbers = Enumerable.Range(0, 1000).Select(_ => Random.NextGaussian(mu, sigma)).ToList();

            
            var average = numbers.Average();
            var stDev = numbers.Average(n => Math.Abs(n - mu));
            Output.WriteLine($"Average: {average}");
            Output.WriteLine($"Standard deviation: {stDev}");

            // Since normally distributed, there will always be a small error
            var tolerance = 0.1d * sigma;
            Assert.True(average - mu <= tolerance);
            Assert.True(stDev - sigma <= tolerance);
        }
    }
}