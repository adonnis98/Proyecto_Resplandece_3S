namespace Proyecto_Resplandece
{
    partial class FormRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro));
            panel1 = new Panel();
            linkVolverLogin = new LinkLabel();
            txtConfirmarContrasena = new TextBox();
            label4 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            btnRegistrar = new Button();
            txtNuevaContrasena = new TextBox();
            txtNuevoUsuario = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(linkVolverLogin);
            panel1.Controls.Add(txtConfirmarContrasena);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(btnRegistrar);
            panel1.Controls.Add(txtNuevaContrasena);
            panel1.Controls.Add(txtNuevoUsuario);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // linkVolverLogin
            // 
            linkVolverLogin.AutoSize = true;
            linkVolverLogin.LinkColor = Color.Black;
            linkVolverLogin.Location = new Point(318, 380);
            linkVolverLogin.Name = "linkVolverLogin";
            linkVolverLogin.Size = new Size(177, 15);
            linkVolverLogin.TabIndex = 13;
            linkVolverLogin.TabStop = true;
            linkVolverLogin.Text = "Ya tengo cuenta. Volver al inicio.";
            linkVolverLogin.LinkClicked += linkVolverLogin_LinkClicked;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.BorderStyle = BorderStyle.None;
            txtConfirmarContrasena.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarContrasena.Location = new Point(315, 242);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PasswordChar = '*';
            txtConfirmarContrasena.Size = new Size(204, 22);
            txtConfirmarContrasena.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 242);
            label4.Name = "label4";
            label4.Size = new Size(260, 24);
            label4.TabIndex = 9;
            label4.Text = "Confirmar Contraseña:";
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
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Orange;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.Location = new Point(318, 318);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(180, 31);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.BorderStyle = BorderStyle.None;
            txtNuevaContrasena.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNuevaContrasena.Location = new Point(315, 180);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.PasswordChar = '*';
            txtNuevaContrasena.Size = new Size(204, 22);
            txtNuevaContrasena.TabIndex = 5;
            // 
            // txtNuevoUsuario
            // 
            txtNuevoUsuario.BorderStyle = BorderStyle.None;
            txtNuevoUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNuevoUsuario.Location = new Point(315, 128);
            txtNuevoUsuario.Name = "txtNuevoUsuario";
            txtNuevoUsuario.Size = new Size(204, 22);
            txtNuevoUsuario.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(144, 185);
            label3.Name = "label3";
            label3.Size = new Size(141, 24);
            label3.TabIndex = 3;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(184, 126);
            label2.Name = "label2";
            label2.Size = new Size(101, 24);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(265, 20);
            label1.Name = "label1";
            label1.Size = new Size(290, 32);
            label1.TabIndex = 1;
            label1.Text = "Registro de Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nuevo Usuario";
            Load += FormRegistro_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Button btnRegistrar;
        private TextBox txtNuevaContrasena;
        private TextBox txtNuevoUsuario;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtConfirmarContrasena;
        private Label label4;
        private LinkLabel linkVolverLogin;
    }
}