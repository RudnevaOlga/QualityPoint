using Dadata.Model;
using Newtonsoft.Json;
using QualityPoint.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace QualityPoint.Service
{
    public class DadataService : IDadataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _dadataApiKey;
        private readonly string _dadataApiUrl;

        public DadataService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _dadataApiKey = configuration.GetSection("DadataApiKey").Value;
            _dadataApiUrl = configuration.GetSection("DadataApiUrl").Value;
        }

        public async Task<Address> CleanAddressAsync(string address)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, _dadataApiUrl + "clean/address/")
            {
                Content = new StringContent($"{{\"query\":\"{address}\"}}", Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _dadataApiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var cleanAddress = JsonConvert.DeserializeObject<Address>(responseBody);

            return cleanAddress;
        }
    }
}
