using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IServiceRepositorio
    {
        Task<bool> Nuevo(Service servicio);
        Task<bool> Actualizar(Service servicio);
        Task<bool> Eliminar(Service servicio);
        Task<IEnumerable<Service>> GetLista();
        Task<Service> GetPorCodigo(string codigo);
    }
}
