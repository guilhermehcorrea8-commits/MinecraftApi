using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http.Json;

namespace Web_Api_29_07_Mine.Services
{
    public class MojangService
    {
        private readonly HttpClient _httpClient;

        public MojangService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MojangProfile?> GetPlayerAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<MojangProfile>(
                $"https://api.mojang.com/users/profiles/minecraft/{username}");
        }
    }

    public class MojangProfile
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}