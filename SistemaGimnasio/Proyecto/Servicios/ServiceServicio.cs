using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios
{
    public class ServiceServicio : IServiceServicio
    {
        private readonly MySQLConfiguracion _configuracion;
        private IServiceRepositorio servicioRepositorio;

        public ServiceServicio(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            servicioRepositorio = new ServiceRepositorio(configuracion.CadenaConexion);
        }


        public async Task<bool> Actualizar(Service servicio)
        {
            return await servicioRepositorio.Actualizar(servicio);
        }

        public async Task<bool> Eliminar(Service servicio)
        {
            return await servicioRepositorio.Eliminar(servicio);
        }

        public async Task<IEnumerable<Service>> GetLista()
        {
            return await servicioRepositorio.GetLista();
        }

        public async Task<Service> GetPorCodigo(string codigo)
        {
            return await servicioRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Service servicio)
        {
            return await servicioRepositorio.Nuevo(servicio);
        }
    }
}
