using Microsoft.AspNetCore.Components;
using MudBlazor;
using SistemaVentas.Client.Services;
using SistemaVentas.Client.Utilities;

namespace SistemaVentas.Client.Pages.Autorizacion
{
    public partial class Login
    {
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IUsuarioService _usuarioService { get; set; }

        UsuarioLogin usuarioLogin = new UsuarioLogin();
        string myImageClass { get; set; } = "d-none";
        string myAlert { get; set; } = "d-none";
        bool disableButton { get; set; } = false;
        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        void TogglePasswordVisibility()
        {
            if(PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private async Task OnValidSubmit()
        {
            myImageClass = "d-block";
            disableButton = true;
            var result = await _usuarioService.IniciarSesion(usuarioLogin);
            if(result.status)
            {
                _navigationManager.NavigateTo("/page/dashboard");
            }
            else
            {
                myImageClass = "d-none";
                myAlert = "d-block";
                disableButton = false;
            }
        }
    }
}
