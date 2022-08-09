using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly MySQLConfiguracion _configuracion;
        private IClienteRepositorio clienteRepositorio;

        public ClienteServicio(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            clienteRepositorio = new ClienteRepositorio(configuracion.CadenaConexion);
        }


        public async Task<bool> Actualizar(Cliente cliente)
        {
            return await clienteRepositorio.Actualizar(cliente);
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            return await clienteRepositorio.Eliminar(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            return await clienteRepositorio.GetLista();
        }

        public async Task<Cliente> GetPorIdentidad(string identidad)
        {
            return await clienteRepositorio.GetPorIdentidad(identidad);
        }

        public async Task<bool> Nuevo(Cliente cliente)
        {
            return await clienteRepositorio.Nuevo(cliente);
        }
    }
}
