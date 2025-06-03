using System.Net.Http.Json;
using SistemaVentas.Client.DTOs;
using SistemaVentas.Client.Utilities;
using static System.Net.WebRequestMethods;

namespace SistemaVentas.Client.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _httpClient;
        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO entidad)
        {
            var result = await _httpClient.PostAsJsonAsync("Usuario/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return response!;
        }

        public async Task<bool> Editar(UsuarioDTO entidad)
        {
            var result = await _httpClient.PutAsJsonAsync("Usuario/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _httpClient.DeleteAsync($"Usuario/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<UsuarioDTO>> IniciarSesion(UsuarioLogin request)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/IniciarSesion?correo={request.Correo}&clave={request.Password}");
            return result!;
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>("Usuario/Lista");
            return result!;
        }
    }
}
