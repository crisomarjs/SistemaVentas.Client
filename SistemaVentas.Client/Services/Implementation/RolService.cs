using System.Net.Http.Json;
using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services.Implementation
{
    public class RolService : IRolService
    {
        private readonly HttpClient _httpClient;
        public RolService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<List<RolDTO>>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<List<RolDTO>>>("Rol/Lista");
            return result!;
        }
    }
}
