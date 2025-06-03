using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services
{
    public interface IDashBoardService
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
