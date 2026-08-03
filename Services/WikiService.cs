using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http.Json;

namespace Web_Api_29_07_Mine.Services
{
    public class WikiService
    {
        private readonly HttpClient _httpClient;

        public WikiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SearchAsync(string termo)
        {
            var url =
                $"https://minecraft.wiki/api.php?action=opensearch&search={termo}&limit=1&format=json";

            return await _httpClient.GetStringAsync(url);
        }
    }
}