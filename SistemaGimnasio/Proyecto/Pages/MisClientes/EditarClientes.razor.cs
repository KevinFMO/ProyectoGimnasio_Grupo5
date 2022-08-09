using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisClientes
{
    partial class EditarClientes
    {
        [Inject] IClienteServicio clienteServicio { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Parameter] public string Identidad { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Cliente cliente = new Cliente();

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Identidad))
            {
                cliente = await clienteServicio.GetPorIdentidad(Identidad);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(cliente.Identidad) || string.IsNullOrEmpty(cliente.Nombre))
            {
                return;
            }

            bool edito = await clienteServicio.Actualizar(cliente);

            if (edito)
            {
                await Swal.FireAsync("Guardar", "Cliente actualizado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo actualizar el cliente", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Clientes");
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }


        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el cliente?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Si",
                CancelButtonText = "NO"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await clienteServicio.Eliminar(cliente);
                if (elimino)
                {
                    await Swal.FireAsync("Atención", "Cliente eliminado con exito", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Clientes");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el cliente", SweetAlertIcon.Error);
                }
            }


        }

    }
}   
