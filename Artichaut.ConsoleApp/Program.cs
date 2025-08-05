using Microsoft.Extensions.Configuration;
using Artichaut.ConsoleApp.Services;

namespace Artichaut.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var meteoService = new MeteoApiService(config);
            var root = await meteoService.ObtenirMeteoAsync();

            meteoService.AfficherToutesLesPrevisions(root);
        }
    }
}