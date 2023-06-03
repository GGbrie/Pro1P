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
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void busc_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DELL\\Desktop\\Programacion I -- 2023\\PPProyectoFinal\\PPProyectoFinal\\Database3.mdf;Integrated Security=True";
            string query = "SELECT codigo1, proveedor, telefono, fecha, ubi, precio FROM Información WHERE codigo1 = @codigo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo1.Text);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        codigo1.Text = reader["codigo1"].ToString();
                        proveedor.Text = reader["proveedor"].ToString();
                        telefono.Text = reader["telefono"].ToString();
                        fecha.Text = reader["fecha"].ToString();
                        ubi.Text = reader["ubi"].ToString();
                        precio.Text = reader["precio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la información con el código ingresado.");
                    }

                    reader.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show(); 
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
