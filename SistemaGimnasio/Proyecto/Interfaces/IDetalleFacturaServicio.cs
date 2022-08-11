using Modelos;

namespace Proyecto.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}
