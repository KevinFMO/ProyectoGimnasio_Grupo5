using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.MisUsuarios
{
    partial class Usuarios
    {
        [Inject] private IUsuarioServicio _usuarioServicio { get; set; }
        private IEnumerable<Usuario> listaUsuarios { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaUsuarios = await _usuarioServicio.GetLista();
        }
        

    }
}
