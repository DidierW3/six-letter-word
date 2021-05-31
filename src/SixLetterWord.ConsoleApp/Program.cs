using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Configuration;
using SixLetterWord.Infrastructure.Configuration;
using System;

namespace SixLetterWord.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<Startup>().Run(args);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../")))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            
            services.AddServices();
            services.AddConfigurations(configuration);

            services.AddTransient<Startup>();
        }
    }
}
