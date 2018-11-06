namespace prj_escola
{
    partial class ConsAnaMen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsAnaMen));
            this.lblMen = new System.Windows.Forms.Label();
            this.cbEscolha = new System.Windows.Forms.ComboBox();
            this.dgvMen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMen
            // 
            this.lblMen.AutoSize = true;
            this.lblMen.Location = new System.Drawing.Point(290, 134);
            this.lblMen.Name = "lblMen";
            this.lblMen.Size = new System.Drawing.Size(52, 13);
            this.lblMen.TabIndex = 0;
            this.lblMen.Text = "Menção::";
            // 
            // cbEscolha
            // 
            this.cbEscolha.FormattingEnabled = true;
            this.cbEscolha.Location = new System.Drawing.Point(414, 126);
            this.cbEscolha.Name = "cbEscolha";
            this.cbEscolha.Size = new System.Drawing.Size(171, 21);
            this.cbEscolha.TabIndex = 1;
            this.cbEscolha.SelectedIndexChanged += new System.EventHandler(this.cbEscolha_SelectedIndexChanged);
            // 
            // dgvMen
            // 
            this.dgvMen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMen.Location = new System.Drawing.Point(203, 179);
            this.dgvMen.Name = "dgvMen";
            this.dgvMen.Size = new System.Drawing.Size(564, 369);
            this.dgvMen.TabIndex = 2;
            // 
            // ConsAnaMen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.dgvMen);
            this.Controls.Add(this.cbEscolha);
            this.Controls.Add(this.lblMen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsAnaMen";
            this.Text = "Consulta Analítica Menção";
            this.Load += new System.EventHandler(this.ConsAnaMen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMen;
        private System.Windows.Forms.ComboBox cbEscolha;
        private System.Windows.Forms.DataGridView dgvMen;
    }
}