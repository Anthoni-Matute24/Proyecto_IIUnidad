using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos
    {
        // Devuelve la lista de usuarios de la tabla Producto
        public async Task<DataTable> DevolverListaAsync()
        { // DataTable: Captura todos los datos de una tabla
            DataTable dt = new DataTable();
            try
            {
                // Consulta todos los datos de una Tabla
                string sql = "SELECT * FROM Producto";

                // Clase conexión para acceder a la BD
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    // Abre la conexión de la BD
                    await _conexion.OpenAsync();

                    // Comando que ejecuta la sentencia "sql" y la transmite por medio de "_conexion"
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        // Define el tipo de Comando (texto)
                        comando.CommandType = System.Data.CommandType.Text;

                        // MySqlDataReader: Lee todos los datos de "comando" y los envía a DataTable (dt)
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        // Agregar un usuario
        public async Task<bool> InsertarAsync(Producto producto)
        {
            bool inserto = false;
            try
            {
                // Agregar valores a los campos de la tabla
                string sql = "INSERT INTO producto VALUES (@Codigo, @Descripcion, @Existencia, @Precio, @FechaCreacion, @Imagen);";

                // Clase conexión para acceder a la BD
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    // Abre la conexión de la BD
                    await _conexion.OpenAsync();

                    // Comando que ejecuta la sentencia "sql" y la transmite por medio de "_conexion"
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        // Define el tipo de Comando (texto)
                        comando.CommandType = System.Data.CommandType.Text;


                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = producto.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 50).Value = producto.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = producto.Existencia;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@FechaCreacion", MySqlDbType.DateTime).Value = producto.FechaCreacion;
                        comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = producto.Imagen;

                        // Ejecuta "sql" pero no retorna ningún valor
                        await comando.ExecuteNonQueryAsync();
                        inserto = true; // Devuelve True si no hay problema en la ejecución
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }

        // Actualiza un usuario
        public async Task<bool> ActualizarAsync(Producto producto)
        {
            bool actualizo = false;
            try
            {
                // Agregar valores a los campos de la tabla
                string sql = "UPDATE producto SET Descripcion=@Descripcion, Existencia=@Existencia, Precio=@Precio, FechaCreacion=@FechaCreacion, Imagen=@Imagen WHERE Codigo=@Codigo;";

                // Clase conexión para acceder a la BD
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    // Abre la conexión de la BD
                    await _conexion.OpenAsync();

                    // Comando que ejecuta la sentencia "sql" y la transmite por medio de "_conexion"
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        // Define el tipo de Comando (texto)
                        comando.CommandType = System.Data.CommandType.Text;


                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = producto.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 50).Value = producto.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = producto.Existencia;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@FechaCreacion", MySqlDbType.DateTime).Value = producto.FechaCreacion;
                        comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = producto.Imagen;

                        // Ejecuta "sql" pero no retorna ningún valor
                        await comando.ExecuteNonQueryAsync();
                        actualizo = true; // Devuelve True si no hay problema en la ejecución
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return actualizo;
        }

        // Elimina un usuario
        public async Task<bool> EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                // Eliminar un registro de la tabla usuario
                string sql = "DELETE FROM producto WHERE Codigo = @Codigo";

                // Clase conexión para acceder a la BD
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    // Abre la conexión de la BD
                    await _conexion.OpenAsync();

                    // Comando que ejecuta la sentencia "sql" y la transmite por medio de "_conexion"
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        // Define el tipo de Comando (texto)
                        comando.CommandType = System.Data.CommandType.Text;

                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = codigo;

                        // Ejecuta "sql" pero no retorna ningún valor
                        await comando.ExecuteNonQueryAsync();
                        elimino = true; // Devuelve True si no hay problema en la ejecución
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }

        // Consulta la imagen de un producto
        public async Task<byte[]> SeleccionarImagen(string codigo)
        {
            // Variable "imagen": Si no existe/encuentra imagen, devolverá 0
            byte[] imagen = new byte[0];

            try
            {
                // Eliminar un registro de la tabla usuario
                string sql = "SELECT Imagen FROM producto WHERE Codigo = @Codigo;";

                // Clase conexión para acceder a la BD
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    // Abre la conexión de la BD
                    await _conexion.OpenAsync();

                    // Comando que ejecuta la sentencia "sql" y la transmite por medio de "_conexion"
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        // Define el tipo de Comando (texto)
                        comando.CommandType = System.Data.CommandType.Text;

                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = codigo;

                        // Método para traer la imagen
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();

                        if (dr.Read()) // Si encuentra bytes, entoces le envía los bytes a la variable "imagen"
                        {
                            imagen = (byte[])dr["Imagen"];
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            { 
            }
            return imagen;
        }
    }
}
