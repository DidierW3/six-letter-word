using Microsoft.Extensions.Options;
using SixLetterWord.Domain;
using SixLetterWord.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace SixLetterWord.Infrastructure
{
    public class FileReaderService : IFileReaderService
    {
        private readonly ApplicationSettings _applicationSettings;

        public FileReaderService(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;
        }

        public IEnumerable<string> ReadLinesFromFile()
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../", _applicationSettings.InputFileLocation));

            if (!File.Exists(path))
                throw new FileNotFoundException($"The file on location '{path}' was not found");

            return File.ReadAllLines(path);
        }
    }
}
