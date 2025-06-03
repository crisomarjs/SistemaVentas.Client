using System.Net.Http.Json;
using SistemaVentas.Client.DTOs;
using static System.Net.WebRequestMethods;

namespace SistemaVentas.Client.Services.Implementation
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;
        public VentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<List<VentaDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<List<VentaDTO>>>($"Venta/Historial?buscarPor={buscarPor}&numeroVenta={numeroVenta}&fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO entidad)
        {
            var result = await _httpClient.PostAsJsonAsync("Venta/Registrar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return response!;
        }

        public async Task<ResponseDTO<List<ReporteDTO>>> Reporte(string fechaInicio, string fechaFin)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<List<ReporteDTO>>>($"Venta/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }
    }
}
