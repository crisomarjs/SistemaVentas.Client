﻿using SistemaVentas.Client.DTOs;

namespace SistemaVentas.Client.Services
{
    public interface IVentaService
    {

        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO entidad);
        Task<ResponseDTO<List<VentaDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<ResponseDTO<List<ReporteDTO>>> Reporte(string fechaInicio, string fechaFin);
    }
}
