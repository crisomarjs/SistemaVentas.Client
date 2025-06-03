using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaVentas.Client.DTOs;
using SistemaVentas.Client.Services;

namespace SistemaVentas.Client.Pages.Modales
{
    public partial class MdProducto
    {
        [Inject] ICategoriaService _categoriaServicio { get; set; }
        [Inject] IProductoService _productoServicio { get; set; }
        [Inject] ISnackbar _snackBar { get; set; }

        [Parameter]
        public ProductoDTO _producto { get; set; } = new ProductoDTO();

        List<CategoriaDTO> listaCategoria = new List<CategoriaDTO>();
        public CategoriaDTO categoriaSeleccionado;


        [CascadingParameter]
        IMudDialogInstance MudDialog { get; set; }


        protected override async Task OnInitializedAsync()
        {

            var resultado = await _categoriaServicio.Lista();

            if (resultado.status)
            {
                listaCategoria = resultado.value!;
                if (_producto.IdProducto != 0)
                    categoriaSeleccionado = listaCategoria.FirstOrDefault(p => p.IdCategoria == _producto.IdCategoria)!;
                else
                    categoriaSeleccionado = listaCategoria.First();


            }
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
        private async Task Guardar()
        {
            _producto.IdCategoria = categoriaSeleccionado.IdCategoria;
            string _mensaje = "";
            bool _resultado;

            if (_producto.IdProducto != 0)
            {
                _resultado = await _productoServicio.Editar(_producto);
                _mensaje = "Producto fue modificado";
            }
            else
            {
                var response = await _productoServicio.Crear(_producto);
                _resultado = response.status;
                _mensaje = "Producto fue creado";
            }

            if (_resultado)
            {
                _snackBar.Add(_mensaje, Severity.Success, a => a.VisibleStateDuration = 500);
                MudDialog.Close(DialogResult.Ok(true));
            }
            else
                _snackBar.Add("Error al guardar cambios", Severity.Error, a => a.VisibleStateDuration = 500);

        }
    }
}
