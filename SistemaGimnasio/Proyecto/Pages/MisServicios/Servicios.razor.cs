using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisServicios
{
    partial class Servicios
    {
        [Inject] private IServiceServicio serviceServicio { get; set; }

        private IEnumerable<Service> listaServicio { set; get; }    

        protected override async Task OnInitializedAsync()
        {
            listaServicio = await serviceServicio.GetLista();
        }
    }
}
