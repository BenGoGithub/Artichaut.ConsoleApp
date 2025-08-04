using System;
using Artichaut.ConsoleApp.Domain;
using Artichaut.ConsoleApp.Services;

namespace Artichaut.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var meteoService = new MeteoService();

            var meteoActuelle = meteoService.ObtenirMeteo("Paris");
            Console.WriteLine("Conditions actuelles :");
            Console.WriteLine(meteoActuelle);

            var historique = meteoService.Historique("Paris");
            Console.WriteLine("\\nHistorique :");
            foreach (var m in historique)
                Console.WriteLine(m);
        }
    }
}