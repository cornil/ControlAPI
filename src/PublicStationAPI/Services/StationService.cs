using System.Text.Json;
using PublicStationAPI.Interfaces;

namespace PublicStationAPI.Services
{
    public class StationService : IStationService
    {
        // call http://privatestationapi/station

        private readonly HttpClient _httpClient;

        public StationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // get env var PrivateStationApiUrl
            string privateStationApiUrl = Environment.GetEnvironmentVariable("PrivateStationApiUrl");

            if(string.IsNullOrEmpty(privateStationApiUrl))
            {
                privateStationApiUrl = "http://localhost:5092";
            }

            Console.WriteLine($"PrivateStationApiUrl: {privateStationApiUrl}"); 
            _httpClient.BaseAddress = new Uri(privateStationApiUrl);
        }

        public async Task<List<StationDTO>> GetStationAsync()
        {
            var response = await _httpClient.GetAsync("api/station");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var list = JsonSerializer.Deserialize<List<StationDTO>>(content, options);
            return list;
        }
    }
}
