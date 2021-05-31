using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using SixLetterWord.Domain;
using SixLetterWord.Domain.Configuration;
using System;
using System.IO;
using Xunit;

namespace SixLetterWord.Infrastructure.Tests
{
    public class FileReaderServiceTest
    {
        private readonly IFileReaderService _fileReaderService;

        public FileReaderServiceTest()
        {
            var inputFileLocation = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "assets/test.txt"));

            var appSettings = new ApplicationSettings
            { 
                InputFileLocation = inputFileLocation,
                NumberOfCharacters = 6
            };

            var appSettingOptionsMock = new Mock<IOptions<ApplicationSettings>>();
            appSettingOptionsMock
                .Setup(s => s.Value)
                .Returns(appSettings);
            
            _fileReaderService = new FileReaderService(appSettingOptionsMock.Object);
        }

        [Fact]
        public void ReadLinesFromFile_ShouldReturnLines()
        {
            // Given + When
            var result = _fileReaderService.ReadLinesFromFile();

            // Then
            result.Should().Contain("foo");
            result.Should().Contain("bar");
            result.Should().Contain("foobar");
        }
    }
}
