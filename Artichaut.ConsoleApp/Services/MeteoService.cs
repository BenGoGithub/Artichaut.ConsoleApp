using System;
using System.Collections.Generic;
using Artichaut.ConsoleApp.Domain;

namespace Artichaut.ConsoleApp.Services
{
    public class MeteoService
    {
        // Exemple : retourne une météo simulée
        public Meteo ObtenirMeteo(string ville)
        {
            // Simule une météo pour la ville
            return new Meteo(
                ville,
                DateTime.Now,
                (float)(20 + new Random().NextDouble() * 10), // temp. aléatoire
                new Random().Next(40, 90), // humidité aléatoire
                "Ensoleillé"
            );
        }

        // Exemple : Liste historique factice
        public List<Meteo> Historique(string ville, int jours = 5)
        {
            var liste = new List<Meteo>();
            for (int i = 0; i < jours; i++)
            {
                liste.Add(new Meteo(
                    ville,
                    DateTime.Today.AddDays(-i),
                    18 + i,
                    60 + i,
                    i % 2 == 0 ? "Nuageux" : "Ensoleillé"
                ));
            }
            return liste;
        }
    }
}