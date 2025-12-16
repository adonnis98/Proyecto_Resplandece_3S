using Proyecto_Resplandece;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Windows.Forms;
using BCrypt.Net;
using System.Drawing.Drawing2D;
using System.Drawing;
using Proyecto_Resplandece.Clases;
using System;

namespace Proyecto_Resplandece
{
    public partial class FormIniciarSesion : Form
    {

        private const string connectionString =
       "Server=127.0.0.1; Port=3306;Database=bd_proyecto; Uid=root; Pwd=smilecry98;";
        public FormIniciarSesion()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color colorArriba = Color.FromArgb(240, 248, 255);
            Color colorAbajo = Color.FromArgb(240, 248, 255);

            LinearGradientBrush pincelDegradado = new LinearGradientBrush
             (
                  panel1.ClientRectangle,
                  colorArriba,
                  colorAbajo,
                  LinearGradientMode.BackwardDiagonal
             );
            e.Graphics.FillRectangle(pincelDegradado, panel1.ClientRectangle);
            pincelDegradado.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormGestionUsuarios registro = new FormGestionUsuarios();
            registro.ShowDialog();
            this.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string contrasenaIngresada = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuarioIngresado) || string.IsNullOrWhiteSpace(contrasenaIngresada))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string userRol = AutenticarUsuario(usuarioIngresado, contrasenaIngresada);
            if (!string.IsNullOrEmpty(userRol))
            {
                SessionManager.Username = usuarioIngresado;
                SessionManager.Rol = userRol;

                FormMenuPrincipal menu = new FormMenuPrincipal();
                menu.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }
        private string AutenticarUsuario(string username, string password)
        {// Aseguramos que el nombre de usuario esté limpio de espacios
            string usuarioLimpio = username.Trim();

            string query = @"
        SELECT u.Contrasena_Hash, u.Contrasena_Salt, r.Nombre_Rol 
        FROM usuario u
        JOIN usuario_x_rol uxr ON u.Id_Usuario = uxr.Id_Usuario
        JOIN rol r ON uxr.Id_Rol = r.Id_Rol
        WHERE u.Username = @user AND u.Estado = 'ACTIVO';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Enviamos la versión limpia a la consulta SQL
                    command.Parameters.AddWithValue("@user", usuarioLimpio);

                    try
                    {
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Se encontró el usuario. Leemos y limpiamos estrictamente los datos:
                                string hashAlmacenadoLimpio = reader["Contrasena_Hash"].ToString().Trim();
                                string saltAlmacenadoLimpio = reader["Contrasena_Salt"].ToString().Trim();
                                string rolUsuarioLimpio = reader["Nombre_Rol"].ToString().Trim();

                                // Verificación de seguridad usando la contraseña simple y los datos limpios de la DB
                                if (SeguridadUtils.VerificarContrasena(password, hashAlmacenadoLimpio, saltAlmacenadoLimpio))
                                {
                                    return rolUsuarioLimpio; // Autenticación Exitosa
                                }

                                // Si llega aquí, la contraseña es incorrecta
                                return null;
                            }
                            // Si reader.Read() es falso, significa que el usuario no existe.
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mantenemos tu manejo de errores
                        MessageBox.Show($"Error al intentar autenticar: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
        }
    }
}




