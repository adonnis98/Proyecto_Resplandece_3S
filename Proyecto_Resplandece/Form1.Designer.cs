namespace Proyecto_Resplandece
{
    partial class FormIniciarSesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIniciarSesion));
            panel1 = new Panel();
            linkCrearCuenta = new LinkLabel();
            linkOlvideContrasena = new LinkLabel();
            btnIngresar = new Button();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(linkCrearCuenta);
            panel1.Controls.Add(linkOlvideContrasena);
            panel1.Controls.Add(btnIngresar);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(605, 539);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // linkCrearCuenta
            // 
            linkCrearCuenta.AutoSize = true;
            linkCrearCuenta.Font = new Font("Bookman Old Style", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkCrearCuenta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkCrearCuenta.LinkColor = Color.Black;
            linkCrearCuenta.Location = new Point(257, 454);
            linkCrearCuenta.Name = "linkCrearCuenta";
            linkCrearCuenta.Size = new Size(116, 19);
            linkCrearCuenta.TabIndex = 8;
            linkCrearCuenta.TabStop = true;
            linkCrearCuenta.Text = "Crear Usuario";
            linkCrearCuenta.LinkClicked += linkCrearCuenta_LinkClicked;
            // 
            // linkOlvideContrasena
            // 
            linkOlvideContrasena.AutoSize = true;
            linkOlvideContrasena.Font = new Font("Bookman Old Style", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkOlvideContrasena.LinkBehavior = LinkBehavior.NeverUnderline;
            linkOlvideContrasena.LinkColor = Color.Black;
            linkOlvideContrasena.Location = new Point(228, 482);
            linkOlvideContrasena.Name = "linkOlvideContrasena";
            linkOlvideContrasena.Size = new Size(174, 19);
            linkOlvideContrasena.TabIndex = 7;
            linkOlvideContrasena.TabStop = true;
            linkOlvideContrasena.Text = "Olvide mi contraseña.";
            linkOlvideContrasena.LinkClicked += linkOlvideContrasena_LinkClicked;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Orange;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(228, 398);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(180, 31);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtContraseña
            // 
            txtContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(228, 349);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(204, 22);
            txtContraseña.TabIndex = 5;
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(228, 299);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(204, 22);
            txtUsuario.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(49, 349);
            label3.Name = "label3";
            label3.Size = new Size(141, 24);
            label3.TabIndex = 3;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(93, 299);
            label2.Name = "label2";
            label2.Size = new Size(101, 24);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(49, 215);
            label1.Name = "label1";
            label1.Size = new Size(522, 32);
            label1.TabIndex = 1;
            label1.Text = "Bienvenido/a Porfavor Inicie Sesión";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(212, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(196, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FormIniciarSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 539);
            Controls.Add(panel1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormIniciarSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fundación Resplandece";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Label label3;
        private Button btnIngresar;
        private LinkLabel linkCrearCuenta;
        private LinkLabel linkOlvideContrasena;
    }
}
