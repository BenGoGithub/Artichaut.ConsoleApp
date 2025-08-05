using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Artichaut.ConsoleApp.Domain;

namespace Artichaut.ConsoleApp.Services
{
    public class MeteoApiService
    {
        private readonly HttpClient _client = new();
        private readonly IConfiguration _config;

        public MeteoApiService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Root?> ObtenirMeteoAsync()
        {
            try
            {
                string? url = _config["Infoclimat:ApiUrl"];
                if (string.IsNullOrEmpty(url))
                {
                    Console.WriteLine("L'URL de l'API n'est pas configurée.");
                    return null;
                }

                Console.WriteLine("URL utilisée : " + url);

                var json = await _client.GetStringAsync(url);
                var root = JsonConvert.DeserializeObject<Root?>(json);
                if (root == null)
                {
                    Console.WriteLine("Erreur de lecture des données météo (réponse vide ou inconnue).");
                    return null;
                }

                return root;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Erreur lors de l'appel HTTP : " + ex.Message);
                return null;
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Erreur lors de la désérialisation JSON : " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur inconnue : " + ex.Message);
                return null;
            }
        }

        public void AfficherToutesLesPrevisions(Root? root)
        {
            if (root == null || root.Previsions == null)
            {
                Console.WriteLine("Pas de données météo retournées.");
                return;
            }

            foreach (var kv in root.Previsions)
            {
                if (DateTime.TryParse(kv.Key, out DateTime dt))
                {
                    // On re-serialize puis désérialise dynamiquement l'objet de la période
                    var detailsJson = kv.Value.ToString();
                    var meteoData = JsonConvert.DeserializeObject<MeteoPeriode>(detailsJson!);

                    if (meteoData == null)
                    {
                        Console.WriteLine($"Données manquantes pour la date {dt:yyyy-MM-dd HH:mm}");
                        continue;
                    }

                    Console.WriteLine($"--- Prévisions du {dt:yyyy-MM-dd HH:mm} ---");
                    Console.WriteLine($"Température à 2m : {meteoData.temperature?._2m ?? double.NaN} °C");
                    Console.WriteLine($"Humidité : {meteoData.humidite?._2m ?? double.NaN} %");
                    Console.WriteLine($"Pression niveau mer : {meteoData.pression?.niveau_de_la_mer ?? 0} hPa");
                    Console.WriteLine($"Vent moyen 10m : {meteoData.vent_moyen?._10m ?? double.NaN} km/h");
                    Console.WriteLine($"Vent rafales 10m : {meteoData.vent_rafales?._10m ?? double.NaN} km/h");
                    Console.WriteLine($"Direction vent 10m : {meteoData.vent_direction?._10m ?? 0} °");
                    Console.WriteLine($"Risque neige : {meteoData.risque_neige ?? "non renseigné"}");
                    Console.WriteLine($"Précipitations : {meteoData.pluie ?? double.NaN} mm");
                    Console.WriteLine($"Nébulosité totale : {meteoData.nebulosite?.totale ?? 0}");
                    Console.WriteLine();
                }
            }
        }
    }
}