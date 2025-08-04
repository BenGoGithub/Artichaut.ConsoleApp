namespace Artichaut.ConsoleApp.Domain
{
    public class Meteo
    {
        public string Ville { get; set; }
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public int Humidite { get; set; }
        public string Conditions { get; set; }

        // Constructeur par défaut
        public Meteo() {}

        public Meteo(string ville, DateTime date, float temperature, int humidite, string conditions)
        {
            Ville = ville;
            Date = date;
            Temperature = temperature;
            Humidite = humidite;
            Conditions = conditions;
        }

        public override string ToString() =>
            $"{Date:dd/MM/yyyy} à {Ville} : {Temperature}°C, {Humidite}% humidité ({Conditions})";
    }
}