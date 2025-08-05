using Newtonsoft.Json;

namespace Artichaut.ConsoleApp.Domain
{
    public class Root
    {
        public int request_state { get; set; }
        public string? request_key { get; set; }
        public string? message { get; set; }
        public string? model_run { get; set; }
        public string? source { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object>? Previsions { get; set; }
    }

    public class _20250804050000
    {
        public Temperature? temperature { get; set; }
        public Pression? pression { get; set; }
        public double? pluie { get; set; }
        public double? pluie_convective { get; set; }
        public Humidite? humidite { get; set; }
        public VentMoyen? vent_moyen { get; set; }
        public VentRafales? vent_rafales { get; set; }
        public VentDirection? vent_direction { get; set; }
        public int? iso_zero { get; set; }
        public string? risque_neige { get; set; }
        public int? cape { get; set; }
        public Nebulosite? nebulosite { get; set; }
    }

    public class Temperature
    {
        [JsonProperty("2m")]
        public float? _2m { get; set; }
        public double? sol { get; set; }
        [JsonProperty("500hPa")]
        public double? _500hPa { get; set; }
        [JsonProperty("850hPa")]
        public double? _850hPa { get; set; }
    }

    public class Pression
    {
        public int? niveau_de_la_mer { get; set; }
    }

    public class Humidite
    {
        [JsonProperty("2m")]
        public double? _2m { get; set; }
    }

    public class VentMoyen
    {
        [JsonProperty("10m")]
        public double? _10m { get; set; }
    }

    public class VentRafales
    {
        [JsonProperty("10m")]
        public double? _10m { get; set; }
    }

    public class VentDirection
    {
        [JsonProperty("10m")]
        public int? _10m { get; set; }
    }

    public class Nebulosite
    {
        public int? haute { get; set; }
        public int? moyenne { get; set; }
        public int? basse { get; set; }
        public int? totale { get; set; }
    }
    public class MeteoPeriode
    {
        public Temperature? temperature { get; set; }
        public Pression? pression { get; set; }
        public double? pluie { get; set; }
        public double? pluie_convective { get; set; }
        public Humidite? humidite { get; set; }
        public VentMoyen? vent_moyen { get; set; }
        public VentRafales? vent_rafales { get; set; }
        public VentDirection? vent_direction { get; set; }
        public int? iso_zero { get; set; }
        public string? risque_neige { get; set; }
        public int? cape { get; set; }
        public Nebulosite? nebulosite { get; set; }
    }
}
