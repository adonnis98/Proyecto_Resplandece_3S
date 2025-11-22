using Proyecto_Resplandece.Clases.Base;
using Proyecto_Resplandece.Models;    
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
        public FormIniciarSesion()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Intenta autenticar a un usuario y devuelve su Rol si es exitoso, o null si falla.
        /// </summary>
        private string AutenticarUsuario(string username, string password)
        {
            try
            {
                using (var context = new BaseDeDatos())
                {
                    var userInDb = context.Usuarios
                                         .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

                    if (userInDb == null)
                    {
                        return null; // Usuario no encontrado
                    }

                    // 1. Verificar la contraseña
                    if (BCrypt.Net.BCrypt.Verify(password, userInDb.ContrasenaHash))
                    {
                        // 2. Si la verificación es exitosa, devolvemos el Rol
                        return userInDb.Rol;
                    }

                    return null; // Contraseña incorrecta
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores de conexión o base de datos.
                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color colorArriba = Color.FromArgb(150, 150, 250);
            Color colorAbajo = Color.FromArgb(0, 153, 102);  

            // Crea un objeto LinearGradientBrush
            LinearGradientBrush pincelDegradado = new LinearGradientBrush
             (
                  panel1.ClientRectangle, // El área a dibujar (todo el Panel)
                  colorArriba,            // El color inicial (arriba)
                  colorAbajo,             // El color final (abajo) 
                  LinearGradientMode.BackwardDiagonal // La dirección del degradado: de arriba a abajo
             );
            e.Graphics.FillRectangle(pincelDegradado, panel1.ClientRectangle);
            pincelDegradado.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Lógica para abrir el formulario de registro (FormRegistro)
            this.Hide();
            // Asegúrate de que tu formulario de registro se llama FormRegistro o Form2 (si ese es tu nombre)
            FormRegistro registro = new FormRegistro();
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

            // Llamamos a la función de autenticación (que ahora devuelve el Rol si tiene éxito)
            string userRol = AutenticarUsuario(usuarioIngresado, contrasenaIngresada);

            // Si el Rol no es nulo/vacío, el inicio de sesión es exitoso
            if (!string.IsNullOrEmpty(userRol))
            {
                // 💡 1. GUARDAR LA SESIÓN DEL USUARIO
                SessionManager.Username = usuarioIngresado;
                SessionManager.Rol = userRol;
                // Asume que tu modelo Usuario tiene una columna 'Rol'

                // ÉXITO: Abrir Formulario Principal
                MessageBox.Show($"¡Inicio de sesión exitoso! Bienvenido/a {usuarioIngresado} (Rol: {userRol}).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormMenuPrincipal menu = new FormMenuPrincipal();
                menu.Show();
            }
            else
            {
                // ERROR (AutenticarUsuario devolvió null)
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }

        private void linkOlvideContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de recuperación
            FormRecuperarContrasena recuperarForm = new FormRecuperarContrasena();
            recuperarForm.ShowDialog();

            // Mostrar de nuevo la ventana de Login al cerrarse el de recuperación
            this.Show();
        }
    }
}
