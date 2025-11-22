using BCrypt.Net;
using Proyecto_Resplandece.Clases.Base;
using Proyecto_Resplandece.Models;
using System;
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
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nuevoUsuario = txtNuevoUsuario.Text.Trim();
            string contrasena = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;
            string rolAsignado = "Usuario"; // Rol por defecto

            // 1. VALIDACIONES INICIALES
            if (string.IsNullOrWhiteSpace(nuevoUsuario) || string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(confirmar))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. CONEXIÓN Y VERIFICACIÓN DE EXISTENCIA
            try
            {
                using (var context = new BaseDeDatos())
                {
                    // Verificar si el usuario ya existe en la base de datos.
                    bool usuarioYaExiste = context.Usuarios.Any(u => u.Username.ToLower() == nuevoUsuario.ToLower());

                    if (usuarioYaExiste)
                    {
                        MessageBox.Show("El nombre de usuario ya está en uso. Elija otro.", "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNuevoUsuario.Focus();
                        return;
                    }

                    string contrasenaHash = BCrypt.Net.BCrypt.HashPassword(contrasena);
                    string codigoTemporal = (nuevoUsuario.Length >= 3 ? nuevoUsuario.Substring(0, 3) : nuevoUsuario) + "-NEW";

                    var nuevoUser = new Usuarios
                    {
                        Codigo = codigoTemporal.ToUpper(), // Se asignará el código correcto después de guardar
                        Username = nuevoUsuario,
                        ContrasenaHash = contrasenaHash,
                        ContrasenaSalt = null, // BCrypt lo incluye en el hash, por eso lo dejamos nulo
                        Rol = rolAsignado
                    };

                    // 5. GUARDAR EN LA BASE DE DATOS
                    context.Usuarios.Add(nuevoUser); // Agregar a la tabla DbSet
                    context.SaveChanges();          // Ejecuta la inserción en SQL Server

                    MessageBox.Show($"¡Usuario '{nuevoUsuario}' registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Opcional: Cerrar el formulario y volver a la pantalla de Login
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar o guardar: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void linkVolverLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}


