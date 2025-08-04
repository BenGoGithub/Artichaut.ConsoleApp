namespace Artichaut.ConsoleApp.Domain
{
    public class Utilisateur
    {
        public string Nom { get; set; }
        public string Email { get; set; }

        public Utilisateur() {}

        public Utilisateur(string nom, string email)
        {
            Nom = nom;
            Email = email;
        }

        public override string ToString() => $"{Nom} ({Email})";
    }
}