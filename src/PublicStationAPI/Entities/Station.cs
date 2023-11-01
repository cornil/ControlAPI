using System.Text.Json.Serialization;

namespace PublicStationAPI.Entities
{
    public class Station
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
