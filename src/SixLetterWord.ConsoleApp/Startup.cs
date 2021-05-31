using Microsoft.Extensions.Options;
using SixLetterWord.Domain;
using SixLetterWord.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixLetterWord.ConsoleApp
{
    public class Startup
    {
        private readonly IFileReaderService _fileReaderService;
        private readonly IWordService _wordService;
        private readonly ApplicationSettings _applicationSettings;

        public Startup(IFileReaderService fileReaderService, IWordService wordService, IOptions<ApplicationSettings> applicationSettings)
        {
            _fileReaderService = fileReaderService;
            _wordService = wordService;
            _applicationSettings = applicationSettings.Value;
        }

        public void Run(string[] args)
        {
            var entries = GetAllInputEntries();

            var (wordsToSearchFor, wordsToCombine) = SplitEntries(entries);

            var combinations = _wordService.GetAllCombinationsForWords(wordsToSearchFor, wordsToCombine);

            PrintAllCombinations(combinations);
        }

        private (IEnumerable<string> wordsToSearchFor, IEnumerable<string> wordsToCombine) SplitEntries(IEnumerable<string> entries)
        {
            return (
                entries.Where(x => x.Length == _applicationSettings.NumberOfCharacters),
                entries.Where(x => x.Length != _applicationSettings.NumberOfCharacters)
                );
        }

        private IEnumerable<string> GetAllInputEntries()
        {
            return _fileReaderService.ReadLinesFromFile();
        }

        private void PrintAllCombinations(IEnumerable<string> combinations)
        {
            foreach (var combination in combinations)
                Console.WriteLine(combination);
        }
    }
}
