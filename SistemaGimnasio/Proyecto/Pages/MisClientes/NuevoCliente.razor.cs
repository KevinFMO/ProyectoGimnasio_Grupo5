using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisClientes
{
    partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        private Cliente cl = new Cliente();


        //protected override async Task OnInitializedAsync()
        //{
           
        //}

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(cl.Identidad) || string.IsNullOrEmpty(cl.Nombre) )
            {
                return;
            }

            bool inserto = await clienteServicio.Nuevo(cl);

            if (inserto)
            {
                await Swal.FireAsync("Guardar", "Cliente guardado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el cliente", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Clientes");
        }

        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/Clientes");
        }

    }
}
