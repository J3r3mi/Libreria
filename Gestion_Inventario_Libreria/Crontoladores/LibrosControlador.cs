using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Inventario_Libreria.Modelos;
using Gestion_Inventario_Libreria.Config;
using System.Data.SqlClient;
using System.Data;

namespace Gestion_Inventario_Libreria.Crontoladores
{
    internal class LibrosControlador
    {
        private readonly Conexión cn = new Conexión();

        // Obtener todos los libros
        public List<libreria_model> ObtenerTodos()

        {
            var listaLibros = new List<libreria_model>();

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "SELECT id_libro, titulo, id_autor, genero FROM Libros";

                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        conexión.Open();
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                var libro = new libreria_model
                                {
                                    id_libro = (int)lector["id_libro"],
                                    titulo = lector["titulo"].ToString(),
                                    id_autor = lector["id_autor"].ToString(),
                                    genero = lector["genero"].ToString()
                                };
                                listaLibros.Add(libro);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los libros: " + ex.Message);
            }

            return listaLibros;
        }

        
        public libreria_model ObtenerPorId(int idLibro)
        {
            libreria_model libro = null;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "SELECT id_libro, titulo, id_autor, genero FROM Libros WHERE id_libro = @id";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@id", idLibro);
                        conexión.Open();

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                libro = new libreria_model
                                {
                                    id_libro = (int)lector["id_libro"],
                                    titulo = lector["titulo"].ToString(),
                                    id_autor = lector["id_autor"].ToString(),
                                    genero = lector["genero"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el libro por ID: " + ex.Message);
            }

            return libro;
        }

        
        public bool AgregarLibro(libreria_model nuevoLibro)
        {
            bool resultado = false;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "INSERT INTO Libros (titulo, id_autor, genero) VALUES (@titulo, @idAutor, @genero)";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@titulo", nuevoLibro.titulo);
                        comando.Parameters.AddWithValue("@idAutor", nuevoLibro.id_autor);
                        comando.Parameters.AddWithValue("@genero", nuevoLibro.genero);

                        conexión.Open();
                        resultado = comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el libro: " + ex.Message);
            }

            return resultado;
        }

        
        public bool ActualizarLibro(libreria_model libro)
        {
            bool resultado = false;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "UPDATE Libros SET titulo = @titulo, id_autor = @idAutor, genero = @genero WHERE id_libro = @id";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@titulo", libro.titulo);
                        comando.Parameters.AddWithValue("@idAutor", libro.id_autor);
                        comando.Parameters.AddWithValue("@genero", libro.genero);
                        comando.Parameters.AddWithValue("@id", libro.id_libro);

                        conexión.Open();
                        resultado = comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el libro: " + ex.Message);
            }

            return resultado;
        }
        

        
        public bool EliminarLibro(int idLibro)
        {
            bool resultado = false;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "DELETE FROM Libros WHERE id_libro = @id";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@id", idLibro);
                        conexión.Open();
                        resultado = comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el libro: " + ex.Message);
            }

            return resultado;
        }
    }

    }

