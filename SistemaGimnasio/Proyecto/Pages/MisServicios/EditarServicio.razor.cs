using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisServicios
{
    partial class EditarServicio
    {
        [Inject] private IServiceServicio serviceServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Parameter] public string Codigo { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Service services = new Service();


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                services = await serviceServicio.GetPorCodigo(Codigo);
            }

        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(services.Codigo) || string.IsNullOrEmpty(services.Descripcion)
                || services.PrecioDia == 0 || services.PrecioMes == 0)
            {
                return;
            }

            bool edito = await serviceServicio.Actualizar(services);

            if (edito)
            {
                await Swal.FireAsync("Guardar", "Servicio guardado con exito", SweetAlertIcon.Success);
                navigationManager.NavigateTo("/Servicios");
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el servicio", SweetAlertIcon.Error);
            }
            
        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Servicios");
        }
        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el servicio?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Si",
                CancelButtonText = "NO"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await serviceServicio.Eliminar(services);
                if (elimino)
                {
                    await Swal.FireAsync("Atención", "Servicio eliminado con exito", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Servicios");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el servicio", SweetAlertIcon.Error);
                }
            }


        }


    }
}
