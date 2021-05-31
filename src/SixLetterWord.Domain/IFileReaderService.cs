using System.Collections.Generic;

namespace SixLetterWord.Domain
{
    public interface IFileReaderService
    {
        IEnumerable<string> ReadLinesFromFile();
    }
}
