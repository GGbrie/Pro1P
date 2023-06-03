using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PPProyectoFinal
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public string Usuario { get; internal set; }
        public string Contraseña { get; internal set; }

        private void buscar_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Desktop\\Programacion I -- 2023\\PPProyectoFinal\\PPProyectoFinal\\Database2.mdf;Integrated Security=True";
            string query = "SELECT codigo, producto, disponible, cantidad FROM Medicamentos WHERE codigo = @codigo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigos.Text); // Obtén el código ingresado en el TextBox

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Si se encontró un resultado, asigna los valores a los TextBox correspondientes
                        producto.Text = reader["producto"].ToString();
                        disponible.Text = reader["disponible"].ToString();
                        cantidad.Text = reader["cantidad"].ToString();
                    }
                    else
                    {
                        // Si no se encontró un resultado, muestra un mensaje o realiza alguna otra acción
                        MessageBox.Show("No se encontró el medicamento con el código ingresado.");
                    }

                    reader.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }
    }
}

