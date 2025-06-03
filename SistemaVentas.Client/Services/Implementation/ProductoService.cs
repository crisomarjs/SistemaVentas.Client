using System.Net.Http.Json;
using SistemaVentas.Client.DTOs;
using static System.Net.WebRequestMethods;

namespace SistemaVentas.Client.Services.Implementation
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;
        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO producto)
        {
            var result = await _httpClient.PostAsJsonAsync("Producto/Guardar", producto);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return response!;
        }

        public async Task<bool> Editar(ProductoDTO producto)
        {
            var result = await _httpClient.PutAsJsonAsync("Producto/Editar", producto);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _httpClient.DeleteAsync($"Producto/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>("Producto/Lista");
            return result!;
        }
    }
}
