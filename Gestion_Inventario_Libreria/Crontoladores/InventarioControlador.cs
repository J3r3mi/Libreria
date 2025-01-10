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
    internal class InventarioControlador
    {
        private readonly Conexión cn = new Conexión();

        public bool ActualizarStock(int idLibro, int stock)
        {
            bool resultado = false;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "UPDATE Inventario SET stock = @stock WHERE id_libro = @id";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@id", idLibro);
                        comando.Parameters.AddWithValue("@stock", stock);

                        conexión.Open();
                        resultado = comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el stock: " + ex.Message);
            }

            return resultado;
        }

        public bool AgregarInventario(int idLibro, int stock, decimal precio)
        {
            bool resultado = false;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "INSERT INTO Inventario (id_libro, stock, precio) VALUES (@idLibro, @stock, @precio)";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@idLibro", idLibro);
                        comando.Parameters.AddWithValue("@stock", stock);
                        comando.Parameters.AddWithValue("@precio", precio);

                        conexión.Open();
                        resultado = comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar al inventario: " + ex.Message);
            }

            return resultado;
        }


        public List<inventario_model> ObtenerInventario()
        {
            var listaInventario = new List<inventario_model>();

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "SELECT id_inventario, id_libro, stock_disponible, precio FROM Inventario";

                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        conexión.Open();
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                var inventario = new inventario_model
                                {
                                    id_inventario = (int)lector["id_inventario"],
                                    id_libro = (int)lector["id_libro"],
                                    stock_disponible = (int)lector["stock_disponible"],
                                    precio = (decimal)lector["precio"]
                                };
                                listaInventario.Add(inventario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el inventario: " + ex.Message);
            }

            return listaInventario;
        }


            public bool ActualizarInventario(int idLibro, int stock, decimal precio)
        {
            bool resultado = false;

            try
            {
                using (var conexión = cn.obtenerConexion())
                {
                    string cadena = "UPDATE Inventarios SET Stock = @Stock, Precio = @Precio WHERE LibroID = @IdLibro";
                    using (var comando = new SqlCommand(cadena, conexión))
                    {
                        comando.Parameters.AddWithValue("@Stock", stock);
                        comando.Parameters.AddWithValue("@Precio", precio);
                        comando.Parameters.AddWithValue("@IdLibro", idLibro);

                        conexión.Open();
                        resultado = comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el inventario: " + ex.Message);
            }

            return resultado;
        }
    }
    }

