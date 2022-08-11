using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios
{
    public class DetalleFacturaServicio : IDetalleFacturaServicio
    {

        private readonly MySQLConfiguracion _configuracion;
        private IDetalleFacturaRepositorio detalleFacturaRepositorio;

        public DetalleFacturaServicio(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            detalleFacturaRepositorio = new DetalleFacturaRepositorio(configuracion.CadenaConexion);
        }

        public async Task<bool> Nuevo(DetalleFactura detalleFactura)
        {
         
            return await detalleFacturaRepositorio.Nuevo(detalleFactura);
        }
    }
}
