using Domain.Extentions;
using Domain.Models;
using Domain.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Testing
{
    public class UnitTest
    {
        [Fact]
        public void CollectionShouldReturnSomeWhenKeyFound()
        {
            var collection = new NameValueCollection
            {
                { "green", "vert" }
            };
            var result = collection.Lookup("green");
            Assert.Equal("vert", result.ToString());
        }

        [Fact]
        public void CollectionShouldReturnNoneWhenKeyNotFound()
        {
            var result = new NameValueCollection().Lookup("green");
            Assert.Equal("None", result.ToString());
        }

        [Fact]
        public void DictionaryShouldReturnSomeWhenKeyFound()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "green", "vert" }
            };
            var result = dictionary.Lookup("green");
            Assert.Equal("vert", result.ToString());
        }

        [Fact]
        public void DictionaryShouldReturnNoneWhenNoKeyFound()
        {
            var result = new Dictionary<string, string>().Lookup("green");
            Assert.Equal("None", result.ToString());
        }

        [Fact]
        public void ShouldBindBetweenStringToAge()
        {
            Func<string, Option<Age>> parseAge = s => Int.Parse(s).Bind(Age.Create);
            var result = parseAge("18").ToString();
            Assert.NotEqual("None", result);
            Assert.Equal("18", result);
        }

        [Fact]
        public void ShouldNotBindBetweenStringToAge()
        {
            Func<string, Option<Age>> parseAge = s => Int.Parse(s).Bind(Age.Create);
            var result = parseAge("3i").ToString();
            Assert.Equal("None", result);
        }


    }
}
