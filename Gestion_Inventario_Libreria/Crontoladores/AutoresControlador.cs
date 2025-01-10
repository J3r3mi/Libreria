using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Inventario_Libreria.Modelos;
using Gestion_Inventario_Libreria.Config;
using System.Data.SqlClient;

namespace Gestion_Inventario_Libreria.Crontoladores
{
    internal class AutoresControlador
    {
        private readonly Conexión cn = new Conexión();

        public int AgregarAutor(string nombreAutor)
        {
            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "INSERT INTO Autores (nombre) VALUES (@nombre)";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombreAutor);
                        conexión.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Si se insertó correctamente, obtener el ID del autor recién agregado
                            string idQuery = "SELECT SCOPE_IDENTITY()";
                            using (var comandoId = new SqlCommand(idQuery, conexión))
                            {
                                int idAutor = Convert.ToInt32(comandoId.ExecuteScalar());
                                return idAutor; // Devuelve el ID del nuevo autor
                            }
                        }
                        else
                        {
                            // Si no se afectaron filas, retornar un valor negativo
                            return -1; // Indica un error al agregar el autor
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el autor: " + ex.Message);
                return -1; // Devuelve -1 si ocurre una excepción
            }
        }


        public List<autores_model> ObtenerAutores()
        {
            var listaAutores = new List<autores_model>();

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "SELECT id_autor, nombre_autor FROM Autores";

                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        conexión.Open();
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                var autor = new autores_model
                                {
                                    id_autor = (int)lector["id_autor"],
                                    nombre_autor = lector["nombre_autor"].ToString(),
                                    apellido_autor = lector["apellido_autor"].ToString(),
                                };
                                listaAutores.Add(autor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los autores: " + ex.Message);
            }

            return listaAutores;
        }

        
        public void AgregarAutor(string idAutor, string nombreAutor)
        {
            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "INSERT INTO Autores (id_autor, nombre_autor) VALUES (@idAutor, @nombreAutor)";

                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@idAutor", idAutor);
                        comando.Parameters.AddWithValue("@nombreAutor", nombreAutor);
                        

                        conexión.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el autor: " + ex.Message);
            }
        }
    }
}
