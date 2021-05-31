using System.Collections.Generic;

namespace SixLetterWord.Domain
{
    public interface IWordService
    {
        IEnumerable<string> GetAllCombinationsForWords(IEnumerable<string> wordsToLookFor, IEnumerable<string> partsOfWords);
    }
}
