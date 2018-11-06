namespace prj_escola
{
    partial class FrmConsCadDisc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsCadDisc));
            this.lblEscolha = new System.Windows.Forms.Label();
            this.cbEscolha = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dgvDisc = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVisu = new System.Windows.Forms.Button();
            this.btnQtd = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisc)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEscolha
            // 
            this.lblEscolha.AutoSize = true;
            this.lblEscolha.Location = new System.Drawing.Point(84, 51);
            this.lblEscolha.Name = "lblEscolha";
            this.lblEscolha.Size = new System.Drawing.Size(181, 13);
            this.lblEscolha.TabIndex = 0;
            this.lblEscolha.Text = "Escolha o campo a ser pesquisado ::";
            // 
            // cbEscolha
            // 
            this.cbEscolha.FormattingEnabled = true;
            this.cbEscolha.Items.AddRange(new object[] {
            "Código da Disciplina",
            "Descrição",
            "Sigla"});
            this.cbEscolha.Location = new System.Drawing.Point(303, 51);
            this.cbEscolha.Name = "cbEscolha";
            this.cbEscolha.Size = new System.Drawing.Size(121, 21);
            this.cbEscolha.TabIndex = 1;
            this.cbEscolha.Text = "Escolha";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(497, 52);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(317, 20);
            this.txtPesquisar.TabIndex = 2;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // dgvDisc
            // 
            this.dgvDisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisc.Location = new System.Drawing.Point(112, 114);
            this.dgvDisc.Name = "dgvDisc";
            this.dgvDisc.Size = new System.Drawing.Size(729, 214);
            this.dgvDisc.TabIndex = 3;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(112, 378);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(91, 42);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "     Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVisu
            // 
            this.btnVisu.Image = ((System.Drawing.Image)(resources.GetObject("btnVisu.Image")));
            this.btnVisu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisu.Location = new System.Drawing.Point(112, 454);
            this.btnVisu.Name = "btnVisu";
            this.btnVisu.Size = new System.Drawing.Size(91, 41);
            this.btnVisu.TabIndex = 5;
            this.btnVisu.Text = "     Visualizar";
            this.btnVisu.UseVisualStyleBackColor = true;
            this.btnVisu.Click += new System.EventHandler(this.btnVisu_Click);
            // 
            // btnQtd
            // 
            this.btnQtd.Location = new System.Drawing.Point(739, 378);
            this.btnQtd.Name = "btnQtd";
            this.btnQtd.Size = new System.Drawing.Size(102, 59);
            this.btnQtd.TabIndex = 6;
            this.btnQtd.Text = "Quantidade de Selecionados";
            this.btnQtd.UseVisualStyleBackColor = true;
            this.btnQtd.Click += new System.EventHandler(this.btnQtd_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FrmConsCadDisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.btnQtd);
            this.Controls.Add(this.btnVisu);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dgvDisc);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbEscolha);
            this.Controls.Add(this.lblEscolha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConsCadDisc";
            this.Text = "Consulta de Disciplinas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsCadDisc_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsCadDisc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEscolha;
        private System.Windows.Forms.ComboBox cbEscolha;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView dgvDisc;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVisu;
        private System.Windows.Forms.Button btnQtd;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}