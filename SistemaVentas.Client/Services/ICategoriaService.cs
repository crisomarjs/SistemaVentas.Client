using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();
    }
}
