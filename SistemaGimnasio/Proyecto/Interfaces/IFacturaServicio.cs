using Modelos;

namespace Proyecto.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> Nueva(Factura factura);
    }
}
