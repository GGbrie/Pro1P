using PPProyectoFinal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPProyectoFinal
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private SqlConnection CrearConexion()
        {
            return new SqlConnection("C:\\Users\\DELL\\Desktop\\Programacion I -- 2023\\PPProyectoFinal\\PPProyectoFinal\\Database1.mdf");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ingresarusuarioText = ingresar.Text;
            string ingresarcontraseña = incrontra.Text;

            //Realiza la verificación en la base de datos correspondientes
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\Programacion I -- 2023\PPProyectoFinal\PPProyectoFinal\Database1.mdf;Integrated Security=True";

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Gabriel WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object value = command.Parameters.AddWithValue("@Usuario", ingresarusuarioText);
                    command.Parameters.AddWithValue("@Contraseña", ingresarcontraseña);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        //Si los datos coinciden, abrira la siguiente ventana 
                        Window1 window1 = new Window1();
                        window1.Usuario = ingresarusuarioText;
                        window1.Contraseña = ingresarcontraseña;
                        window1.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta, Vuelve a Intentarlo");
                        ingresar.Text = "";
                        incrontra.Text = "";
                    }

                }
            }
        }
    }
}