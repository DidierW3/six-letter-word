using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SixLetterWord.Application;
using SixLetterWord.Domain;
using SixLetterWord.Domain.Configuration;

namespace SixLetterWord.Infrastructure.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFileReaderService, FileReaderService>();
            services.AddScoped<IWordService, WordService>();
        }

        public static void AddConfigurations(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection("Application"));
        }
    }
}
