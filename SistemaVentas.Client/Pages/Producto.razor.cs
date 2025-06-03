using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaVentas.Client.DTOs;
using SistemaVentas.Client.Pages.Modales;
using SistemaVentas.Client.Services;
using SistemaVentas.Client.Pages.Modales;

namespace SistemaVentas.Client.Pages
{
    public partial class Producto
    {
        [Inject] IProductoService _productoService { get; set; }
        [Inject] IDialogService _dialogService { get; set; }
        [Inject] ISnackbar _snackbar { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        List<ProductoDTO> listaProductos = new List<ProductoDTO>();
        private string searchString1 = "";
        private ProductoDTO selectedItem1 = null;
        private bool isLoading = true;

        private async Task ObtenerProductos()
        {
            var reuslt = await _productoService.Lista();
            if (reuslt.status)
            {
                listaProductos = (List<ProductoDTO>)reuslt.value;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await ObtenerProductos();
            isLoading = false;
        }

        private bool FilterFunc1(ProductoDTO element) => FilterFunc(element, searchString1);

        private bool FilterFunc(ProductoDTO element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Nombre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DescripcionCategoria.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{element.Nombre} {element.DescripcionCategoria}".Contains(searchString))
                return true;

            return false;
        }

        private async Task AbrirNuevoProducto()
        {
            var dialogo = _dialogService.Show<MdProducto>("Nuevo Producto");
            var resultado = await dialogo.Result;

            if (!resultado.Canceled)
            {
                await ObtenerProductos();
            }
        }

        private async Task AbrirEditarProducto(ProductoDTO model)
        {
            var parametros = new DialogParameters { ["_producto"] = model };

            var dialogo = _dialogService.Show<MdProducto>("Editar Producto", parametros);
            var resultado = await dialogo.Result;

            if (!resultado.Canceled)
            {
                await ObtenerProductos();
            }
        }

        private async Task EliminarUsuario(ProductoDTO model)
        {
            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Esta seguro?",
                Text = $"Eliminar producto: {model.Nombre}",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Si, eliminar",
                CancelButtonText = "No, volver"
            });

            if (result.IsConfirmed)
            {
                var resultado = await _productoService.Eliminar(model.IdProducto);

                if (resultado)
                {
                    _snackbar.Add("El producto fue eliminado", Severity.Success, a => a.VisibleStateDuration = 500);
                    await ObtenerProductos();
                }
                else
                    _snackbar.Add("No se pudo eliminar", Severity.Error, a => a.VisibleStateDuration = 500);
            }
        }
    }
}
