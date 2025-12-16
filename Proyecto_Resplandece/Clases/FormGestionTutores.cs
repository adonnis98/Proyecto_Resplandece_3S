using MySql.Data.MySqlClient;
using Proyecto_Resplandece;
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

namespace Proyecto_Resplandece.Clases
{
    public partial class FormRegistrarTutor : Form
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=bd_proyecto;Uid=root;Pwd=smilecry98;";
        private int idTutorSeleccionado = 0;

        public FormRegistrarTutor()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtNombresT.Clear();
            txtApellidosT.Clear();
            txtTelefonoT.Clear();
            txtEMinimaT.Clear();
            txtEMaximaT.Clear();
            txtNombresT.Focus();
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

        private void FormRegistrarTutor_Load(object sender, EventArgs e)
        {
            CargarDataGridViewTutores();
            LimpiarCampos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (idTutorSeleccionado != 0)
            {
                MessageBox.Show("Haga clic en Limpiar para crear un nuevo tutor.", "Modo Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string nombres = txtNombresT.Text.Trim();
            string apellidos = txtApellidosT.Text.Trim();
            string telefono = txtTelefonoT.Text.Trim();
            string edadMinimaStr = txtEMinimaT.Text.Trim();
            string edadMaximaStr = txtEMaximaT.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
            string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(edadMinimaStr) ||
            string.IsNullOrWhiteSpace(edadMaximaStr))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de Campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string checkQuery = "SELECT COUNT(*) FROM Tutor WHERE Nombres = @Nombres";// 5. Verificación de Tutor Duplicado
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection, transaction);
                    checkCmd.Parameters.AddWithValue("@Nombres", nombres);

                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ya existe un tutor registrado con estos nombres.", "Tutor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertTutorQuery = @"
                INSERT INTO Tutor (Nombres, Apellidos, Telefono, Edad_Minima, Edad_Maxima, Estado)
                VALUES (@Nombres, @Apellidos, @Telefono, @EdadMinima, @EdadMaxima, @Estado);";

                    MySqlCommand insertTutorCmd = new MySqlCommand(insertTutorQuery, connection, transaction);
                    insertTutorCmd.Parameters.AddWithValue("@Nombres", nombres);
                    insertTutorCmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    insertTutorCmd.Parameters.AddWithValue("@Telefono", telefono);
                    insertTutorCmd.Parameters.AddWithValue("@EdadMinima", edadMinimaStr); // El parámetro mantiene el nombre
                    insertTutorCmd.Parameters.AddWithValue("@EdadMaxima", edadMaximaStr); // El parámetro mantiene el nombre

                    insertTutorCmd.ExecuteNonQuery();
                    long lastInsertId = insertTutorCmd.LastInsertedId;

                    transaction.Commit();
                    MessageBox.Show($"¡Tutor '{nombres} {apellidos}' registrado con éxito!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDataGridViewTutores();
                }
                catch (MySqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error al guardar el tutor: {ex.Message} \n\nCódigo de Error SQL: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idTutorSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un Tutor de la lista para actualizar.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nombres = txtNombresT.Text.Trim();
            string apellidos = txtApellidosT.Text.Trim();
            string telefono = txtTelefonoT.Text.Trim();
            string edadMinimaStr = txtEMinimaT.Text.Trim();
            string edadMaximaStr = txtEMaximaT.Text.Trim();

            string estado = "ACTIVO";

            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
    string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(edadMinimaStr) ||
    string.IsNullOrWhiteSpace(edadMaximaStr))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de Campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string edadMinimaLimpia = edadMinimaStr.Replace(" meses", "").Replace(" año", "").Replace(" años", "").Trim();
            string edadMaximaLimpia = edadMaximaStr.Replace(" meses", "").Replace(" año", "").Replace(" años", "").Trim();

            if (!int.TryParse(edadMinimaLimpia, out int edadMinima) || !int.TryParse(edadMaximaLimpia, out int edadMaxima))
            {
                MessageBox.Show("Error: La edad contiene caracteres no válidos o el formato es incorrecto.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string updateTutorQuery = @"
                UPDATE Tutor 
                SET Nombres = @Nombres, 
                    Apellidos = @Apellidos, 
                    Telefono = @Telefono, 
                    Edad_Minima = @EdadMinima, 
                    Edad_Maxima = @EdadMaxima, 
                    Estado = @Estado
                WHERE Id_Tutor = @IdTutor;";

                    MySqlCommand updateTutorCmd = new MySqlCommand(updateTutorQuery, connection, transaction);

                    updateTutorCmd.Parameters.AddWithValue("@Nombres", nombres);
                    updateTutorCmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    updateTutorCmd.Parameters.AddWithValue("@Telefono", telefono);
                    updateTutorCmd.Parameters.AddWithValue("@EdadMinima", edadMinima);
                    updateTutorCmd.Parameters.AddWithValue("@EdadMaxima", edadMaxima);

                    updateTutorCmd.Parameters.AddWithValue("@Estado", estado);
                    updateTutorCmd.Parameters.AddWithValue("@IdTutor", idTutorSeleccionado);

                    int filasAfectadas = updateTutorCmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show($"¡Tutor '{nombres} {apellidos}' actualizado con éxito!", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarDataGridViewTutores();
                        idTutorSeleccionado = 0;
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("No se encontró el tutor para actualizar. ¿Fue eliminado recientemente?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (MySqlException ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Error al actualizar el tutor: {ex.Message} \n\nCódigo de Error SQL: {ex.Number}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show($"Ocurrió un error inesperado durante la actualización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ActualizarEstadoTutor(int userId, string nuevoEstado)
        {
            string query = "UPDATE tutor SET Estado = @Estado WHERE Id_Tutor = @Id";

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

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (idTutorSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un tutor antes de inactivar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show(
               $"¿Está seguro que desea INACTIVAR al tutor '{txtNombresT.Text} {txtApellidosT.Text}'?",
               "Confirmar Inactivación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (ActualizarEstadoTutor(idTutorSeleccionado, "INACTIVO"))
                {
                    MessageBox.Show($"Tutor '{txtNombresT.Text} {txtApellidosT.Text}' inactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDataGridViewTutores();
                }
            }

        }

        private DataTable ObtenerListaTutores()
        {
            string query = @"
   SELECT 
        Id_Tutor, Nombres, Apellidos, Telefono, Edad_Minima, Edad_Maxima, Estado
    FROM Tutor 
    ORDER BY Id_Tutor DESC;";

            DataTable dtTutores = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dtTutores);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar la lista de tutores: {ex.Message}", "Error de Base de Datos");
                    }
                }
            }
            return dtTutores;
        }

        private void CargarDataGridViewTutores()
        {
            dgvTutores.DataSource = ObtenerListaTutores();
            dgvTutores.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (dgvTutores.Columns.Contains("Id_Tutor"))
            {
                dgvTutores.Columns["Id_Tutor"].Visible = false;
            }
        }

        private void dgvTutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTutores.Rows[e.RowIndex];

                if (row.Cells["Id_Tutor"].Value != null)
                {
                    idTutorSeleccionado = Convert.ToInt32(row.Cells["Id_Tutor"].Value);

                    txtNombresT.Text = row.Cells["Nombres"].Value.ToString();
                    txtApellidosT.Text = row.Cells["Apellidos"].Value.ToString();
                    txtTelefonoT.Text = row.Cells["Telefono"].Value.ToString();

                    txtEMinimaT.Text = row.Cells["Edad_Minima"].Value.ToString();
                    txtEMaximaT.Text = row.Cells["Edad_Maxima"].Value.ToString();
                }
            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            if (idTutorSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un tutor antes de activar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea ACTIVAR al tutor '{txtNombresT.Text} {txtApellidosT.Text}'?",
                "Confirmar Activación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (ActualizarEstadoTutor(idTutorSeleccionado, "ACTIVO"))
                {
                    MessageBox.Show($"Tutor '{txtNombresT.Text} {txtApellidosT.Text}' activado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDataGridViewTutores();
                }
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
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
    }
}
