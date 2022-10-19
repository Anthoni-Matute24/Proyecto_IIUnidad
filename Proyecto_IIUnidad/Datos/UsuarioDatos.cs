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
    // Esta clase sirve para crear los métodos que nos permite acceder a los datos de la tabla Usuario
    public class UsuarioDatos
    {
        // Permite acceder a la tabla Usuario
        public async Task<bool> LoginAsync(string codigo, string clave)
        {
            // Devuelve False, por que el "Codigo y Clave" son incorrectos
            bool valido = false;

            try
            {
                // Si el "Codigo y Claves" son correctos, entonces devolverá 1
                string sql = "SELECT 1 FROM Usuario WHERE Codigo=@Codigo AND Clave=@Clave;";

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

                        // Objeto: comando, pasa parametro a:
                        // "Código" -> Tipo dato: VarChar, Tamaño: 20 caracteres 
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = codigo;
                        // "Clave"->Tipo dato: VarChar, Tamaño: 120 caracteres
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 120).Value = clave;

                        // Ejecuta todo el "Objeto: comando" y devuelve un valor numérico (1)
                        // Se covierte a Boolean y devuelve "True" 
                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return valido;
        }

        // Devuelve la lista de usuarios de la tabla Usuario
        public async Task<DataTable> DevolverListaAsync()
        { // DataTable: Captura todos los datos de una tabla
            DataTable dt = new DataTable();
            try
            {
                // Consulta todos los datos de una Tabla
                string sql = "SELECT * FROM Usuario";

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
        public async Task<bool> InsertarAsync(Usuario usuario)
        {
            bool inserto = false;
            try
            {
                // Agregar valores a los campos de la tabla
                string sql = "INSERT INTO usuario VALUES (@Codigo, @Nombre, @Clave, @Correo, @Rol, @EstaActivo)";

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

                        
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = usuario.Codigo;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = usuario.Nombre;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 120).Value = usuario.Clave;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = usuario.Correo;
                        comando.Parameters.Add("@Rol", MySqlDbType.VarChar, 20).Value = usuario.Rol;
                        comando.Parameters.Add("@EstaActivo", MySqlDbType.Bit, 120).Value = usuario.EstaActivo;

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
        public async Task<bool> ActualizarAsync(Usuario usuario)
        {
            bool actualizo = false;
            try
            {
                // Agregar valores a los campos de la tabla
                string sql = "UPDATE usuario SET Nombre=@Nombre, Clave=@Clave, Correo=@Correo, Rol=@Rol, EstaActivo=@EstaActivo WHERE Codigo=@Codigo;";

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


                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = usuario.Codigo;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = usuario.Nombre;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 120).Value = usuario.Clave;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = usuario.Correo;
                        comando.Parameters.Add("@Rol", MySqlDbType.VarChar, 20).Value = usuario.Rol;
                        comando.Parameters.Add("@EstaActivo", MySqlDbType.Bit, 120).Value = usuario.EstaActivo;

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
                string sql = "DELETE FROM usuario WHERE Codigo = @Codigo";

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

                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = codigo;

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
    }
}
