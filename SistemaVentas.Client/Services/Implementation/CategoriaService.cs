using System.Net.Http.Json;
using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;
        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>("Categoria/Lista");
            return result;
        }
    }
}
