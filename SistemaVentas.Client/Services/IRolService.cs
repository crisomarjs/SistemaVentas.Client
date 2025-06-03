using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services
{
    public interface IRolService
    {
        Task<ResponseDTO<List<RolDTO>>> Lista();
    }
}
