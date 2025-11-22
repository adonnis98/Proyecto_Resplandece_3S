using Proyecto_Resplandece.Clases.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Resplandece.Clases
{
    public partial class FormGestionBeneficiarios : Form
    {
        private int BeneficiarioIdSeleccionado = 0;

        public FormGestionBeneficiarios()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormGestionBeneficiarios_Load(object sender, EventArgs e)
        {
            CargarBeneficiarios();
            LimpiarCampos();
        }
        private void CargarBeneficiarios()
        {
            try
            {
                // 💡 Usando 'BaseDeDatos' como tu DbContext
                using (var context = new BaseDeDatos())
                {
                    var lista = context.Beneficiarios
                        .Select(b => new
                        {
                            b.Id,
                            b.Codigo,
                            b.Cedula,
                            b.NombresCompletos,
                            b.Telefono,
                            b.Estado
                        })
                        .ToList();

                    dgvBeneficiarios.DataSource = lista;
                    if (dgvBeneficiarios.Columns.Contains("Id"))
                        dgvBeneficiarios.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar beneficiarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- GUARDAR (CREATE/UPDATE) ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Recolección y validación
            string cedula = txtCedula.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            DateTime fechaNacimiento = dtpFechaNacimiento.Value.Date;

            if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show("Cédula, Nombres y Apellidos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var context = new BaseDeDatos())
                {
                    Beneficiarios beneficiario;

                    if (BeneficiarioIdSeleccionado == 0)
                    {
                        // --- MODO CREAR (CREATE) ---
                        // Usamos el constructor que calcula Edad, Código y NombresCompletos
                        beneficiario = new Beneficiarios(
                            cedula, nombres, apellidos,
                            txtDireccion.Text, fechaNacimiento,
                            txtPlantel.Text, txtAnioEducativo.Text,
                            txtTelefono.Text, txtEmail.Text
                        );
                        context.Beneficiarios.Add(beneficiario);
                    }
                    else
                    {
                        // --- MODO ACTUALIZAR (UPDATE) ---
                        // El operador '!' se usa para decirle al compilador que confiamos en que no será null aquí.
                        beneficiario = context.Beneficiarios.Find(BeneficiarioIdSeleccionado)!;
                        if (beneficiario == null) return;

                        // Actualizar propiedades
                        beneficiario.Cedula = cedula;
                        beneficiario.Nombres = nombres;
                        beneficiario.Apellidos = apellidos;
                        beneficiario.NombresCompletos = nombres + " " + apellidos; // Recalculado
                        beneficiario.Direccion = txtDireccion.Text;
                        beneficiario.FechaNacimiento = fechaNacimiento;
                        beneficiario.PlantelEducativo = txtPlantel.Text;
                        beneficiario.AnioEducativo = txtAnioEducativo.Text;
                        beneficiario.Telefono = txtTelefono.Text;
                        beneficiario.Email = txtEmail.Text;

                        // Recalcular edad si la fecha cambió
                        beneficiario.Edad = CalcularEdad(fechaNacimiento);
                    }
                    context.SaveChanges();
                    MessageBox.Show("Beneficiario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBeneficiarios();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el beneficiario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- ELIMINAR (Lógica) ---
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (BeneficiarioIdSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un beneficiario de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea **desactivar** este beneficiario (cambiar estado a Inactivo)?", "Confirmar Desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var context = new BaseDeDatos())
                    {
                        var beneficiario = context.Beneficiarios.Find(BeneficiarioIdSeleccionado);
                        if (beneficiario != null)
                        {
                            // Eliminación LÓGICA (cambio de estado de 'A' a 'I')
                            beneficiario.Estado = "I";
                            context.SaveChanges();

                            MessageBox.Show("Beneficiario marcado como Inactivo con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarBeneficiarios();
                            LimpiarCampos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el estado del beneficiario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // --- CARGAR DATOS AL SELECCIONAR FILA ---
        private void dgvBeneficiarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BeneficiarioIdSeleccionado = Convert.ToInt32(dgvBeneficiarios.Rows[e.RowIndex].Cells["Id"].Value);

                using (var context = new BaseDeDatos())
                {
                    var b = context.Beneficiarios.Find(BeneficiarioIdSeleccionado);
                    if (b != null)
                    {
                        txtCedula.Text = b.Cedula;
                        txtNombres.Text = b.Nombres;
                        txtApellidos.Text = b.Apellidos;
                        txtDireccion.Text = b.Direccion;
                        dtpFechaNacimiento.Value = b.FechaNacimiento;
                        txtPlantel.Text = b.PlantelEducativo;
                        txtAnioEducativo.Text = b.AnioEducativo;
                        txtTelefono.Text = b.Telefono;
                        txtEmail.Text = b.Email;
                    }
                }
            }
        }
        // --- AUXILIARES ---
        private void LimpiarCampos()
        {
            BeneficiarioIdSeleccionado = 0;
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-10); // Sugiere una fecha pasada
            txtPlantel.Clear();
            txtAnioEducativo.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtCedula.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Función para calcular la edad (replicando la lógica del constructor)
        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.Month < fechaNacimiento.Month ||
                (DateTime.Now.Month == fechaNacimiento.Month && DateTime.Now.Day < fechaNacimiento.Day))
            {
                edad--;
            }
            return edad;
        }
    }
}

