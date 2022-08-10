using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisServicios
{
    partial class NuevoServicio
    {
        [Inject] private IServiceServicio serviceServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        private Service service = new Service();

        //protected override async Task OnInitializedAsync()
        //{
            
        //}

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(service.Codigo) || string.IsNullOrEmpty(service.Descripcion)
                || service.PrecioDia ==0 || service.PrecioMes ==0)
            {
                return;
            }

            Service servicioExistente = new Service();

            servicioExistente = await serviceServicio.GetPorCodigo(service.Codigo);

            if (!string.IsNullOrEmpty(servicioExistente.Codigo))
            {
                await Swal.FireAsync("Advertencia", "El servicio ya existe con ese código", SweetAlertIcon.Warning);
                return;
            }

            bool inserto = await serviceServicio.Nuevo(service);

            if (inserto)
            {
                await Swal.FireAsync("Guardar", "Servicio guardado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Servicios");
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el servicio", SweetAlertIcon.Error);
            }

            
        }

        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Servicios");
        }
    }
        
}

