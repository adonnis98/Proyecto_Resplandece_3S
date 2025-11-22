using System;
using Proyecto_Resplandece.Clases.Base;
using BCrypt.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Resplandece
{
    public partial class FormRecuperarContrasena : Form
    {
        public FormRecuperarContrasena()
        {
            InitializeComponent();
        }

        private void FormRecuperarContrasena_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color colorArriba = Color.FromArgb(150, 150, 250); // 
            Color colorAbajo = Color.FromArgb(0, 153, 102);  // Un color azul (similar a tu imagen)

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

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string nuevaContrasena = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nuevaContrasena) || nuevaContrasena != confirmar)
            {
                MessageBox.Show("Verifique que el campo de usuario no esté vacío y que las contraseñas coincidan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new BaseDeDatos())
                {
                    // 1. Buscar el usuario por nombre
                    var userToUpdate = context.Usuarios
                                              .FirstOrDefault(u => u.Username.ToLower() == usuario.ToLower());

                    if (userToUpdate == null)
                    {
                        MessageBox.Show("Usuario no encontrado. Verifique el nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Generar el nuevo hash seguro
                    string nuevoHash = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);

                    // 3. Actualizar la base de datos
                    userToUpdate.ContrasenaHash = nuevoHash;

                    // 💡 IMPORTANTE: Si usas la columna ContrasenaSalt, debes dejarla nula, ya que BCrypt la integra en el hash.
                    // userToUpdate.ContrasenaSalt = null; 

                    context.SaveChanges();

                    MessageBox.Show("¡Contraseña restablecida con éxito! Ya puedes iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario de recuperación
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar restablecer la contraseña: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
