using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web_Api_29_07_Mine.Services
{
    public class WikiService
    {
        private readonly HttpClient _httpClient;

        public WikiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
            // Adiciona User-Agent exigido pelas APIs da Wiki
            if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "MinecraftApi/1.0");
            }
        }

        public async Task<string> SearchAsync(string termo)
        {
            // Trata espaços e caracteres especiais no termo da busca
            var termoEncoded = Uri.EscapeDataString(termo);
            var url = $"https://minecraft.wiki/api.php?action=opensearch&search={termoEncoded}&limit=1&format=json";

            return await _httpClient.GetStringAsync(url);
        }
    }
}