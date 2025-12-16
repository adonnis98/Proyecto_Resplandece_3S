namespace Proyecto_Resplandece
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            aToolStripMenuItem = new ToolStripMenuItem();
            gestionUsuarioToolStripMenuItem = new ToolStripMenuItem();
            gestionTutoresToolStripMenuItem = new ToolStripMenuItem();
            fundaciónToolStripMenuItem = new ToolStripMenuItem();
            administraciónDeBeneficiariosToolStripMenuItem = new ToolStripMenuItem();
            listatadoDeBeneficiariosToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1213, 839);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint_1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aToolStripMenuItem, fundaciónToolStripMenuItem, ayudaToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1211, 33);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // aToolStripMenuItem
            // 
            aToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionUsuarioToolStripMenuItem, gestionTutoresToolStripMenuItem });
            aToolStripMenuItem.Name = "aToolStripMenuItem";
            aToolStripMenuItem.Size = new Size(147, 29);
            aToolStripMenuItem.Text = "Administración";
            // 
            // gestionUsuarioToolStripMenuItem
            // 
            gestionUsuarioToolStripMenuItem.Name = "gestionUsuarioToolStripMenuItem";
            gestionUsuarioToolStripMenuItem.Size = new Size(220, 34);
            gestionUsuarioToolStripMenuItem.Text = "Crear Usuario";
            gestionUsuarioToolStripMenuItem.Click += gestionUsuarioToolStripMenuItem_Click;
            // 
            // gestionTutoresToolStripMenuItem
            // 
            gestionTutoresToolStripMenuItem.Name = "gestionTutoresToolStripMenuItem";
            gestionTutoresToolStripMenuItem.Size = new Size(220, 34);
            gestionTutoresToolStripMenuItem.Text = "Crear Tutores";
            gestionTutoresToolStripMenuItem.Click += gestionTutoresToolStripMenuItem_Click;
            // 
            // fundaciónToolStripMenuItem
            // 
            fundaciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administraciónDeBeneficiariosToolStripMenuItem, listatadoDeBeneficiariosToolStripMenuItem });
            fundaciónToolStripMenuItem.Name = "fundaciónToolStripMenuItem";
            fundaciónToolStripMenuItem.Size = new Size(110, 29);
            fundaciónToolStripMenuItem.Text = "Fundación";
            // 
            // administraciónDeBeneficiariosToolStripMenuItem
            // 
            administraciónDeBeneficiariosToolStripMenuItem.Name = "administraciónDeBeneficiariosToolStripMenuItem";
            administraciónDeBeneficiariosToolStripMenuItem.Size = new Size(299, 34);
            administraciónDeBeneficiariosToolStripMenuItem.Text = "Crear Beneficiario";
            administraciónDeBeneficiariosToolStripMenuItem.Click += administraciónDeBeneficiariosToolStripMenuItem_Click;
            // 
            // listatadoDeBeneficiariosToolStripMenuItem
            // 
            listatadoDeBeneficiariosToolStripMenuItem.Name = "listatadoDeBeneficiariosToolStripMenuItem";
            listatadoDeBeneficiariosToolStripMenuItem.Size = new Size(299, 34);
            listatadoDeBeneficiariosToolStripMenuItem.Text = "Listado de Beneficiarios";
            listatadoDeBeneficiariosToolStripMenuItem.Click += listatadoDeBeneficiariosToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(98, 29);
            ayudaToolStripMenuItem.Text = "Reportes";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(203, 34);
            acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(132, 29);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 839);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMenuPrincipal";
            WindowState = FormWindowState.Maximized;
            Load += FormMenuPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aToolStripMenuItem;
        private ToolStripMenuItem fundaciónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem gestionUsuarioToolStripMenuItem;
        private ToolStripMenuItem gestionTutoresToolStripMenuItem;
        private ToolStripMenuItem administraciónDeBeneficiariosToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem listatadoDeBeneficiariosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}