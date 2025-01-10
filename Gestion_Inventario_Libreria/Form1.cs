using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_Inventario_Libreria.Crontoladores;
using Gestion_Inventario_Libreria.Modelos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestion_Inventario_Libreria
{
    public partial class Libreria : Form
    {
        // Instancias de los controladores
        private readonly LibrosControlador librosControlador = new LibrosControlador();
        private readonly AutoresControlador autoresControlador = new AutoresControlador();
        private readonly InventarioControlador inventarioControlador = new InventarioControlador();
        public Libreria()
        {
            InitializeComponent();
        }
        private void Libreria_Load(object sender, EventArgs e)
        {
            // Cargar opciones en el ComboBox de género
            comboBox1.Items.Add("Ficción");
            comboBox1.Items.Add("Terror");
            comboBox1.Items.Add("Ciencia");
            comboBox1.Items.Add("Historia");
            comboBox1.SelectedIndex = 0; // Selecciona el primero por defecto

          


        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica los valores de cada campo
            MessageBox.Show("ID Libro: " + txtIdLibro.Text + "\nAutor: " + textBox2.Text +
                            "\nStock: " + textBox3.Text + "\nPrecio: " + textBox4.Text,
                            "Valores de los campos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Verifica si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtIdLibro.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Eliminar espacios adicionales al principio y al final
                string idLibroText = txtIdLibro.Text.Trim();

                // Eliminar cualquier carácter no numérico
                idLibroText = new string(idLibroText.Where(c => Char.IsDigit(c)).ToArray());

                // Intentar convertir el valor a entero
                int idLibro;
                if (!int.TryParse(idLibroText, out idLibro))
                {
                    MessageBox.Show("El ID del libro no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene la ejecución si no es un número válido
                }

                // Si pasa la validación, mostrar el ID de libro
                MessageBox.Show("ID de libro válido: " + idLibro.ToString(), "Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdLibro.Text) ||
       string.IsNullOrWhiteSpace(txtAutor.Text) ||
       string.IsNullOrWhiteSpace(txtStock.Text) ||
       string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener los datos del formulario
                int idLibro = int.Parse(txtIdLibro.Text); // ID del libro a editar
                string autor = txtAutor.Text;
                string genero = comboBox1.SelectedItem.ToString();
                int stock = int.Parse(txtStock.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);

                // Crear el objeto de libro con los datos actualizados
                var libro = new libreria_model
                {
                    id_libro = idLibro,
                    id_autor = autor,
                    genero = genero
                };

                // Llamar al controlador para actualizar el libro
                bool exito = librosControlador.ActualizarLibro(libro);

                if (exito)
                {
                    MessageBox.Show("Libro actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el libro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdLibro.Text))
            {
                MessageBox.Show("Por favor, ingresa el ID del libro que deseas eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idLibro = int.Parse(txtIdLibro.Text); // ID del libro a eliminar

                // Llamar al controlador para eliminar el libro
                bool exito = librosControlador.EliminarLibro(idLibro);

                if (exito)
                {
                    MessageBox.Show("Libro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el libro. Asegúrate de que el libro exista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdLibro.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Por favor, ingresa el ID del libro y el nuevo stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idLibro = int.Parse(txtIdLibro.Text); // ID del libro
                int stock = int.Parse(txtStock.Text); // Nuevo stock

                // Actualizar el stock del libro
                bool exito = inventarioControlador.ActualizarStock(idLibro, stock);

                if (exito)
                {
                    MessageBox.Show("Stock actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
