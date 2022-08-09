using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private string CadenaConexion;

        public ClienteRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }



        public async Task<bool> Actualizar(Cliente cliente)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE cliente SET Nombre = @Nombre, Direccion = @Direccion, Email=@Email
                                WHERE Identidad = @Identidad;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, cliente));

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM cliente WHERE Identidad = @Identidad;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { cliente.Identidad }));
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            IEnumerable<Cliente> lista = new List<Cliente>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM cliente;";
                lista = await conexion.QueryAsync<Cliente>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Cliente> GetPorIdentidad(string identidad)
        {
            Cliente client = new Cliente();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM cliente WHERE Identidad = @Identidad;";
                client = await conexion.QueryFirstAsync<Cliente>(sql, new { identidad });
            }
            catch (Exception ex)
            {
            }
            return client;
        }

        public async Task<bool> Nuevo(Cliente cliente)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO cliente (Identidad, Nombre, Direccion, Email) 
                                VALUES (@Identidad, @Nombre, @Direccion, @Email);";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, cliente));

            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
