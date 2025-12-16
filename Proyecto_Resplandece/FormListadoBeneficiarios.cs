using MySql.Data.MySqlClient;
using Proyecto_Resplandece.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Resplandece
{
    public partial class FormListadoBeneficiarios : Form
    {
        private const string connectionString = "Server=127.0.0.1;Port=3306;Database=bd_proyecto;Uid=root;Pwd=smilecry98;";
        public FormListadoBeneficiarios()
        {
            InitializeComponent();
            dgvBeneficiarios.CellDoubleClick += dgvBeneficiarios_CellContentDoubleClick;
            this.Load += FormListadoBeneficiarios_Load;
        }

        private void FormListadoBeneficiarios_Load(object sender, EventArgs e)
        {
            CargarComboBoxTutor();
        }

        private void CargarComboBoxTutor()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id_Tutor, CONCAT(Nombres, ' ', Apellidos) AS NombreCompleto FROM maestros WHERE Estado = 'ACTIVO' ORDER BY Nombres;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Añadir fila para "Mostrar Todos" (Id_Tutor = 0)
                        DataRow filaTodos = dt.NewRow();
                        filaTodos["Id_Tutor"] = 0;
                        filaTodos["NombreCompleto"] = "--- Mostrar Todos los Beneficiarios ---";
                        dt.Rows.InsertAt(filaTodos, 0);

                        cmbTutor.DataSource = dt;
                        cmbTutor.DisplayMember = "NombreCompleto";
                        cmbTutor.ValueMember = "Id_Tutor";
                        cmbTutor.SelectedIndex = 0; // Seleccionar "Mostrar Todos" por defecto
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la lista de tutores: {ex.Message}", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarListaBeneficiariosFiltrada(int idTutorFiltro)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    B.Id_Beneficiarios, 
                    B.Cedula, 
                    CONCAT(B.Nombres, ' ', B.Apellidos) AS NombreCompleto,
                    B.Estado,
                    T.Nombres AS TutorAsignado,
                    (YEAR(CURDATE()) - YEAR(B.Fecha_Nacimiento)) - (RIGHT(CURDATE(), 5) < RIGHT(B.Fecha_Nacimiento, 5)) AS EdadActual
                FROM beneficiarios B
                LEFT JOIN tutores T ON B.Id_Tutor = T.Id_Tutor
                WHERE 1=1"; // Clausula para facilitar la adición de filtros

                    if (idTutorFiltro > 0)
                    {
                        query += " AND B.Id_Tutor = @IdTutorFiltro";

                        // Aplicar el filtro de rango de edad del tutor
                        query += @" AND (
                                (YEAR(CURDATE()) - YEAR(B.Fecha_Nacimiento)) 
                                - (RIGHT(CURDATE(), 5) < RIGHT(B.Fecha_Nacimiento, 5)) 
                             BETWEEN T.Edad_Minima AND T.Edad_Maxima
                          )";
                    }
                    query += " AND B.Estado = 'ACTIVO' ORDER BY B.Nombres;";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        if (idTutorFiltro > 0)
                        {
                            cmd.Parameters.AddWithValue("@IdTutorFiltro", idTutorFiltro);
                        }

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvBeneficiarios.DataSource = dt;
                        dgvBeneficiarios.Columns["Id_Beneficiarios"].Visible = false;
                        dgvBeneficiarios.AutoResizeColumns();
                    }
                }
                catch (MySqlException mex)
                {
                    MessageBox.Show($"Error al cargar el listado filtrado: {mex.Message}", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {// Verifica si hay un valor seleccionado
            if (cmbTutor.SelectedValue != null && cmbTutor.SelectedValue != DBNull.Value)
            {
                int idTutorSeleccionado = Convert.ToInt32(cmbTutor.SelectedValue);
                CargarListaBeneficiariosFiltrada(idTutorSeleccionado);
            }
            else
            {
                // Si no hay nada seleccionado (aunque cmbTutor_Load selecciona 0), mostramos todos por seguridad
                CargarListaBeneficiariosFiltrada(0);
            }
        }

        private void dgvBeneficiarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {// Verifica que no se haga doble clic en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener la fila completa que fue seleccionada
            DataGridViewRow filaSeleccionada = dgvBeneficiarios.Rows[e.RowIndex];

            // Obtener el Id_Beneficiarios
            if (filaSeleccionada.Cells["Id_Beneficiarios"].Value == null)
            {
                MessageBox.Show("No se pudo obtener el ID del beneficiario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["Id_Beneficiarios"].Value);

            // Abrir el formulario de gestión y cargar datos
            FormGestionBeneficiarios gestionForm = new FormGestionBeneficiarios();

            // LLAMADA AL MÉTODO QUE DEBE ESTAR EN EL OTRO FORMULARIO
            gestionForm.CargarDatosPorId(idSeleccionado);

            gestionForm.Show();
            this.Close();
        }
    }
}
