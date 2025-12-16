namespace Proyecto_Resplandece.Clases
{
    partial class FormRegistrarTutor
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            label2 = new Label();
            btnAtivar = new Button();
            btnInactivar = new Button();
            btnLimpiar = new Button();
            txtNombresT = new TextBox();
            txtApellidosT = new TextBox();
            btnCrear = new Button();
            btnActualizar = new Button();
            txtTelefonoT = new TextBox();
            lblEstadoT = new Label();
            label3 = new Label();
            label7 = new Label();
            label5 = new Label();
            txtEMaximaT = new TextBox();
            label6 = new Label();
            label4 = new Label();
            txtEMinimaT = new TextBox();
            dgvTutores = new DataGridView();
            label1 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTutores).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(dgvTutores);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1223, 852);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnAtivar);
            groupBox1.Controls.Add(btnInactivar);
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(txtNombresT);
            groupBox1.Controls.Add(txtApellidosT);
            groupBox1.Controls.Add(btnCrear);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Controls.Add(txtTelefonoT);
            groupBox1.Controls.Add(lblEstadoT);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtEMaximaT);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtEMinimaT);
            groupBox1.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(60, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1093, 332);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro y Edición de Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 51);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 25;
            label2.Text = "Nombres:";
            // 
            // btnAtivar
            // 
            btnAtivar.BackColor = Color.Orange;
            btnAtivar.FlatStyle = FlatStyle.Flat;
            btnAtivar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtivar.Location = new Point(659, 229);
            btnAtivar.Margin = new Padding(4, 5, 4, 5);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(152, 52);
            btnAtivar.TabIndex = 15;
            btnAtivar.Text = "Activar";
            btnAtivar.UseVisualStyleBackColor = false;
            btnAtivar.Click += btnAtivar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.BackColor = Color.Orange;
            btnInactivar.FlatStyle = FlatStyle.Flat;
            btnInactivar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInactivar.Location = new Point(846, 229);
            btnInactivar.Margin = new Padding(4, 5, 4, 5);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(152, 52);
            btnInactivar.TabIndex = 35;
            btnInactivar.Text = "Inactivar";
            btnInactivar.UseVisualStyleBackColor = false;
            btnInactivar.Click += btnInactivar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Orange;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(467, 229);
            btnLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(152, 52);
            btnLimpiar.TabIndex = 36;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtNombresT
            // 
            txtNombresT.BorderStyle = BorderStyle.FixedSingle;
            txtNombresT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombresT.Location = new Point(168, 42);
            txtNombresT.Margin = new Padding(4, 5, 4, 5);
            txtNombresT.Name = "txtNombresT";
            txtNombresT.Size = new Size(341, 34);
            txtNombresT.TabIndex = 13;
            // 
            // txtApellidosT
            // 
            txtApellidosT.BorderStyle = BorderStyle.FixedSingle;
            txtApellidosT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidosT.Location = new Point(168, 99);
            txtApellidosT.Margin = new Padding(4, 5, 4, 5);
            txtApellidosT.Name = "txtApellidosT";
            txtApellidosT.Size = new Size(341, 34);
            txtApellidosT.TabIndex = 18;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.Orange;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrear.Location = new Point(96, 229);
            btnCrear.Margin = new Padding(4, 5, 4, 5);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(152, 52);
            btnCrear.TabIndex = 16;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Orange;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(279, 229);
            btnActualizar.Margin = new Padding(4, 5, 4, 5);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(152, 52);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtTelefonoT
            // 
            txtTelefonoT.BorderStyle = BorderStyle.FixedSingle;
            txtTelefonoT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefonoT.Location = new Point(168, 156);
            txtTelefonoT.Margin = new Padding(4, 5, 4, 5);
            txtTelefonoT.Name = "txtTelefonoT";
            txtTelefonoT.Size = new Size(341, 34);
            txtTelefonoT.TabIndex = 24;
            // 
            // lblEstadoT
            // 
            lblEstadoT.AutoSize = true;
            lblEstadoT.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoT.Location = new Point(837, 162);
            lblEstadoT.Name = "lblEstadoT";
            lblEstadoT.Size = new Size(117, 28);
            lblEstadoT.TabIndex = 33;
            lblEstadoT.Text = "ESTADO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 108);
            label3.Name = "label3";
            label3.Size = new Size(123, 25);
            label3.TabIndex = 26;
            label3.Text = "Apellidos:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(670, 162);
            label7.Name = "label7";
            label7.Size = new Size(97, 25);
            label7.TabIndex = 32;
            label7.Text = "Estado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(30, 165);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 28;
            label5.Text = "Telefono:";
            // 
            // txtEMaximaT
            // 
            txtEMaximaT.BorderStyle = BorderStyle.FixedSingle;
            txtEMaximaT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEMaximaT.Location = new Point(786, 98);
            txtEMaximaT.Margin = new Padding(4, 5, 4, 5);
            txtEMaximaT.Name = "txtEMaximaT";
            txtEMaximaT.Size = new Size(197, 34);
            txtEMaximaT.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(596, 51);
            label6.Name = "label6";
            label6.Size = new Size(171, 25);
            label6.TabIndex = 29;
            label6.Text = "Edad Minima:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(591, 103);
            label4.Name = "label4";
            label4.Size = new Size(176, 25);
            label4.TabIndex = 30;
            label4.Text = "Edad Maxima:";
            // 
            // txtEMinimaT
            // 
            txtEMinimaT.BorderStyle = BorderStyle.FixedSingle;
            txtEMinimaT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEMinimaT.Location = new Point(786, 42);
            txtEMinimaT.Margin = new Padding(4, 5, 4, 5);
            txtEMinimaT.Name = "txtEMinimaT";
            txtEMinimaT.Size = new Size(197, 34);
            txtEMinimaT.TabIndex = 19;
            // 
            // dgvTutores
            // 
            dgvTutores.AllowUserToAddRows = false;
            dgvTutores.AllowUserToDeleteRows = false;
            dgvTutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTutores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTutores.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTutores.Location = new Point(60, 477);
            dgvTutores.Margin = new Padding(4, 5, 4, 5);
            dgvTutores.Name = "dgvTutores";
            dgvTutores.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTutores.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTutores.RowHeadersWidth = 62;
            dgvTutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutores.Size = new Size(1093, 345);
            dgvTutores.TabIndex = 11;
            dgvTutores.CellClick += dgvTutores_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(444, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(396, 48);
            label1.TabIndex = 1;
            label1.Text = "Registro de Tutor";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRegistrarTutor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 852);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistrarTutor";
            Text = "Registrar Tutor";
            Load += FormRegistrarTutor_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTutores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private TextBox txtTelefonoT;
        private TextBox txtEMinimaT;
        private TextBox txtApellidosT;
        private Button btnCrear;
        private Button btnAtivar;
        private Button btnActualizar;
        private TextBox txtNombresT;
        private DataGridView dgvTutores;
        private Label label1;
        private Label label7;
        private TextBox txtEMaximaT;
        private Label label4;
        private Label lblEstadoT;
        private Button btnLimpiar;
        private Button btnInactivar;
        private GroupBox groupBox1;
    }
}