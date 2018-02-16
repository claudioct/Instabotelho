using InstaSharp;
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InstaBotelho
{
    public partial class Program
    {
        public static ILoggerFactory LoggerFactory;
        public static IConfigurationRoot Configuration;
        public static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            Startup();

            Console.WriteLine("Welcome!");
            Console.ReadKey();

            var clientId = Configuration.
            var clientSecret = ConfigurationManager.AppSettings["client_secret"];
            var redirectUri = ConfigurationManager.AppSettings["redirect_uri"];
            var realtimeUri = "";

            InstagramConfig config = new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);
        }
    }
}
