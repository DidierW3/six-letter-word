using FluentAssertions;
using SixLetterWord.Domain;
using System.Collections.Generic;
using Xunit;

namespace SixLetterWord.Application.Tests
{
    public class WordServiceTest
    {
        private readonly IWordService _wordService;

        public WordServiceTest()
        {
            _wordService = new WordService();
        }

        [Fact]
        public void GetAllCombinationsForWords_ShouldReturnCombination()
        {
            // Given
            var wordsToLookFor = new List<string>
            { 
                "foobar"
            };

            var partsOfWords = new List<string>
            { 
                "foo", "bar"
            };

            // When
            var result = _wordService.GetAllCombinationsForWords(wordsToLookFor, partsOfWords);

            // Then
            result.Should().ContainSingle("foo+bar=foobar");
        }
    }
}
