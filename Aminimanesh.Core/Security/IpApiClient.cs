using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aminimanesh.DataLayer.Entities.Owner;

namespace Aminimanesh.Core.Security
{
    public class IpApiClient(HttpClient httpClient)
    {
        private const string BASE_URL = "http://ip-api.com";
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IpApiResponse?> Get(string? ipAddress, CancellationToken ct)
        {
            var route = $"{BASE_URL}/json/{ipAddress}";
            var response = await _httpClient.GetFromJsonAsync<IpApiResponse>(route, ct);
            return response;
        }
    }
}
