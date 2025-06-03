using System.Net.Http.Json;
using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        private readonly HttpClient _httpClient;
        public DashBoardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<DashBoardDTO>> Resumen()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>("DashBoard/Resumen");
            return result!;
        }
    }
}
