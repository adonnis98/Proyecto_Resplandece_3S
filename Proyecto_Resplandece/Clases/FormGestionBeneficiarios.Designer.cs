namespace Proyecto_Resplandece.Clases
{
    partial class FormGestionBeneficiarios
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
            panel1 = new Panel();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtAnioEducativo = new TextBox();
            txtPlantel = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            txtDireccion = new TextBox();
            txtApellidos = new TextBox();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            txtNombres = new TextBox();
            txtCedula = new TextBox();
            dgvBeneficiarios = new DataGridView();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBeneficiarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtAnioEducativo);
            panel1.Controls.Add(txtPlantel);
            panel1.Controls.Add(dtpFechaNacimiento);
            panel1.Controls.Add(txtDireccion);
            panel1.Controls.Add(txtApellidos);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(txtNombres);
            panel1.Controls.Add(txtCedula);
            panel1.Controls.Add(dgvBeneficiarios);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(11, 314);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PasswordChar = '*';
            txtTelefono.Size = new Size(204, 29);
            txtTelefono.TabIndex = 24;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(11, 349);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '*';
            txtEmail.Size = new Size(204, 29);
            txtEmail.TabIndex = 23;
            // 
            // txtAnioEducativo
            // 
            txtAnioEducativo.BorderStyle = BorderStyle.FixedSingle;
            txtAnioEducativo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnioEducativo.Location = new Point(11, 279);
            txtAnioEducativo.Name = "txtAnioEducativo";
            txtAnioEducativo.PasswordChar = '*';
            txtAnioEducativo.Size = new Size(204, 29);
            txtAnioEducativo.TabIndex = 22;
            // 
            // txtPlantel
            // 
            txtPlantel.BorderStyle = BorderStyle.FixedSingle;
            txtPlantel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPlantel.Location = new Point(11, 244);
            txtPlantel.Name = "txtPlantel";
            txtPlantel.PasswordChar = '*';
            txtPlantel.Size = new Size(204, 29);
            txtPlantel.TabIndex = 21;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(11, 215);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(204, 23);
            dtpFechaNacimiento.TabIndex = 6;
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(11, 180);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PasswordChar = '*';
            txtDireccion.Size = new Size(204, 29);
            txtDireccion.TabIndex = 19;
            // 
            // txtApellidos
            // 
            txtApellidos.BorderStyle = BorderStyle.FixedSingle;
            txtApellidos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.Location = new Point(11, 145);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.PasswordChar = '*';
            txtApellidos.Size = new Size(204, 29);
            txtApellidos.TabIndex = 18;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Orange;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(251, 180);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(180, 31);
            btnNuevo.TabIndex = 16;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Orange;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(251, 128);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(180, 31);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(251, 91);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 31);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // txtNombres
            // 
            txtNombres.BorderStyle = BorderStyle.FixedSingle;
            txtNombres.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(11, 110);
            txtNombres.Name = "txtNombres";
            txtNombres.PasswordChar = '*';
            txtNombres.Size = new Size(204, 29);
            txtNombres.TabIndex = 13;
            // 
            // txtCedula
            // 
            txtCedula.BorderStyle = BorderStyle.FixedSingle;
            txtCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCedula.Location = new Point(11, 75);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(204, 29);
            txtCedula.TabIndex = 12;
            // 
            // dgvBeneficiarios
            // 
            dgvBeneficiarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBeneficiarios.Location = new Point(458, 75);
            dgvBeneficiarios.Name = "dgvBeneficiarios";
            dgvBeneficiarios.Size = new Size(315, 145);
            dgvBeneficiarios.TabIndex = 11;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Bookman Old Style", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(257, 454);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(116, 19);
            linkLabel2.TabIndex = 8;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Crear Usuario";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Bookman Old Style", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(228, 482);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(174, 19);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Olvide mi contraseña.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(184, 22);
            label1.Name = "label1";
            label1.Size = new Size(445, 32);
            label1.TabIndex = 1;
            label1.Text = "Gestión de Cuentas de Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormGestionBeneficiarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "FormGestionBeneficiarios";
            Text = "FormGestionBeneficiarios";
            Load += FormGestionBeneficiarios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBeneficiarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtDireccion;
        private TextBox txtApellidos;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnGuardar;
        private TextBox txtNombres;
        private TextBox txtCedula;
        private DataGridView dgvBeneficiarios;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label label1;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtAnioEducativo;
        private TextBox txtPlantel;
    }
}