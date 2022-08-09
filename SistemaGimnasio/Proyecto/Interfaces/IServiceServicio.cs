using Modelos;

namespace Proyecto.Interfaces
{
    public interface IServiceServicio
    {
        Task<bool> Nuevo(Service servicio);
        Task<bool> Actualizar(Service servicio);
        Task<bool> Eliminar(Service servicio);
        Task<IEnumerable<Service>> GetLista();
        Task<Service> GetPorCodigo(string codigo);
    }
}
