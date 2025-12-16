
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
    public partial class FormGestionBeneficiarios : Form
    {
        private int IdBeneficiarioActual = 0;
        private readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=bd_proyecto;Uid=root;Pwd=smilecry98;";

        public FormGestionBeneficiarios()
        {
            InitializeComponent();
        }
        
        private void FormGestionBeneficiarios_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // Campos del Beneficiario
            txtCedula.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            cmbGenero.SelectedIndex = -1; // Deselecciona ComboBox
            dtpFechaNacimiento.Value = DateTime.Today;

            cmbDiscapacidad.SelectedIndex = -1;
            txtDiscapacidad.Text = string.Empty; // Asumiendo txtTipoDiscapacidad

            txtEscuela.Text = string.Empty;
            txtCurso.Text = string.Empty;
            cmbAplicaBeca.SelectedIndex = -1;
            // txtEstado.Text = "ACTIVO"; // O se deja vacío, dependiendo de si muestra el estado.

            // Campos del Representante Legal
            txtCedulaRe.Text = string.Empty;
            txtNombresRe.Text = string.Empty;
            txtApellidosRe.Text = string.Empty;
            txtTelefonoRe.Text = string.Empty;
            txtParentesco.Text = string.Empty;
            txtEmail.Text = string.Empty;

            // Variables internas críticas
            IdBeneficiarioActual = 0; // Importante para desvincular el ID de la sesión actual

            // MessageBox.Show("Campos de registro limpiados.", "Limpieza", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            int edad = CalcularEdad(fechaNacimiento);
            // txtEdadActual.Text = edad.ToString();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Limpiamos la variable de sesión y la interfaz antes de consultar
            LimpiarCampos();
            IdBeneficiarioActual = 0; // Aseguramos que no haya un ID anterior

            string cedulaConsulta = txtCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedulaConsulta))
            {
                MessageBox.Show("Por favor, ingrese la Cédula del Beneficiario a consultar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // --- 1. CONSULTAR DATOS DEL BENEFICIARIO (Ignorando Id_Tutor para la interfaz) ---
                    string queryBenef = @"
                SELECT 
                    Id_Beneficiarios, Nombres, Apellidos, Domicilio, Genero, Fecha_Nacimiento,
                    Discapacidad, Tipo_Discapacidad, Escuela, Curso, `Aplica Beca`, Estado
                FROM beneficiarios
                WHERE Cedula = @CedulaConsulta;";

                    int idBeneficiario = 0;

                    using (var cmdBenef = new MySqlCommand(queryBenef, conn))
                    {
                        cmdBenef.Parameters.AddWithValue("@CedulaConsulta", cedulaConsulta);
                        using (var reader = cmdBenef.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Cargar variables internas
                                idBeneficiario = reader.GetInt32("Id_Beneficiarios");

                                // Cargar campos del Beneficiario
                                txtNombres.Text = reader.GetString("Nombres");
                                txtApellidos.Text = reader.GetString("Apellidos");
                                txtDomicilio.Text = reader.GetString("Domicilio");
                                cmbGenero.SelectedItem = reader.GetString("Genero");
                                dtpFechaNacimiento.Value = reader.GetDateTime("Fecha_Nacimiento");

                                // Conversiones a ComboBox Sí/No
                                cmbDiscapacidad.SelectedItem = (reader.GetInt32("Discapacidad") == 1) ? "Sí" : "No";
                                txtDiscapacidad.Text = reader.GetString("Tipo_Discapacidad"); // Asumiendo txtTipoDiscapacidad

                                txtEscuela.Text = reader.GetString("Escuela");
                                txtCurso.Text = reader.GetString("Curso");

                                cmbAplicaBeca.SelectedItem = (reader.GetInt32("Aplica Beca") == 1) ? "Sí" : "No";
                                // Asumiendo que 'Estado' es un control de texto:
                                // txtEstado.Text = reader.GetString("Estado"); 

                                MessageBox.Show("Beneficiario consultado con éxito.", "Consulta Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún Beneficiario con esa Cédula.", "Consulta Fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return; // Salimos si no hay beneficiario
                            }
                        }
                    }

                    // Guardamos el ID para Actualizar/Activar/Inactivar
                    IdBeneficiarioActual = idBeneficiario;

                    // --- 2. CONSULTAR DATOS DEL REPRESENTANTE LEGAL ASOCIADO ---
                    string queryRep = @"
                SELECT 
                    R.Cedula, R.Nombres, R.Apellidos, R.Telefono, R.Parentesco, R.Correo
                FROM representantes R
                INNER JOIN beneficiario_x_representante BXR ON R.Id_Representante = BXR.Id_Representante
                WHERE BXR.Id_Beneficiario = @IdBeneficiario AND BXR.Estado = 'ACTIVO';";

                    using (var cmdRep = new MySqlCommand(queryRep, conn))
                    {
                        cmdRep.Parameters.AddWithValue("@IdBeneficiario", idBeneficiario);
                        using (var readerRep = cmdRep.ExecuteReader())
                        {
                            if (readerRep.Read())
                            {
                                // Cargar campos del Representante Legal
                                txtCedulaRe.Text = readerRep.GetString("Cedula");
                                txtNombresRe.Text = readerRep.GetString("Nombres");
                                txtApellidosRe.Text = readerRep.GetString("Apellidos");
                                txtTelefonoRe.Text = readerRep.GetString("Telefono");
                                txtParentesco.Text = readerRep.GetString("Parentesco");
                                txtEmail.Text = readerRep.GetString("Correo");
                            }
                        }
                    }
                }
                catch (MySqlException mex)
                {
                    MessageBox.Show($"Error de base de datos al consultar: {mex.Message} (Código {mex.Number})", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al consultar: {ex.Message}", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string domicilio = txtDomicilio.Text.Trim();
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(domicilio))
            {
                MessageBox.Show("Cédula, Nombres, Apellidos y Domicilio del Beneficiario son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaNacimiento = dtpFechaNacimiento.Value.Date;
            string genero = cmbGenero.SelectedItem?.ToString() ?? "N/A";

            int discapacidad = (cmbDiscapacidad.SelectedItem?.ToString().Equals("Sí", StringComparison.OrdinalIgnoreCase) == true) ? 1 : 0;
            int aplicaBeca = (cmbAplicaBeca.SelectedItem?.ToString().Equals("Sí", StringComparison.OrdinalIgnoreCase) == true) ? 1 : 0;

            string becadoValue = (aplicaBeca == 1) ? "Si" : "No";

            string tipoDiscapacidad = txtDiscapacidad.Text.Trim(); 
            string escuela = txtEscuela.Text.Trim();
            string curso = txtCurso.Text.Trim();
            string estado = "ACTIVO";

            // *** CORRECCIÓN CLAVE: ID_TUTOR NO ESTÁ EN EL FORMULARIO, ASIGNAMOS NULL ***
            object idTutor = DBNull.Value;
            // Si su columna Id_Tutor en la BD no acepta NULL, cambie la línea anterior por:
            // object idTutor = 1; // Donde 1 es un ID de tutor válido por defecto.

            string cedulaRe = txtCedulaRe.Text.Trim();
            string nombresRe = txtNombresRe.Text.Trim();
            string apellidosRe = txtApellidosRe.Text.Trim();
            string telefonoRe = txtTelefonoRe.Text.Trim();
            string parentescoRe = txtParentesco.Text.Trim();
            string correoRe = txtEmail.Text.Trim();
            string estadoRe = "ACTIVO";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertBenef = @"
                    INSERT INTO beneficiarios
                    (Cedula, Nombres, Apellidos, Domicilio, Genero, Fecha_Nacimiento,
                     Discapacidad, Tipo_Discapacidad, Escuela, Curso, `Aplica Beca`, 
                     Becado, Estado, Id_Tutor, Fecha_Creacion, Fecha_Modificacion)
                    VALUES
                    (@Cedula, @Nombres, @Apellidos, @Domicilio, @Genero, @FechaNacimiento,
                     @Discapacidad, @TipoDiscapacidad, @Escuela, @Curso, @AplicaBeca,
                     @Becado, @Estado, @IdTutor, NOW(), NOW()); 
                    SELECT LAST_INSERT_ID();";

                        using (var cmd = new MySqlCommand(insertBenef, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Cedula", cedula);
                            cmd.Parameters.AddWithValue("@Nombres", nombres);
                            cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                            cmd.Parameters.AddWithValue("@Domicilio", domicilio);
                            cmd.Parameters.AddWithValue("@Genero", genero);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                            cmd.Parameters.AddWithValue("@Discapacidad", discapacidad);
                            cmd.Parameters.AddWithValue("@TipoDiscapacidad", tipoDiscapacidad);
                            cmd.Parameters.AddWithValue("@Escuela", escuela);
                            cmd.Parameters.AddWithValue("@Curso", curso);
                            cmd.Parameters.AddWithValue("@AplicaBeca", aplicaBeca);
                            cmd.Parameters.AddWithValue("@Becado", becadoValue);
                            cmd.Parameters.AddWithValue("@Estado", estado);
                            cmd.Parameters.AddWithValue("@IdTutor", idTutor); // Valor NULL o por defecto

                            object result = cmd.ExecuteScalar();
                            int idBeneficiario = Convert.ToInt32(result);
                            IdBeneficiarioActual = idBeneficiario;

                            if (!string.IsNullOrEmpty(cedulaRe))
                            {
                                string insertRep = @"
                            INSERT INTO representantes
                            (Cedula, Nombres, Apellidos, Telefono, Parentesco, Correo, Estado)
                            VALUES
                            (@RCedula, @RNombres, @RApellidos, @RTelefono, @RParentesco, @RCorreo, @REstado);
                            SELECT LAST_INSERT_ID();";

                                using (var cmdRep = new MySqlCommand(insertRep, conn, transaction))
                                {
                                    cmdRep.Parameters.AddWithValue("@RCedula", cedulaRe);
                                    cmdRep.Parameters.AddWithValue("@RNombres", nombresRe);
                                    cmdRep.Parameters.AddWithValue("@RApellidos", apellidosRe);
                                    cmdRep.Parameters.AddWithValue("@RTelefono", telefonoRe);
                                    cmdRep.Parameters.AddWithValue("@RParentesco", parentescoRe);
                                    cmdRep.Parameters.AddWithValue("@RCorreo", correoRe);
                                    cmdRep.Parameters.AddWithValue("@REstado", estadoRe);

                                    object repResult = cmdRep.ExecuteScalar();
                                    int idRepresentante = Convert.ToInt32(repResult);

                                    string insertInter = @"
                                INSERT INTO beneficiario_x_representante
                                (Id_Beneficiario, Id_Representante, Fecha_Asignacion, Estado)
                                VALUES
                                (@IdBeneficiario, @IdRepresentante, NOW(), @REstado);";

                                    using (var cmdInter = new MySqlCommand(insertInter, conn, transaction))
                                    {
                                        cmdInter.Parameters.AddWithValue("@IdBeneficiario", idBeneficiario);
                                        cmdInter.Parameters.AddWithValue("@IdRepresentante", idRepresentante);
                                        cmdInter.Parameters.AddWithValue("@REstado", estadoRe);
                                        cmdInter.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Beneficiario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos(); 
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error SQL al crear beneficiario: {mex.Message} (Código {mex.Number})", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            MessageBox.Show("Campos de registro limpiados.", "Limpieza", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (IdBeneficiarioActual <= 0)
            {
                MessageBox.Show("Debe consultar un Beneficiario primero para obtener su ID y poder actualizar.", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cedula = txtCedula.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string domicilio = txtDomicilio.Text.Trim();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value.Date;
            string genero = cmbGenero.SelectedItem?.ToString() ?? "N/A";

            int discapacidad = (cmbDiscapacidad.SelectedItem?.ToString().Equals("Sí", StringComparison.OrdinalIgnoreCase) == true) ? 1 : 0;
            int aplicaBeca = (cmbAplicaBeca.SelectedItem?.ToString().Equals("Sí", StringComparison.OrdinalIgnoreCase) == true) ? 1 : 0;

            string becadoValue = (aplicaBeca == 1) ? "Si" : "No";

            string tipoDiscapacidad = txtDiscapacidad.Text.Trim();
            string escuela = txtEscuela.Text.Trim();
            string curso = txtCurso.Text.Trim();

            // *** CORRECCIÓN CLAVE: ID_TUTOR NO USADO EN EL FORMULARIO ***
            // Si la BD permite NULL, mantenemos el valor nulo al actualizar:
            object idTutor = DBNull.Value;
            // Si la BD NO permite NULL, debe asignarse un ID válido (ej: 1) o el ID existente si lo consultó previamente.

            string cedulaRe = txtCedulaRe.Text.Trim();
            string nombresRe = txtNombresRe.Text.Trim();
            string apellidosRe = txtApellidosRe.Text.Trim();
            string telefonoRe = txtTelefonoRe.Text.Trim();
            string parentescoRe = txtParentesco.Text.Trim();
            string correoRe = txtEmail.Text.Trim();
            string estadoRe = "ACTIVO";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updateBenef = @"
                    UPDATE beneficiarios SET
                        Cedula = @Cedula,
                        Nombres = @Nombres,
                        Apellidos = @Apellidos,
                        Domicilio = @Domicilio,
                        Genero = @Genero,
                        Fecha_Nacimiento = @FechaNacimiento,
                        Discapacidad = @Discapacidad,
                        Tipo_Discapacidad = @TipoDiscapacidad,
                        Escuela = @Escuela,
                        Curso = @Curso,
                        `Aplica Beca` = @AplicaBeca,
                        Becado = @Becado, 
                        Id_Tutor = @IdTutor, 
                        Fecha_Modificacion = NOW()
                    WHERE Id_Beneficiarios = @IdBeneficiario;";

                        using (var cmd = new MySqlCommand(updateBenef, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Cedula", cedula);
                            cmd.Parameters.AddWithValue("@Nombres", nombres);
                            cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                            cmd.Parameters.AddWithValue("@Domicilio", domicilio);
                            cmd.Parameters.AddWithValue("@Genero", genero);
                            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                            cmd.Parameters.AddWithValue("@Discapacidad", discapacidad);
                            cmd.Parameters.AddWithValue("@TipoDiscapacidad", tipoDiscapacidad);
                            cmd.Parameters.AddWithValue("@Escuela", escuela);
                            cmd.Parameters.AddWithValue("@Curso", curso);
                            cmd.Parameters.AddWithValue("@AplicaBeca", aplicaBeca);
                            cmd.Parameters.AddWithValue("@Becado", becadoValue);
                            cmd.Parameters.AddWithValue("@IdTutor", idTutor); 
                            cmd.Parameters.AddWithValue("@IdBeneficiario", IdBeneficiarioActual);

                            cmd.ExecuteNonQuery();
                        }

                        if (!string.IsNullOrEmpty(cedulaRe))
                        {
                            int idRepresentanteActual = ObtenerIdRepresentanteAsociado(conn, transaction, IdBeneficiarioActual);

                            if (idRepresentanteActual > 0)
                            {
                                // B.1) ACTUALIZAR REPRESENTANTE EXISTENTE
                                string updateRep = @"
                            UPDATE representantes SET
                                Cedula = @RCedula,
                                Nombres = @RNombres,
                                Apellidos = @RApellidos,
                                Telefono = @RTelefono,
                                Parentesco = @RParentesco,
                                Correo = @RCorreo
                            WHERE Id_Representante = @IdRepresentante;";

                                using (var cmdRep = new MySqlCommand(updateRep, conn, transaction))
                                {
                                    cmdRep.Parameters.AddWithValue("@RCedula", cedulaRe);
                                    cmdRep.Parameters.AddWithValue("@RNombres", nombresRe);
                                    cmdRep.Parameters.AddWithValue("@RApellidos", apellidosRe);
                                    cmdRep.Parameters.AddWithValue("@RTelefono", telefonoRe);
                                    cmdRep.Parameters.AddWithValue("@RParentesco", parentescoRe);
                                    cmdRep.Parameters.AddWithValue("@RCorreo", correoRe);
                                    cmdRep.Parameters.AddWithValue("@IdRepresentante", idRepresentanteActual);
                                    cmdRep.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string insertRep = @"
                            INSERT INTO representantes
                            (Cedula, Nombres, Apellidos, Telefono, Parentesco, Correo, Estado)
                            VALUES
                            (@RCedula, @RNombres, @RApellidos, @RTelefono, @RParentesco, @RCorreo, @REstado);
                            SELECT LAST_INSERT_ID();";

                                using (var cmdRep = new MySqlCommand(insertRep, conn, transaction))
                                {
                                    cmdRep.Parameters.AddWithValue("@RCedula", cedulaRe);
                                    cmdRep.Parameters.AddWithValue("@RNombres", nombresRe);
                                    cmdRep.Parameters.AddWithValue("@RApellidos", apellidosRe);
                                    cmdRep.Parameters.AddWithValue("@RTelefono", telefonoRe);
                                    cmdRep.Parameters.AddWithValue("@RParentesco", parentescoRe);
                                    cmdRep.Parameters.AddWithValue("@RCorreo", correoRe);
                                    cmdRep.Parameters.AddWithValue("@REstado", estadoRe);

                                    object repResult = cmdRep.ExecuteScalar();
                                    int nuevoIdRepresentante = Convert.ToInt32(repResult);

                                    string insertInter = @"
                                INSERT INTO beneficiario_x_representante
                                (Id_Beneficiario, Id_Representante, Fecha_Asignacion, Estado)
                                VALUES
                                (@IdBeneficiario, @IdRepresentante, NOW(), @REstado);";

                                    using (var cmdInter = new MySqlCommand(insertInter, conn, transaction))
                                    {
                                        cmdInter.Parameters.AddWithValue("@IdBeneficiario", IdBeneficiarioActual);
                                        cmdInter.Parameters.AddWithValue("@IdRepresentante", nuevoIdRepresentante);
                                        cmdInter.Parameters.AddWithValue("@REstado", estadoRe);
                                        cmdInter.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Beneficiario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error SQL al actualizar: {mex.Message} (Código {mex.Number})", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ocurrió un error al actualizar: {ex.Message}", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int ObtenerIdRepresentanteAsociado(MySqlConnection conn, MySqlTransaction transaction, int idBeneficiario)
        {
            string query = @"
        SELECT R.Id_Representante 
        FROM representantes R
        INNER JOIN beneficiario_x_representante BXR ON R.Id_Representante = BXR.Id_Representante
        WHERE BXR.Id_Beneficiario = @IdBeneficiario AND BXR.Estado = 'ACTIVO';";

            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@IdBeneficiario", idBeneficiario);

                // Usamos ExecuteScalar para obtener un único valor (el ID del representante)
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                return 0; // Retorna 0 si no encuentra un representante asociado
            }
        }

        private void CambiarEstadoBeneficiario(string nuevoEstado, string operacion)
        {
            // Verificación de ID
            if (IdBeneficiarioActual <= 0)
            {
                MessageBox.Show($"Debe consultar un Beneficiario primero para poder {operacion.ToLower()}.", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación del usuario
            if (MessageBox.Show($"¿Está seguro que desea {operacion.ToLower()} al Beneficiario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (var conn = new MySqlConnection(connectionString)) // Asegure que 'connectionString' esté definida
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. ACTUALIZAR EL ESTADO DEL BENEFICIARIO
                        string updateBenef = @"
                    UPDATE beneficiarios SET 
                        Estado = @Estado, 
                        Fecha_Modificacion = NOW()
                    WHERE Id_Beneficiarios = @IdBeneficiario;";

                        using (var cmd = new MySqlCommand(updateBenef, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                            cmd.Parameters.AddWithValue("@IdBeneficiario", IdBeneficiarioActual);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. ACTUALIZAR EL ESTADO DE LA RELACIÓN BENEFICIARIO_X_REPRESENTANTE
                        // Esto es importante para mantener la coherencia en la tabla intermedia.
                        string updateRelacion = @"
                    UPDATE beneficiario_x_representante SET 
                        Estado = @Estado,
                        Fecha_Modificacion = NOW()
                    WHERE Id_Beneficiario = @IdBeneficiario;";

                        using (var cmdRel = new MySqlCommand(updateRelacion, conn, transaction))
                        {
                            cmdRel.Parameters.AddWithValue("@Estado", nuevoEstado);
                            cmdRel.Parameters.AddWithValue("@IdBeneficiario", IdBeneficiarioActual);
                            cmdRel.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show($"Beneficiario {operacion} con éxito. Nuevo estado: {nuevoEstado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Si su formulario muestra el estado, actualice el campo aquí (ejemplo):
                        // txtEstado.Text = nuevoEstado;
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error SQL al {operacion.ToLower()} el beneficiario: {mex.Message} (Código {mex.Number})", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ocurrió un error al {operacion.ToLower()}: {ex.Message}", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            CambiarEstadoBeneficiario("ACTIVO", "Activar");
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            CambiarEstadoBeneficiario("INACTIVO", "Inactivar");
        }

        private void CargarOpcionesComboBoxes()
        {
            // Opciones de Género
            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.SelectedIndex = -1; // No selecciona ninguno por defecto

            // Opciones Sí/No para Discapacidad
            cmbDiscapacidad.Items.Clear();
            cmbDiscapacidad.Items.Add("Sí");
            cmbDiscapacidad.Items.Add("No");
            cmbDiscapacidad.SelectedItem = "No"; // Por defecto 'No'

            // Opciones Sí/No para Aplica Beca
            cmbAplicaBeca.Items.Clear();
            cmbAplicaBeca.Items.Add("Sí");
            cmbAplicaBeca.Items.Add("No");
            cmbAplicaBeca.SelectedItem = "No"; // Por defecto 'No'
        }

        /// <summary>
        /// Carga los datos de un Beneficiario y su Representante usando su ID primario.
        /// Este método se usa al navegar desde el Listado.
        /// </summary>
        /// <param name="id">Id_Beneficiarios del registro a cargar.</param>
        public void CargarDatosPorId(int id)
        {
            // Asegúrate de que LimpiarCampos() y IdBeneficiarioActual estén definidos y sean accesibles.
            LimpiarCampos();

            if (id <= 0)
            {
                MessageBox.Show("ID de Beneficiario inválido.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Asegúrate de que 'connectionString' esté accesible en esta clase
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    IdBeneficiarioActual = id; // Almacenar el ID actual

                    // --- 1. CONSULTAR DATOS DEL BENEFICIARIO POR ID ---
                    string queryBenef = @"
                SELECT 
                    Id_Beneficiarios, Cedula, Nombres, Apellidos, Domicilio, Genero, Fecha_Nacimiento,
                    Discapacidad, Tipo_Discapacidad, Escuela, Curso, `Aplica Beca`, Estado
                FROM beneficiarios
                WHERE Id_Beneficiarios = @IdBeneficiario;";

                    using (var cmdBenef = new MySqlCommand(queryBenef, conn))
                    {
                        cmdBenef.Parameters.AddWithValue("@IdBeneficiario", id);
                        using (var reader = cmdBenef.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Cargar campos del Beneficiario
                                txtCedula.Text = reader.GetString("Cedula");
                                txtNombres.Text = reader.GetString("Nombres");
                                txtApellidos.Text = reader.GetString("Apellidos");
                                txtDomicilio.Text = reader.GetString("Domicilio");
                                cmbGenero.SelectedItem = reader.GetString("Genero");
                                dtpFechaNacimiento.Value = reader.GetDateTime("Fecha_Nacimiento");

                                cmbDiscapacidad.SelectedItem = (reader.GetInt32("Discapacidad") == 1) ? "Sí" : "No";
                                txtDiscapacidad.Text = reader.GetString("Tipo_Discapacidad");

                                txtEscuela.Text = reader.GetString("Escuela");
                                txtCurso.Text = reader.GetString("Curso");

                                cmbAplicaBeca.SelectedItem = (reader.GetInt32("Aplica Beca") == 1) ? "Sí" : "No";
                            }
                        }
                    }

                    // --- 2. CONSULTAR DATOS DEL REPRESENTANTE LEGAL ASOCIADO ---
                    string queryRep = @"
                SELECT 
                    R.Cedula, R.Nombres, R.Apellidos, R.Telefono, R.Parentesco, R.Correo
                FROM representantes R
                INNER JOIN beneficiario_x_representante BXR ON R.Id_Representante = BXR.Id_Representante
                WHERE BXR.Id_Beneficiario = @IdBeneficiario AND BXR.Estado = 'ACTIVO';";

                    using (var cmdRep = new MySqlCommand(queryRep, conn))
                    {
                        cmdRep.Parameters.AddWithValue("@IdBeneficiario", id);
                        using (var readerRep = cmdRep.ExecuteReader())
                        {
                            if (readerRep.Read())
                            {
                                // Cargar campos del Representante Legal
                                txtCedulaRe.Text = readerRep.GetString("Cedula");
                                txtNombresRe.Text = readerRep.GetString("Nombres");
                                txtApellidosRe.Text = readerRep.GetString("Apellidos");
                                txtTelefonoRe.Text = readerRep.GetString("Telefono");
                                txtParentesco.Text = readerRep.GetString("Parentesco");
                                txtEmail.Text = readerRep.GetString("Correo");
                            }
                        }
                    }
                }
                catch (MySqlException mex)
                {
                    MessageBox.Show($"Error de base de datos al cargar por ID: {mex.Message} (Código {mex.Number})", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al cargar por ID: {ex.Message}", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}





