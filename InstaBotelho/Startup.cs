using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using InstaBotelho.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InstaBotelho
{
    public partial class Program
    {
        private static void Startup()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (String.IsNullOrWhiteSpace(environment))
                throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            Console.WriteLine("Environment: {0}", environment);

            var services = new ServiceCollection();

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            if (environment == "Development")
            {

                builder
                    .AddJsonFile(
                        Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{environment}.json"),
                        optional: true
                    );
            }
            else
            {
                builder
                    .AddJsonFile($"appsettings.{environment}.json", optional: false);
            }

            Configuration = builder.Build();

            LoggerFactory = new LoggerFactory()
                .AddConsole(Configuration.GetSection("Logging"))
                .AddDebug();


            _serviceProvider = ConfigureServices(services);

        }

        private static ServiceProvider ConfigureServices(ServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<InstagramApiService, InstagramApiService>();
            return services.BuildServiceProvider();
        }

    }
}
