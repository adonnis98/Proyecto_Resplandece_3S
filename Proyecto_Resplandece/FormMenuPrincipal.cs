using Proyecto_Resplandece;
using Proyecto_Resplandece.Clases;
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
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
            //AplicarControlDeAcceso();
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios gestionForm = new FormGestionUsuarios();
            gestionForm.ShowDialog();

        }

        private void gestionUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios gestionForm = new FormGestionUsuarios();
            gestionForm.ShowDialog();
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

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Desea cerrar la sesión?", "Confirmar cierre de sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes)
            {
                return;
            }
            SessionManager.Logout();
            this.Hide();
            using (var loginForm = new FormIniciarSesion())
            {
                loginForm.ShowDialog();
            }
            if (!string.IsNullOrEmpty(SessionManager.Username))
            {
                this.Show();
            }
            else
            {
                this.Close();
            }

        }

        private void gestionTutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistrarTutor gestionTutoresForm = new FormRegistrarTutor();
            gestionTutoresForm.ShowDialog();
        }

        private void administraciónDeBeneficiariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGestionBeneficiarios gestionBeneficiariosForm = new FormGestionBeneficiarios();
            gestionBeneficiariosForm.ShowDialog();
        }

        private void listatadoDeBeneficiariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoBeneficiarios formListado = new FormListadoBeneficiarios();
            formListado.Show();
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
