using System;
using Newtonsoft.Json;

public class Meteo
{
    public string Ville { get; set; }
    public float Temperature { get; set; }
}

public class Program
{
    public static void Main()
    {
        var data = new Meteo { Ville = "Paris", Temperature = 24.5f };
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        Console.WriteLine(json);
    }
}