using System;
using System.Collections.Generic;
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

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ExamenAngel_Sorto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenAngel_Sorto.Properties.Settings.ERP"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            MostrarNombre();
        }

        private void MostrarNombre()
        {
            string query = "SELECT * FROM Usuarios.usuario";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,sqlConnection);

            using (sqlDataAdapter)
            {
                try
                {
                    DataTable tablaUsuario = new DataTable();
                    sqlDataAdapter.Fill(tablaUsuario);
                    lblNombre.DisplayMemberPath = "nombre";
                    lblNombre.SelectedValue = "nombreUsuario";
                    lblNombre.ItemsSource = tablaUsuario.DefaultView;
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Usuarios.usuario VALUES(@nom,@apell,@nomUsu,@contra,@correo,@tipoU,@estado)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            // Abrir la conexión
            sqlConnection.Open();

            // Reemplazar el parámetro con su valor respectivo
            sqlCommand.Parameters.AddWithValue("@nom",txtNombre.Text);
            sqlCommand.Parameters.AddWithValue("@apell",txtApellidos.Text);
            sqlCommand.Parameters.AddWithValue("@nomUsu",txtNombreUsuario.Text);
            sqlCommand.Parameters.AddWithValue("@contra", txtContraseña);
            sqlCommand.Parameters.AddWithValue("@correo",txtCorreo.Text);
            sqlCommand.Parameters.AddWithValue("@tipoU",cmbTipoUsuario.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@estado",cmbEstado.SelectedValue);


            // Ejecutamos el query de inserción
            sqlCommand.ExecuteNonQuery();

            // Limpiar el valor del texto en txtInformacion
            txtNombre.Text = String.Empty;

        }
    }
}
