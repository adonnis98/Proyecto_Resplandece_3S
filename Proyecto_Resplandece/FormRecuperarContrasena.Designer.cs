namespace Proyecto_Resplandece
{
    partial class FormRecuperarContrasena
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
            txtConfirmarContrasena = new TextBox();
            label4 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            btnRestablecer = new Button();
            txtNuevaContrasena = new TextBox();
            txtUsuario = new TextBox();
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
            panel1.Controls.Add(txtConfirmarContrasena);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(btnRestablecer);
            panel1.Controls.Add(txtNuevaContrasena);
            panel1.Controls.Add(txtUsuario);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarContrasena.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarContrasena.Location = new Point(315, 316);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PasswordChar = '*';
            txtConfirmarContrasena.Size = new Size(204, 29);
            txtConfirmarContrasena.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(49, 321);
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
            // btnRestablecer
            // 
            btnRestablecer.BackColor = Color.Orange;
            btnRestablecer.FlatStyle = FlatStyle.Flat;
            btnRestablecer.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestablecer.Location = new Point(304, 381);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new Size(180, 31);
            btnRestablecer.TabIndex = 6;
            btnRestablecer.Text = "RESTABLECER";
            btnRestablecer.UseVisualStyleBackColor = false;
            btnRestablecer.Click += btnRestablecer_Click;
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtNuevaContrasena.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNuevaContrasena.Location = new Point(325, 195);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.PasswordChar = '*';
            txtNuevaContrasena.Size = new Size(204, 29);
            txtNuevaContrasena.TabIndex = 5;
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(325, 112);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(204, 29);
            txtUsuario.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(71, 200);
            label3.Name = "label3";
            label3.Size = new Size(215, 24);
            label3.TabIndex = 3;
            label3.Text = "Nueva Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 117);
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
            label1.Location = new Point(184, 22);
            label1.Name = "label1";
            label1.Size = new Size(417, 32);
            label1.TabIndex = 1;
            label1.Text = "Recuperación de Contraseña";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRecuperarContrasena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "FormRecuperarContrasena";
            Text = "FormRecuperarContrasena";
            Load += FormRecuperarContrasena_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtConfirmarContrasena;
        private Label label4;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Button btnRestablecer;
        private TextBox txtNuevaContrasena;
        private TextBox txtUsuario;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}