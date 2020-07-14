using System;
using Xunit;
using Translator.Data.Models;

namespace TranslatorTests
{
    public class TranslatorTest
    {
        private Dictionary dictionary;
        public TranslatorTest()
        {
            dictionary = new Dictionary("../Translator/dict.txt");
        }
        [Fact]
        public void SuccessFindFromRuToEn()
        {
            Assert.Equal("дорога", dictionary.Find("road"));
        }
        [Fact]
        public void FindNull()
        {
            Assert.Null(dictionary.Find("undefined word"));
        }
        [Fact]
        public void SuccessFindFromEnToRu()
        {
            Assert.Equal("computer", dictionary.Find("компьютер"));
        }
    }
}
