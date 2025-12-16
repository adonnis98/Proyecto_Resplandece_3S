using BCrypt.Net;
using MySql.Data.MySqlClient;
using Proyecto_Resplandece;
using Proyecto_Resplandece.Clases;
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
    public partial class FormGestionUsuarios : Form
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=bd_proyecto;Uid=root;Pwd=smilecry98;";
        private int idUsuarioSeleccionado = 0;
        public FormGestionUsuarios()
        {
            InitializeComponent();
        }
        private void FormRegistro_Load(object sender, EventArgs e)
        {
            CargarDataGridView();
            CargarRolesEnComboBox();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombresU.Clear();
            txtApellidosU.Clear();
            txtUsernameU.Clear();
            txtContrasenaU.Clear();
            txtConfirmarContrasenaU.Clear(); // ¡Añadido!
            idUsuarioSeleccionado = 0;
            if (cbxRol.Items.Count > 0)
            {
                cbxRol.SelectedIndex = 0;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color colorArriba = Color.FromArgb(150, 150, 250);
            Color colorAbajo = Color.FromArgb(0, 153, 102);

            // Crea un objeto LinearGradientBrush para el degradado
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

        private void btnCrearU_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado != 0)
            {
                MessageBox.Show("Haga clic en Limpiar para crear un nuevo usuario.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string nombres = txtNombresU.Text.Trim();
            string apellidos = txtApellidosU.Text.Trim();
            string nuevoUsuario = txtUsernameU.Text.Trim();
            string contrasena = txtContrasenaU.Text;
            string confirmar = txtConfirmarContrasenaU.Text;
            string rolSeleccionado = cbxRol.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nuevoUsuario) || string.IsNullOrWhiteSpace(contrasena) ||
        string.IsNullOrWhiteSpace(confirmar) || string.IsNullOrWhiteSpace(nombres) ||
        string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(rolSeleccionado))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de Campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifique la Confirmación.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasenaU.Clear();
                txtConfirmarContrasenaU.Clear();
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string checkQuery = "SELECT COUNT(*) FROM usuario WHERE Username = @Usuario";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection, transaction);
                    checkCmd.Parameters.AddWithValue("@Usuario", nuevoUsuario);

                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show("El nombre de usuario ya está en uso.", "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string contrasenaHash, contrasenaSalt;
                    SeguridadUtils.GenerarHashSalt(contrasena, out contrasenaHash, out contrasenaSalt);

                    string insertUsuarioQuery = @"
                INSERT INTO usuario 
                (Username, Nombres, Apellidos, Contrasena_Hash, Contrasena_Salt, Estado) 
                VALUES (@Usuario, @Nombres, @Apellidos, @Hash, @Salt, 'ACTIVO');";

                    MySqlCommand insertUsuarioCmd = new MySqlCommand(insertUsuarioQuery, connection, transaction);
                    insertUsuarioCmd.Parameters.AddWithValue("@Usuario", nuevoUsuario);
                    insertUsuarioCmd.Parameters.AddWithValue("@Nombres", nombres);
                    insertUsuarioCmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    insertUsuarioCmd.Parameters.AddWithValue("@Hash", contrasenaHash);
                    insertUsuarioCmd.Parameters.AddWithValue("@Salt", contrasenaSalt);
                    /*insertUsuarioCmd.Parameters.AddWithValue("@RoleName", rolSeleccionado);*/
                    insertUsuarioCmd.ExecuteNonQuery();

                    long lastInsertId = insertUsuarioCmd.LastInsertedId;//

                    string insertRolQuery = @"
                INSERT INTO usuario_x_rol (Id_Usuario, Id_Rol, Estado)
                SELECT @ID_USUARIO, r.Id_Rol, 'ACTIVO'
                FROM rol r
                WHERE r.Nombre_Rol = @RoleName;";

                    MySqlCommand insertRolCmd = new MySqlCommand(insertRolQuery, connection, transaction);
                    insertRolCmd.Parameters.AddWithValue("@ID_USUARIO", lastInsertId); // Usamos el ID de la inserción previa
                    insertRolCmd.Parameters.AddWithValue("@RoleName", rolSeleccionado); // Usamos el rol seleccionado

                    if (insertRolCmd.ExecuteNonQuery() > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show($"¡Usuario '{nuevoUsuario}' ({rolSeleccionado}) registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDataGridView();
                        LimpiarCampos();
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al asignar el rol. Se deshizo el registro de usuario.", "Error de Rol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (MySqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error al guardar: {ex.Message} \n\nCódigo de Error SQL: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiarU_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizarU_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario antes de hacer clic en Actualizar.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoUsername = txtUsernameU.Text.Trim();
            string nuevosNombres = txtNombresU.Text.Trim();
            string nuevosApellidos = txtApellidosU.Text.Trim();
            string nuevoRol = cbxRol.SelectedItem?.ToString();
            string contrasenaNueva = txtContrasenaU.Text;
            string confirmarContrasena = txtConfirmarContrasenaU.Text;

            if (string.IsNullOrWhiteSpace(nuevoUsername) || string.IsNullOrWhiteSpace(nuevosNombres) ||
                string.IsNullOrWhiteSpace(nuevosApellidos) || string.IsNullOrWhiteSpace(nuevoRol))
            {
                MessageBox.Show("Los campos obligatorios no pueden estar vacíos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(contrasenaNueva) || !string.IsNullOrWhiteSpace(confirmarContrasena))
            {
                if (contrasenaNueva != confirmarContrasena)
                {
                    MessageBox.Show("Las nuevas contraseñas no coinciden.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string updateUsuarioQuery = @"
                UPDATE usuario 
                SET Username = @Username, 
                    Nombres = @Nombres, 
                    Apellidos = @Apellidos
                    {0} 
                WHERE Id_Usuario = @IdUsuario;
            ";

                    string passwordUpdateClause = "";
                    string contrasenaHash = null;
                    string contrasenaSalt = null;

                    if (!string.IsNullOrWhiteSpace(contrasenaNueva))
                    {
                        SeguridadUtils.GenerarHashSalt(contrasenaNueva, out contrasenaHash, out contrasenaSalt);
                        passwordUpdateClause = ", Contrasena_Hash = @Hash, Contrasena_Salt = @Salt";
                    }

                    updateUsuarioQuery = string.Format(updateUsuarioQuery, passwordUpdateClause);

                    MySqlCommand updateUsuarioCmd = new MySqlCommand(updateUsuarioQuery, connection, transaction);
                    updateUsuarioCmd.Parameters.AddWithValue("@IdUsuario", idUsuarioSeleccionado);
                    updateUsuarioCmd.Parameters.AddWithValue("@Username", nuevoUsername);
                    updateUsuarioCmd.Parameters.AddWithValue("@Nombres", nuevosNombres);
                    updateUsuarioCmd.Parameters.AddWithValue("@Apellidos", nuevosApellidos);

                    if (!string.IsNullOrWhiteSpace(contrasenaNueva))
                    {
                        updateUsuarioCmd.Parameters.AddWithValue("@Hash", contrasenaHash);
                        updateUsuarioCmd.Parameters.AddWithValue("@Salt", contrasenaSalt);
                    }

                    updateUsuarioCmd.ExecuteNonQuery();

                    string getRolIdQuery = "SELECT Id_Rol FROM rol WHERE Nombre_Rol = @RoleName LIMIT 1";
                    MySqlCommand getRolCmd = new MySqlCommand(getRolIdQuery, connection, transaction);
                    getRolCmd.Parameters.AddWithValue("@RoleName", nuevoRol);

                    object rolIdObj = getRolCmd.ExecuteScalar();
                    if (rolIdObj == null)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: El rol '{nuevoRol}' no fue encontrado.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int idNuevoRol = Convert.ToInt32(rolIdObj);

                    string deleteRolQuery = "DELETE FROM usuario_x_rol WHERE Id_Usuario = @IdUsuario";
                    MySqlCommand deleteRolCmd = new MySqlCommand(deleteRolQuery, connection, transaction);
                    deleteRolCmd.Parameters.AddWithValue("@IdUsuario", idUsuarioSeleccionado);
                    deleteRolCmd.ExecuteNonQuery();

                    string insertRolQuery = @"
                INSERT INTO usuario_x_rol (Id_Usuario, Id_Rol, Estado)
                VALUES (@IdUsuario, @IdRol, 'ACTIVO');";
                    MySqlCommand insertRolCmd = new MySqlCommand(insertRolQuery, connection, transaction);
                    insertRolCmd.Parameters.AddWithValue("@IdUsuario", idUsuarioSeleccionado);
                    insertRolCmd.Parameters.AddWithValue("@IdRol", idNuevoRol);
                    insertRolCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDataGridView();
                }
                catch (MySqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error al actualizar: {ex.Message} \n\nCódigo de Error SQL: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Ocurrió un error inesperado durante la actualización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }







        private bool ActualizarEstadoUsuario(int userId, string nuevoEstado)
        {
            string query = "UPDATE usuario SET Estado = @Estado WHERE Id_Usuario = @Id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userId);
                    command.Parameters.AddWithValue("@Estado", nuevoEstado);
                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar estado: {ex.Message}", "Error de DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void btnInactivarU_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario antes de inactivar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea INACTIVAR al usuario '{txtUsernameU.Text}'?",
                "Confirmar Inactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ActualizarEstadoUsuario(idUsuarioSeleccionado, "INACTIVO"))
                {
                    MessageBox.Show($"Usuario '{txtUsernameU.Text}' inactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDataGridView();
                }
            }
        }

        private void btnActivarU_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario antes de activar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea ACTIVAR al usuario '{txtUsernameU.Text}'?",
                "Confirmar Activación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ActualizarEstadoUsuario(idUsuarioSeleccionado, "ACTIVO"))
                {
                    MessageBox.Show($"Usuario '{txtUsernameU.Text}' activado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDataGridView();
                }
            }
        }

        private void CargarRolesEnComboBox()
        {
            string query = "SELECT Nombre_Rol FROM rol WHERE Estado = 'ACTIVO'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();
                        cbxRol.Items.Clear();
                        while (reader.Read())
                        {
                            cbxRol.Items.Add(reader["Nombre_Rol"].ToString());
                        }
                        reader.Close();
                        if (cbxRol.Items.Count > 0)
                        {
                            cbxRol.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error de Base de Datos");
                    }
                }
            }
        }

        private DataTable ObtenerListaUsuarios()
        {
            string query = @"
        SELECT 
            u.Id_Usuario, u.Username, u.Nombres, u.Apellidos, u.Estado,
            r.Nombre_Rol 
        FROM usuario u
        JOIN usuario_x_rol uxr ON u.Id_Usuario = uxr.Id_Usuario
        JOIN rol r ON uxr.Id_Rol = r.Id_Rol
        ORDER BY u.Id_Usuario DESC;";

            DataTable dtUsuarios = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dtUsuarios);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la lista de usuarios: {ex.Message}", "Error de Base de Datos");
                    }
                }
            }
            return dtUsuarios;
        }

        private void CargarDataGridView()
        {
            dgvUsuarios.DataSource = ObtenerListaUsuarios();
            dgvUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (dgvUsuarios.Columns.Contains("Id_Usuario"))
            {
                dgvUsuarios.Columns["Id_Usuario"].Visible = false;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];

                if (row.Cells["Id_Usuario"].Value != null)
                {
                    idUsuarioSeleccionado = Convert.ToInt32(row.Cells["Id_Usuario"].Value);

                    // Cargar datos
                    txtNombresU.Text = row.Cells["Nombres"].Value.ToString();
                    txtApellidosU.Text = row.Cells["Apellidos"].Value.ToString();
                    txtUsernameU.Text = row.Cells["Username"].Value.ToString();

                    // Cargar Rol
                    string rolActual = row.Cells["Nombre_Rol"].Value.ToString();
                    cbxRol.SelectedItem = rolActual;

                    // Limpiar contraseñas
                    txtContrasenaU.Clear();
                    txtConfirmarContrasenaU.Clear();
                }
            }
        }


    }
}



