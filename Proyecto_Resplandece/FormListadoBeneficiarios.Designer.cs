namespace Proyecto_Resplandece
{
    partial class FormListadoBeneficiarios
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
            btnConsultar = new Button();
            label2 = new Label();
            dgvBeneficiarios = new DataGridView();
            label1 = new Label();
            cmbTutor = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBeneficiarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(cmbTutor);
            panel1.Controls.Add(btnConsultar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvBeneficiarios);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1010, 629);
            panel1.TabIndex = 1;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.Orange;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Bookman Old Style", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConsultar.Location = new Point(734, 114);
            btnConsultar.Margin = new Padding(4, 5, 4, 5);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(129, 42);
            btnConsultar.TabIndex = 44;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(58, 120);
            label2.Name = "label2";
            label2.Size = new Size(266, 28);
            label2.TabIndex = 4;
            label2.Text = "Seleccione un tutor:";
            // 
            // dgvBeneficiarios
            // 
            dgvBeneficiarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBeneficiarios.Location = new Point(34, 177);
            dgvBeneficiarios.Name = "dgvBeneficiarios";
            dgvBeneficiarios.RowHeadersWidth = 62;
            dgvBeneficiarios.Size = new Size(936, 420);
            dgvBeneficiarios.TabIndex = 3;
            dgvBeneficiarios.CellContentDoubleClick += dgvBeneficiarios_CellContentDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(262, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(462, 48);
            label1.TabIndex = 1;
            label1.Text = "Lista de Beneficiario";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // cmbTutor
            // 
            cmbTutor.FormattingEnabled = true;
            cmbTutor.Location = new Point(330, 119);
            cmbTutor.Name = "cmbTutor";
            cmbTutor.Size = new Size(367, 33);
            cmbTutor.TabIndex = 45;
            // 
            // FormListadoBeneficiarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 629);
            Controls.Add(panel1);
            Name = "FormListadoBeneficiarios";
            Text = "FormListadoBeneficiarios";
            Load += FormListadoBeneficiarios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBeneficiarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private DataGridView dgvBeneficiarios;
        private Button btnConsultar;
        private ComboBox cmbTutor;
    }
}