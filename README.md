# 🧾 Sistema de Ventas - Cliente Blazor WebAssembly (.NET 8)

Este proyecto es un cliente web desarrollado con **Blazor WebAssembly en .NET 8**, que consume la API REST disponible en el backend:

🔗 **API Backend (.NET 8 Web API)**: [crisomarjs/SistemaVentas.Server](https://github.com/crisomarjs/SistemaVentas.Server)

## ⚙️ Tecnologías Utilizadas

- [Blazor WebAssembly (.NET 8)](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-8.0)
- [MudBlazor](https://mudblazor.com/) (componentes UI modernos y responsivos)
- [SweetAlert2](https://sweetalert2.github.io/) (ventanas emergentes personalizadas)
- [ChartJs Blazor Fork](https://github.com/mariusmuntean/ChartJs.Blazor.Fork) (gráficas con Chart.js en Blazor)

## 📁 Estructura del Proyecto

- 📁 DTOs -> Modelos para el consumo de la API
- 📁 Layout -> Componentes de diseño global (NavBar, MainLayout, etc.)
- 📁 Pages -> Páginas del sistema (Dashboard, Productos, Ventas, etc.)
- 📁 Properties -> Configuraciones del proyecto
- 📁 Services -> Servicios inyectables que consumen la API
- 📁 Utilities -> Funciones de apoyo y clases auxiliares
- 📁 wwwroot -> Archivos estáticos (CSS, JS, logos, etc.)

## 🚀 Cómo Ejecutarlo

1. Clona este repositorio:
2. Asegúrate de que el api esté corriendo
3. Configura la URL base de la API en appsettings.json
   ```bash
   {
    "ApiUrl": "http://localhost:5232/api/"
   }
   ```
4. Ejecuta el proyecto Blazor
   dotnet run

## 📷 Capturas
![Captura de pantalla 2025-06-03 141923](https://github.com/user-attachments/assets/99422c86-66c3-43ab-8cb3-bcc5c39e6da0)
![Captura de pantalla 2025-06-03 141944](https://github.com/user-attachments/assets/a3c58cbf-9f85-4367-b3ae-5d959ee85d2f)
![Captura de pantalla 2025-06-03 142001](https://github.com/user-attachments/assets/5a0067be-e00b-4f65-8466-d7ae847f1c4f)
![Captura de pantalla 2025-06-03 142034](https://github.com/user-attachments/assets/6112a60a-0747-49f1-9276-2f9a4c65969d)
![Captura de pantalla 2025-06-03 142057](https://github.com/user-attachments/assets/2eb68bbb-4e85-43da-b4db-530b18ea66ff)
![Captura de pantalla 2025-06-03 142117](https://github.com/user-attachments/assets/c41e1759-9578-4f1f-ab33-c494cf8e7a9e)
![Captura de pantalla 2025-06-03 142132](https://github.com/user-attachments/assets/aac3c0be-4ef0-4b7a-a405-f5e4a3e79a10)
