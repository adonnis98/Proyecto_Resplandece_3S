using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Proyecto_Resplandece.Clases;
using System.Drawing;
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
            // 💡 Llamamos a la función de control de acceso justo después de inicializar los componentes
            AplicarControlDeAcceso();
        }
        private void AplicarControlDeAcceso()
        {
            // Opcional: Mostrar un mensaje de bienvenida personalizado
            // if (lblBienvenida != null)
            // {
            //     lblBienvenida.Text = $"Bienvenido, {SessionManager.Username} ({SessionManager.Rol})";
            // }

            // 1. Verificar si el usuario logueado NO es Administrador
            if (!SessionManager.IsAdmin)
            {
                // 2. Ocultar el botón (asumiendo que se llama btnGestionUsuarios)
                // Esto previene que un usuario regular acceda a las herramientas de administración.
                btnGestionUsuarios.Visible = false;

                // 3. (Opcional) Si tu menú es más complejo, puedes ocultar otros paneles o menús aquí.
            }
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Oculta el menú principal
            this.Hide();

            // Crea y muestra una nueva instancia del formulario de Login (Form1)
            FormIniciarSesion loginForm = new FormIniciarSesion();
            loginForm.Show();

            // Cierra esta instancia del menú principal
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de usuarios
            FormGestionUsuarios gestionForm = new FormGestionUsuarios();
            gestionForm.ShowDialog();
            // No usamos this.Hide() porque queremos mantener el menú principal visible.
        }
    }
}
