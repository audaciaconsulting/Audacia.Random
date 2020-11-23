using System;
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
    }
}
