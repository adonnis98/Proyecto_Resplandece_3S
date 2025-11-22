using Proyecto_Resplandece.Clases.Base; // Para DbContext (BaseDeDatos)
using Proyecto_Resplandece.Models;     // Para el modelo Usuarios
using System;
using System.Linq;
using System.Windows.Forms;
using BCrypt.Net;  // Para el hashing seguro de contraseñas
// Los demás usings de System ya deben estar
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Resplandece
{
    public partial class FormGestionUsuarios : Form
    {
        // 💡 Variable global para saber si estamos editando (ID > 0) o creando (ID = 0)
        private int IdSeleccionado = 0;
        public FormGestionUsuarios()
        {
            InitializeComponent();
            ConfigurarRoles(); // Llamamos a la configuración de roles al iniciar
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        // --- CONFIGURACIÓN DE ROLES ---
        private void ConfigurarRoles()
        {
            // 1. Opciones que el usuario puede elegir
            if (cmbRol.Items.Count == 0)
            {
                cmbRol.Items.Add("Administrador");
                cmbRol.Items.Add("Usuario");
            }
            cmbRol.SelectedIndex = 1; // Selecciona "Usuario" por defecto
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // --- LECTURA (READ) ---
        private void CargarUsuarios()
        {
            try
            {
                using (var context = new BaseDeDatos())
                {
                    var listaUsuarios = context.Usuarios
                        .Select(u => new
                        {
                            u.Id,
                            u.Username,
                            u.Rol,
                            u.Codigo
                        })
                        .ToList();

                    dgvUsuarios.DataSource = listaUsuarios;
                    // Asumiendo que el campo 'UsuarioId' existe en tu DataGridView
                    if (dgvUsuarios.Columns.Contains("Id"))
                    {
                        dgvUsuarios.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- EVENTO: Carga los datos al hacer clic en una fila del DataGridView (CellClick es más confiable que CellContentClick)
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Cargar datos a las variables/campos
                IdSeleccionado = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["Id"].Value);
                txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                cmbRol.SelectedItem = dgvUsuarios.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
                string rol = dgvUsuarios.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
                if (cmbRol.Items.Contains(rol))
                {
                    cmbRol.SelectedItem = rol;
                }

                // Limpiar contraseña por seguridad
                txtContrasena.Clear();
                txtUsuario.Focus();
            }
        }


        // --- GUARDAR (CREATE/UPDATE) ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("El usuario y la contraseña son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new BaseDeDatos())
                {
                    Usuarios usuario;

                    if (IdSeleccionado == 0)
                    {
                        // MODO CREAR (CREATE)
                        usuario = new Usuarios();
                        context.Usuarios.Add(usuario);
                        // 💡 GENERACIÓN DEL CAMPO CÓDIGO (Temporal, se actualiza después del SaveChanges)
                        // Por ahora, lo dejamos vacío, ya que el ID (la clave para el código) se genera DESPUÉS de SaveChanges.
                        usuario.Codigo = "TEMP";
                    }
                    else
                    {
                        // MODO ACTUALIZAR (UPDATE)
                        // 💡 Usamos Find(IdSeleccionado)
                        usuario = context.Usuarios.Find(IdSeleccionado)!;
                        if (usuario == null)
                        {
                            MessageBox.Show("Error: Usuario a actualizar no encontrado en la base de datos.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Asignar valores
                    usuario.Username = username;
                    usuario.Rol = cmbRol.SelectedItem.ToString()!;

                    // Generar y asignar el nuevo hash de contraseña
                    string nuevoHash = BCrypt.Net.BCrypt.HashPassword(contrasena);
                    usuario.ContrasenaHash = nuevoHash;

                    context.SaveChanges();
                    // 💡 AJUSTE POST-GUARDADO: Si se acaba de crear, actualizamos el campo CÓDIGO con el nuevo ID generado.
                    if (IdSeleccionado == 0)
                    {
                        usuario.Codigo = "USER" + usuario.Id.ToString("0000"); // Ejemplo: USER0001
                        context.SaveChanges(); // Guardamos el código actualizado
                    }
                    MessageBox.Show("Usuario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar la lista y limpiar
                    CargarUsuarios();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- ELIMINAR (DELETE) ---
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var context = new BaseDeDatos())
                    {
                        var usuario = context.Usuarios.Find(IdSeleccionado);
                        if (usuario != null)
                        {
                            context.Usuarios.Remove(usuario);
                            context.SaveChanges();
                            MessageBox.Show("Usuario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarUsuarios();
                            LimpiarCampos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // --- NUEVO / LIMPIEZA ---
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            IdSeleccionado = 0; // Reiniciar ID para modo CREAR
            cmbRol.SelectedIndex = 1; // Rol por defecto
            txtUsuario.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
