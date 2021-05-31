using SixLetterWord.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixLetterWord.Application
{
    public class WordService : IWordService
    {
        public IEnumerable<string> GetAllCombinationsForWords(IEnumerable<string> wordsToLookFor, IEnumerable<string> partsOfWords)
        {
            var result = new List<string>();

            foreach (var wordToLookFor in wordsToLookFor)
                RecursivelyBreakupWord(partsOfWords.ToList(), wordToLookFor, wordToLookFor, result);

            return result;
        }

        private static void RecursivelyBreakupWord(IEnumerable<string> partsOfWords, string wordToLookFor, string word, List<string> result, string combination = "")
        {
            if (wordToLookFor.Length == 0)
            {
                result.Add($"{combination}={word}");
                return;
            }

            for (int i = 1; i <= wordToLookFor.Length; i++)
            {
                string splittedWord = GetFirstNumberOfChars(wordToLookFor, i);

                if (partsOfWords.Contains(splittedWord))
                {
                    RecursivelyBreakupWord(
                        partsOfWords,
                        wordToLookFor[i..],
                        word,
                        result,
                        BuildCombination(combination, splittedWord));
                }
            }
        }

        private static string GetFirstNumberOfChars(string word, int numberOfChars)
        {
            return word.Substring(0, numberOfChars);
        }

        private static string BuildCombination(string combination, string part)
        {
            return combination == string.Empty
                           ? part
                           : $"{combination}+{part}";
        }
    }
}
