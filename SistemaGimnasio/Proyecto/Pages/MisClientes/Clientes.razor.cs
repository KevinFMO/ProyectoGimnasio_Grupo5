using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisClientes
{
    partial class Clientes
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        private IEnumerable<Cliente> listaClientes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaClientes = await clienteServicio.GetLista();
        }
    }
}
