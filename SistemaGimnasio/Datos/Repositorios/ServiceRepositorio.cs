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
    public class ServiceRepositorio : IServiceRepositorio
    {
        private string CadenaConexion;

        public ServiceRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }



        public async Task<bool> Actualizar(Service servicio)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE servicio SET Descripcion = @Descripcion, PrecioDia = @PrecioDia, PrecioMes = @PrecioMes
                                WHERE Codigo = @Codigo;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, servicio));

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<bool> Eliminar(Service servicio)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM servicio WHERE Codigo = @Codigo;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { servicio.Codigo }));
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<IEnumerable<Service>> GetLista()
        {
            IEnumerable<Service> lista = new List<Service>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM servicio;";
                lista = await conexion.QueryAsync<Service>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Service> GetPorCodigo(string codigo)
        {

            Service ser = new Service();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM servicio WHERE Codigo = @Codigo;";
                ser = await conexion.QueryFirstAsync<Service>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return ser;
        }

        public async Task<bool> Nuevo(Service servicio)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO servicio (Codigo, Descripcion, PrecioDia, PrecioMes) 
                                VALUES (@Codigo, @Descripcion, @PrecioDia, @PrecioMes);";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, servicio));

            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
