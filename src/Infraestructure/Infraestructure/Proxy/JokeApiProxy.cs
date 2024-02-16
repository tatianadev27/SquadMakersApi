using Domain.Proxy;

namespace Infraestructure.Proxy
{
    public class JokeApiProxy : IJokeApiProxy
    {
        private readonly HttpClient _httpClient;

        public JokeApiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetAsync(string apiUrl)
        {
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve joke from {apiUrl}: {response.StatusCode}");
            }
        }
    }
}
