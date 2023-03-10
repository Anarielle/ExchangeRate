using Newtonsoft.Json;

namespace ExchangeRate.Models
{
    public class CurrenciesModel
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("PreviousDate")]
        public DateTime PreviousDate { get; set; }
        [JsonProperty("PreviousURL")]
        public string PreviousURL { get; set; }
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("Valute")]
        public Dictionary<string, Currency> Currencies { get; set; }
        public Pager Pager { get; set; }
    }
}
