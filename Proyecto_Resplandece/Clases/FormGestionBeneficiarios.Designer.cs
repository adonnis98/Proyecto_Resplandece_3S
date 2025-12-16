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
            btnLimpiar = new Button();
            btnInactivar = new Button();
            btnConsultar = new Button();
            btnCrear = new Button();
            btnAtivar = new Button();
            btnActualizar = new Button();
            groupBox3 = new GroupBox();
            txtEmail = new TextBox();
            label20 = new Label();
            txtParentesco = new TextBox();
            txtTelefonoRe = new TextBox();
            txtCedulaRe = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            txtApellidosRe = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtNombresRe = new TextBox();
            groupBox1 = new GroupBox();
            cmbGenero = new ComboBox();
            cmbDiscapacidad = new ComboBox();
            cmbAplicaBeca = new ComboBox();
            lblEstado = new Label();
            txtDiscapacidad = new TextBox();
            label21 = new Label();
            label22 = new Label();
            label5 = new Label();
            txtCurso = new TextBox();
            txtEscuela = new TextBox();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label8 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            label7 = new Label();
            label2 = new Label();
            label6 = new Label();
            txtApellidos = new TextBox();
            txtCedula = new TextBox();
            label4 = new Label();
            txtNombres = new TextBox();
            label3 = new Label();
            txtDomicilio = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnInactivar);
            panel1.Controls.Add(btnConsultar);
            panel1.Controls.Add(btnCrear);
            panel1.Controls.Add(btnAtivar);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1223, 934);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Orange;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(621, 834);
            btnLimpiar.Margin = new Padding(4, 5, 4, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(257, 52);
            btnLimpiar.TabIndex = 45;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.BackColor = Color.Orange;
            btnInactivar.FlatStyle = FlatStyle.Flat;
            btnInactivar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInactivar.Location = new Point(349, 834);
            btnInactivar.Margin = new Padding(4, 5, 4, 5);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(257, 52);
            btnInactivar.TabIndex = 44;
            btnInactivar.Text = "Inactivar";
            btnInactivar.UseVisualStyleBackColor = false;
            btnInactivar.Click += btnInactivar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.Orange;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConsultar.Location = new Point(71, 746);
            btnConsultar.Margin = new Padding(4, 5, 4, 5);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(257, 52);
            btnConsultar.TabIndex = 43;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.Orange;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrear.Location = new Point(349, 746);
            btnCrear.Margin = new Padding(4, 5, 4, 5);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(257, 52);
            btnCrear.TabIndex = 42;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnAtivar
            // 
            btnAtivar.BackColor = Color.Orange;
            btnAtivar.FlatStyle = FlatStyle.Flat;
            btnAtivar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtivar.Location = new Point(898, 746);
            btnAtivar.Margin = new Padding(4, 5, 4, 5);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(257, 52);
            btnAtivar.TabIndex = 41;
            btnAtivar.Text = "Activar";
            btnAtivar.UseVisualStyleBackColor = false;
            btnAtivar.Click += btnAtivar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Orange;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Bookman Old Style", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(621, 746);
            btnActualizar.Margin = new Padding(4, 5, 4, 5);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(257, 52);
            btnActualizar.TabIndex = 40;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtEmail);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(txtParentesco);
            groupBox3.Controls.Add(txtTelefonoRe);
            groupBox3.Controls.Add(txtCedulaRe);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(txtApellidosRe);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(txtNombresRe);
            groupBox3.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(20, 455);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1178, 249);
            groupBox3.TabIndex = 39;
            groupBox3.TabStop = false;
            groupBox3.Text = "Representante Legal";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(772, 162);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(351, 39);
            txtEmail.TabIndex = 46;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(641, 173);
            label20.Name = "label20";
            label20.Size = new Size(104, 28);
            label20.TabIndex = 45;
            label20.Text = "Correo:";
            // 
            // txtParentesco
            // 
            txtParentesco.BorderStyle = BorderStyle.FixedSingle;
            txtParentesco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtParentesco.Location = new Point(772, 113);
            txtParentesco.Margin = new Padding(4, 5, 4, 5);
            txtParentesco.Name = "txtParentesco";
            txtParentesco.Size = new Size(177, 39);
            txtParentesco.TabIndex = 44;
            // 
            // txtTelefonoRe
            // 
            txtTelefonoRe.BorderStyle = BorderStyle.FixedSingle;
            txtTelefonoRe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefonoRe.Location = new Point(772, 64);
            txtTelefonoRe.Margin = new Padding(4, 5, 4, 5);
            txtTelefonoRe.Name = "txtTelefonoRe";
            txtTelefonoRe.Size = new Size(177, 39);
            txtTelefonoRe.TabIndex = 43;
            // 
            // txtCedulaRe
            // 
            txtCedulaRe.BorderStyle = BorderStyle.FixedSingle;
            txtCedulaRe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCedulaRe.Location = new Point(182, 64);
            txtCedulaRe.Margin = new Padding(4, 5, 4, 5);
            txtCedulaRe.Name = "txtCedulaRe";
            txtCedulaRe.Size = new Size(177, 39);
            txtCedulaRe.TabIndex = 42;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(588, 124);
            label15.Name = "label15";
            label15.Size = new Size(157, 28);
            label15.TabIndex = 41;
            label15.Text = "Parentesco:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(617, 70);
            label14.Name = "label14";
            label14.Size = new Size(128, 28);
            label14.TabIndex = 40;
            label14.Text = "Telefono:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(67, 75);
            label13.Name = "label13";
            label13.Size = new Size(105, 28);
            label13.TabIndex = 39;
            label13.Text = "Cedula:";
            // 
            // txtApellidosRe
            // 
            txtApellidosRe.BorderStyle = BorderStyle.FixedSingle;
            txtApellidosRe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidosRe.Location = new Point(182, 162);
            txtApellidosRe.Margin = new Padding(4, 5, 4, 5);
            txtApellidosRe.Name = "txtApellidosRe";
            txtApellidosRe.Size = new Size(326, 39);
            txtApellidosRe.TabIndex = 38;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(44, 124);
            label11.Name = "label11";
            label11.Size = new Size(128, 28);
            label11.TabIndex = 35;
            label11.Text = "Nombres:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(38, 173);
            label12.Name = "label12";
            label12.Size = new Size(134, 28);
            label12.TabIndex = 37;
            label12.Text = "Apellidos:";
            // 
            // txtNombresRe
            // 
            txtNombresRe.BorderStyle = BorderStyle.FixedSingle;
            txtNombresRe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombresRe.Location = new Point(182, 113);
            txtNombresRe.Margin = new Padding(4, 5, 4, 5);
            txtNombresRe.Name = "txtNombresRe";
            txtNombresRe.Size = new Size(326, 39);
            txtNombresRe.TabIndex = 36;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbGenero);
            groupBox1.Controls.Add(cmbDiscapacidad);
            groupBox1.Controls.Add(cmbAplicaBeca);
            groupBox1.Controls.Add(lblEstado);
            groupBox1.Controls.Add(txtDiscapacidad);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(label22);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtCurso);
            groupBox1.Controls.Add(txtEscuela);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtApellidos);
            groupBox1.Controls.Add(txtCedula);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNombres);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDomicilio);
            groupBox1.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(20, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1178, 363);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Beneficiario";
            // 
            // cmbGenero
            // 
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Items.AddRange(new object[] { "Masculino", "Femenino" });
            cmbGenero.Location = new Point(168, 232);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(182, 36);
            cmbGenero.TabIndex = 50;
            // 
            // cmbDiscapacidad
            // 
            cmbDiscapacidad.FormattingEnabled = true;
            cmbDiscapacidad.Items.AddRange(new object[] { "Si", "No" });
            cmbDiscapacidad.Location = new Point(715, 35);
            cmbDiscapacidad.Name = "cmbDiscapacidad";
            cmbDiscapacidad.Size = new Size(182, 36);
            cmbDiscapacidad.TabIndex = 49;
            // 
            // cmbAplicaBeca
            // 
            cmbAplicaBeca.FormattingEnabled = true;
            cmbAplicaBeca.Items.AddRange(new object[] { "Si", "No" });
            cmbAplicaBeca.Location = new Point(701, 230);
            cmbAplicaBeca.Name = "cmbAplicaBeca";
            cmbAplicaBeca.Size = new Size(182, 36);
            cmbAplicaBeca.TabIndex = 48;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(682, 292);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(92, 28);
            lblEstado.TabIndex = 42;
            lblEstado.Text = "Activo";
            // 
            // txtDiscapacidad
            // 
            txtDiscapacidad.BorderStyle = BorderStyle.FixedSingle;
            txtDiscapacidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiscapacidad.Location = new Point(811, 83);
            txtDiscapacidad.Margin = new Padding(4, 5, 4, 5);
            txtDiscapacidad.Name = "txtDiscapacidad";
            txtDiscapacidad.Size = new Size(347, 39);
            txtDiscapacidad.TabIndex = 46;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(530, 292);
            label21.Name = "label21";
            label21.Size = new Size(104, 28);
            label21.TabIndex = 41;
            label21.Text = "Estado:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(524, 96);
            label22.Name = "label22";
            label22.Size = new Size(287, 28);
            label22.TabIndex = 45;
            label22.Text = "Tipo de Discapacidad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(524, 44);
            label5.Name = "label5";
            label5.Size = new Size(185, 28);
            label5.TabIndex = 42;
            label5.Text = "Discapacidad:";
            // 
            // txtCurso
            // 
            txtCurso.BorderStyle = BorderStyle.FixedSingle;
            txtCurso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurso.Location = new Point(646, 183);
            txtCurso.Margin = new Padding(4, 5, 4, 5);
            txtCurso.Name = "txtCurso";
            txtCurso.Size = new Size(235, 39);
            txtCurso.TabIndex = 39;
            // 
            // txtEscuela
            // 
            txtEscuela.BorderStyle = BorderStyle.FixedSingle;
            txtEscuela.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEscuela.Location = new Point(646, 132);
            txtEscuela.Margin = new Padding(4, 5, 4, 5);
            txtEscuela.Name = "txtEscuela";
            txtEscuela.Size = new Size(512, 39);
            txtEscuela.TabIndex = 38;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(530, 240);
            label18.Name = "label18";
            label18.Size = new Size(165, 28);
            label18.TabIndex = 37;
            label18.Text = "Aplica Beca:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(524, 194);
            label17.Name = "label17";
            label17.Size = new Size(92, 28);
            label17.TabIndex = 36;
            label17.Text = "Curso:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(524, 145);
            label16.Name = "label16";
            label16.Size = new Size(115, 28);
            label16.TabIndex = 35;
            label16.Text = "Escuela:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 292);
            label8.Name = "label8";
            label8.Size = new Size(246, 28);
            label8.TabIndex = 34;
            label8.Text = "Fecha Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(280, 286);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(209, 36);
            dtpFechaNacimiento.TabIndex = 33;
            dtpFechaNacimiento.ValueChanged += dtpFechaNacimiento_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(47, 238);
            label7.Name = "label7";
            label7.Size = new Size(109, 28);
            label7.TabIndex = 30;
            label7.Text = "Genero:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 44);
            label2.Name = "label2";
            label2.Size = new Size(105, 28);
            label2.TabIndex = 25;
            label2.Text = "Cedula:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 194);
            label6.Name = "label6";
            label6.Size = new Size(142, 28);
            label6.TabIndex = 29;
            label6.Text = "Domicilio:";
            // 
            // txtApellidos
            // 
            txtApellidos.BorderStyle = BorderStyle.FixedSingle;
            txtApellidos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.Location = new Point(163, 134);
            txtApellidos.Margin = new Padding(4, 5, 4, 5);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(315, 39);
            txtApellidos.TabIndex = 12;
            // 
            // txtCedula
            // 
            txtCedula.BorderStyle = BorderStyle.FixedSingle;
            txtCedula.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCedula.Location = new Point(163, 36);
            txtCedula.Margin = new Padding(4, 5, 4, 5);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(187, 39);
            txtCedula.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 145);
            label4.Name = "label4";
            label4.Size = new Size(134, 28);
            label4.TabIndex = 27;
            label4.Text = "Apellidos:";
            // 
            // txtNombres
            // 
            txtNombres.BorderStyle = BorderStyle.FixedSingle;
            txtNombres.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(163, 85);
            txtNombres.Margin = new Padding(4, 5, 4, 5);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(315, 39);
            txtNombres.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 96);
            label3.Name = "label3";
            label3.Size = new Size(128, 28);
            label3.TabIndex = 26;
            label3.Text = "Nombres:";
            // 
            // txtDomicilio
            // 
            txtDomicilio.BorderStyle = BorderStyle.FixedSingle;
            txtDomicilio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDomicilio.Location = new Point(163, 183);
            txtDomicilio.Margin = new Padding(4, 5, 4, 5);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(315, 39);
            txtDomicilio.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(487, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(199, 48);
            label1.TabIndex = 1;
            label1.Text = "Registro";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormGestionBeneficiarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 934);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormGestionBeneficiarios";
            Text = "FormGestionBeneficiarios";
            Load += FormGestionBeneficiarios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtDomicilio;
        private TextBox txtNombres;
        private TextBox txtCedula;
        private TextBox txtApellidos;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label6;
        private GroupBox groupBox1;
        private Label label7;
        private Label label8;
        private DateTimePicker dtpFechaNacimiento;
        private GroupBox groupBox3;
        private Label label14;
        private Label label13;
        private TextBox txtApellidosRe;
        private Label label11;
        private Label label12;
        private TextBox txtNombresRe;
        private Label label15;
        private TextBox txtCedulaRe;
        private TextBox txtEscuela;
        private Label label18;
        private Label label17;
        private Label label16;
        private TextBox txtCurso;
        private TextBox txtTelefonoRe;
        private TextBox txtParentesco;
        private Button btnLimpiar;
        private Button btnInactivar;
        private Button btnConsultar;
        private Button btnCrear;
        private Button btnAtivar;
        private Button btnActualizar;
        private Label lblEstado;
        private Label label21;
        private Label label22;
        private Label label5;
        private TextBox txtDiscapacidad;
        private TextBox txtEmail;
        private Label label20;
        private ComboBox cmbDiscapacidad;
        private ComboBox cmbAplicaBeca;
        private ComboBox cmbGenero;
    }
}