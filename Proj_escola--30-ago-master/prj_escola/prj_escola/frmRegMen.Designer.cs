namespace prj_escola
{
    partial class frmRegMen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegMen));
            this.lblAluno = new System.Windows.Forms.Label();
            this.lblDisc = new System.Windows.Forms.Label();
            this.lblMen = new System.Windows.Forms.Label();
            this.cbAluno = new System.Windows.Forms.ComboBox();
            this.cbDisc = new System.Windows.Forms.ComboBox();
            this.cbMencao = new System.Windows.Forms.ComboBox();
            this.lblMat = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvMencao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMencao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAluno
            // 
            this.lblAluno.AutoSize = true;
            this.lblAluno.Location = new System.Drawing.Point(67, 53);
            this.lblAluno.Name = "lblAluno";
            this.lblAluno.Size = new System.Drawing.Size(43, 13);
            this.lblAluno.TabIndex = 0;
            this.lblAluno.Text = "Aluno ::";
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Location = new System.Drawing.Point(67, 92);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(61, 13);
            this.lblDisc.TabIndex = 1;
            this.lblDisc.Text = "Disciplina ::";
            // 
            // lblMen
            // 
            this.lblMen.AutoSize = true;
            this.lblMen.Location = new System.Drawing.Point(67, 145);
            this.lblMen.Name = "lblMen";
            this.lblMen.Size = new System.Drawing.Size(55, 13);
            this.lblMen.TabIndex = 2;
            this.lblMen.Text = "Menção ::";
            // 
            // cbAluno
            // 
            this.cbAluno.FormattingEnabled = true;
            this.cbAluno.Location = new System.Drawing.Point(155, 53);
            this.cbAluno.Name = "cbAluno";
            this.cbAluno.Size = new System.Drawing.Size(181, 21);
            this.cbAluno.TabIndex = 3;
            this.cbAluno.SelectedIndexChanged += new System.EventHandler(this.cbAluno_SelectedIndexChanged);
            // 
            // cbDisc
            // 
            this.cbDisc.FormattingEnabled = true;
            this.cbDisc.Location = new System.Drawing.Point(155, 92);
            this.cbDisc.Name = "cbDisc";
            this.cbDisc.Size = new System.Drawing.Size(181, 21);
            this.cbDisc.TabIndex = 4;
            this.cbDisc.SelectedIndexChanged += new System.EventHandler(this.cbDisc_SelectedIndexChanged);
            // 
            // cbMencao
            // 
            this.cbMencao.FormattingEnabled = true;
            this.cbMencao.Location = new System.Drawing.Point(155, 145);
            this.cbMencao.Name = "cbMencao";
            this.cbMencao.Size = new System.Drawing.Size(121, 21);
            this.cbMencao.TabIndex = 5;
            // 
            // lblMat
            // 
            this.lblMat.AutoSize = true;
            this.lblMat.Location = new System.Drawing.Point(391, 52);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(0, 13);
            this.lblMat.TabIndex = 6;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(394, 99);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(0, 13);
            this.lblCod.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(671, 170);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 54);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvMencao
            // 
            this.dgvMencao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMencao.Location = new System.Drawing.Point(227, 257);
            this.dgvMencao.Name = "dgvMencao";
            this.dgvMencao.Size = new System.Drawing.Size(519, 219);
            this.dgvMencao.TabIndex = 9;
            // 
            // frmRegMen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.dgvMencao);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.lblMat);
            this.Controls.Add(this.cbMencao);
            this.Controls.Add(this.cbDisc);
            this.Controls.Add(this.cbAluno);
            this.Controls.Add(this.lblMen);
            this.Controls.Add(this.lblDisc);
            this.Controls.Add(this.lblAluno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegMen";
            this.Text = "Registro de Menções";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegMen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMencao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAluno;
        private System.Windows.Forms.Label lblDisc;
        private System.Windows.Forms.Label lblMen;
        private System.Windows.Forms.ComboBox cbAluno;
        private System.Windows.Forms.ComboBox cbDisc;
        private System.Windows.Forms.ComboBox cbMencao;
        private System.Windows.Forms.Label lblMat;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvMencao;
    }
}