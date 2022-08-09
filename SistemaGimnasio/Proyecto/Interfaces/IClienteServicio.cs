﻿using Modelos;

namespace Proyecto.Interfaces
{
    public interface IClienteServicio
    {
        Task<bool> Nuevo(Cliente cliente);
        Task<bool> Actualizar(Cliente cliente);
        Task<bool> Eliminar(Cliente cliente);
        Task<IEnumerable<Cliente>> GetLista();
        Task<Cliente> GetPorIdentidad(string identidad);
    }
}
