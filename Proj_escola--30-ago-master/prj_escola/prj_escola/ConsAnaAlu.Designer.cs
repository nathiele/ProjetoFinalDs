namespace prj_escola
{
    partial class ConsAnaAlu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsAnaAlu));
            this.dgvAlu = new System.Windows.Forms.DataGridView();
            this.cbEscolha = new System.Windows.Forms.ComboBox();
            this.lblAlu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlu
            // 
            this.dgvAlu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlu.Location = new System.Drawing.Point(209, 151);
            this.dgvAlu.Name = "dgvAlu";
            this.dgvAlu.Size = new System.Drawing.Size(564, 369);
            this.dgvAlu.TabIndex = 5;
            // 
            // cbEscolha
            // 
            this.cbEscolha.FormattingEnabled = true;
            this.cbEscolha.Location = new System.Drawing.Point(420, 98);
            this.cbEscolha.Name = "cbEscolha";
            this.cbEscolha.Size = new System.Drawing.Size(171, 21);
            this.cbEscolha.TabIndex = 4;
            this.cbEscolha.SelectedIndexChanged += new System.EventHandler(this.cbEscolha_SelectedIndexChanged);
            // 
            // lblAlu
            // 
            this.lblAlu.AutoSize = true;
            this.lblAlu.Location = new System.Drawing.Point(296, 106);
            this.lblAlu.Name = "lblAlu";
            this.lblAlu.Size = new System.Drawing.Size(40, 13);
            this.lblAlu.TabIndex = 3;
            this.lblAlu.Text = "Aluno::";
            // 
            // ConsAnaAlu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.dgvAlu);
            this.Controls.Add(this.cbEscolha);
            this.Controls.Add(this.lblAlu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsAnaAlu";
            this.Text = "Consulta Analítica Aluno";
            this.Load += new System.EventHandler(this.ConsAnaAlu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlu;
        private System.Windows.Forms.ComboBox cbEscolha;
        private System.Windows.Forms.Label lblAlu;
    }
}