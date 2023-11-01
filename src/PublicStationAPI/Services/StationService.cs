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
                privateStationApiUrl = "http://localhost:8082";
            }

            Console.WriteLine($"PrivateStationApiUrl: {privateStationApiUrl}"); 
            _httpClient.BaseAddress = new Uri(privateStationApiUrl);
        }

        public async Task<List<Station>> GetStationAsync()
        {
            var response = await _httpClient.GetAsync("api/station");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Station>>(content);
            return list;
        }
    }
}
