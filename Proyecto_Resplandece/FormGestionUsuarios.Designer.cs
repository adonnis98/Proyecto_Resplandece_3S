
namespace Proyecto_Resplandece
{
    partial class FormGestionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionUsuarios));
            panel1 = new Panel();
            dgvUsuarios = new DataGridView();
            groupBox1 = new GroupBox();
            txtConfirmarContrasenaU = new TextBox();
            label8 = new Label();
            btnActualizarU = new Button();
            btnActivarU = new Button();
            label5 = new Label();
            btnLimpiarU = new Button();
            cbxRol = new ComboBox();
            btnInactivarU = new Button();
            label2 = new Label();
            btnCrearU = new Button();
            lblEstado = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUsernameU = new TextBox();
            txtApellidosU = new TextBox();
            txtContrasenaU = new TextBox();
            label7 = new Label();
            txtNombresU = new TextBox();
            label6 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dgvUsuarios);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1165, 881);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(66, 533);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 62;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(1034, 309);
            dgvUsuarios.TabIndex = 52;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConfirmarContrasenaU);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(btnActualizarU);
            groupBox1.Controls.Add(btnActivarU);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnLimpiarU);
            groupBox1.Controls.Add(cbxRol);
            groupBox1.Controls.Add(btnInactivarU);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnCrearU);
            groupBox1.Controls.Add(lblEstado);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtUsernameU);
            groupBox1.Controls.Add(txtApellidosU);
            groupBox1.Controls.Add(txtContrasenaU);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtNombresU);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(66, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1034, 374);
            groupBox1.TabIndex = 51;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro y Edición de Usuarios";
            // 
            // txtConfirmarContrasenaU
            // 
            txtConfirmarContrasenaU.BorderStyle = BorderStyle.None;
            txtConfirmarContrasenaU.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarContrasenaU.Location = new Point(314, 213);
            txtConfirmarContrasenaU.Margin = new Padding(4, 5, 4, 5);
            txtConfirmarContrasenaU.Name = "txtConfirmarContrasenaU";
            txtConfirmarContrasenaU.Size = new Size(291, 32);
            txtConfirmarContrasenaU.TabIndex = 54;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 217);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(296, 28);
            label8.TabIndex = 53;
            label8.Text = "Confirmar Contraseña:";
            // 
            // btnActualizarU
            // 
            btnActualizarU.BackColor = Color.Orange;
            btnActualizarU.FlatStyle = FlatStyle.Flat;
            btnActualizarU.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizarU.Location = new Point(818, 111);
            btnActualizarU.Margin = new Padding(4, 5, 4, 5);
            btnActualizarU.Name = "btnActualizarU";
            btnActualizarU.Size = new Size(152, 52);
            btnActualizarU.TabIndex = 52;
            btnActualizarU.Text = "Actualizar";
            btnActualizarU.UseVisualStyleBackColor = false;
            btnActualizarU.Click += btnActualizarU_Click;
            // 
            // btnActivarU
            // 
            btnActivarU.BackColor = Color.Orange;
            btnActivarU.FlatStyle = FlatStyle.Flat;
            btnActivarU.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActivarU.Location = new Point(818, 235);
            btnActivarU.Margin = new Padding(4, 5, 4, 5);
            btnActivarU.Name = "btnActivarU";
            btnActivarU.Size = new Size(152, 52);
            btnActivarU.TabIndex = 51;
            btnActivarU.Text = "Activar";
            btnActivarU.UseVisualStyleBackColor = false;
            btnActivarU.Click += btnActivarU_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(175, 49);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(128, 28);
            label5.TabIndex = 43;
            label5.Text = "Nombres:";
            // 
            // btnLimpiarU
            // 
            btnLimpiarU.BackColor = Color.Orange;
            btnLimpiarU.FlatStyle = FlatStyle.Flat;
            btnLimpiarU.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiarU.Location = new Point(818, 173);
            btnLimpiarU.Margin = new Padding(4, 5, 4, 5);
            btnLimpiarU.Name = "btnLimpiarU";
            btnLimpiarU.Size = new Size(152, 52);
            btnLimpiarU.TabIndex = 42;
            btnLimpiarU.Text = "Limpiar";
            btnLimpiarU.UseVisualStyleBackColor = false;
            btnLimpiarU.Click += btnLimpiarU_Click;
            // 
            // cbxRol
            // 
            cbxRol.FormattingEnabled = true;
            cbxRol.Items.AddRange(new object[] { "Administrador", "Secretaría", "Tutor" });
            cbxRol.Location = new Point(314, 253);
            cbxRol.Name = "cbxRol";
            cbxRol.Size = new Size(291, 36);
            cbxRol.TabIndex = 50;
            // 
            // btnInactivarU
            // 
            btnInactivarU.BackColor = Color.Orange;
            btnInactivarU.FlatStyle = FlatStyle.Flat;
            btnInactivarU.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInactivarU.Location = new Point(818, 297);
            btnInactivarU.Margin = new Padding(4, 5, 4, 5);
            btnInactivarU.Name = "btnInactivarU";
            btnInactivarU.Size = new Size(152, 52);
            btnInactivarU.TabIndex = 41;
            btnInactivarU.Text = "Inactivar";
            btnInactivarU.UseVisualStyleBackColor = false;
            btnInactivarU.Click += btnInactivarU_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(188, 133);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // btnCrearU
            // 
            btnCrearU.BackColor = Color.Orange;
            btnCrearU.FlatStyle = FlatStyle.Flat;
            btnCrearU.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearU.Location = new Point(818, 49);
            btnCrearU.Margin = new Padding(4, 5, 4, 5);
            btnCrearU.Name = "btnCrearU";
            btnCrearU.Size = new Size(152, 52);
            btnCrearU.TabIndex = 39;
            btnCrearU.Text = "Crear";
            btnCrearU.UseVisualStyleBackColor = false;
            btnCrearU.Click += btnCrearU_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(412, 307);
            lblEstado.Margin = new Padding(4, 0, 4, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(96, 28);
            lblEstado.TabIndex = 49;
            lblEstado.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(142, 175);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(161, 28);
            label3.TabIndex = 3;
            label3.Text = "Contraseña:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(199, 295);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 28);
            label4.TabIndex = 48;
            label4.Text = "Estado:";
            // 
            // txtUsernameU
            // 
            txtUsernameU.BorderStyle = BorderStyle.None;
            txtUsernameU.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsernameU.Location = new Point(314, 129);
            txtUsernameU.Margin = new Padding(4, 5, 4, 5);
            txtUsernameU.Name = "txtUsernameU";
            txtUsernameU.Size = new Size(291, 32);
            txtUsernameU.TabIndex = 4;
            // 
            // txtApellidosU
            // 
            txtApellidosU.BorderStyle = BorderStyle.None;
            txtApellidosU.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidosU.Location = new Point(314, 87);
            txtApellidosU.Margin = new Padding(4, 5, 4, 5);
            txtApellidosU.Name = "txtApellidosU";
            txtApellidosU.Size = new Size(291, 32);
            txtApellidosU.TabIndex = 46;
            // 
            // txtContrasenaU
            // 
            txtContrasenaU.BorderStyle = BorderStyle.None;
            txtContrasenaU.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenaU.Location = new Point(314, 171);
            txtContrasenaU.Margin = new Padding(4, 5, 4, 5);
            txtContrasenaU.Name = "txtContrasenaU";
            txtContrasenaU.Size = new Size(291, 32);
            txtContrasenaU.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(241, 261);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(62, 28);
            label7.TabIndex = 45;
            label7.Text = "Rol:";
            // 
            // txtNombresU
            // 
            txtNombresU.BorderStyle = BorderStyle.None;
            txtNombresU.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombresU.Location = new Point(314, 45);
            txtNombresU.Margin = new Padding(4, 5, 4, 5);
            txtNombresU.Name = "txtNombresU";
            txtNombresU.Size = new Size(291, 32);
            txtNombresU.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(169, 91);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(134, 28);
            label6.TabIndex = 44;
            label6.Text = "Apellidos:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(380, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(438, 48);
            label1.TabIndex = 1;
            label1.Text = "Registro de Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 881);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormGestionUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Usuario";
            Load += FormRegistro_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Panel panel1;
        private TextBox txtContrasenaU;
        private TextBox txtUsernameU;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtNombresU;
        private Button btnLimpiarU;
        private Button btnInactivarU;
        private Button btnCrearU;
        private Label label5;
        private Label label7;
        private Label label6;
        private TextBox txtApellidosU;
        private Label lblEstado;
        private Label label4;
        private ComboBox cbxRol;
        private GroupBox groupBox1;
        private Button btnActivarU;
        private Button btnActualizarU;
        private TextBox txtConfirmarContrasenaU;
        private Label label8;
        private DataGridView dgvUsuarios;
    }
}