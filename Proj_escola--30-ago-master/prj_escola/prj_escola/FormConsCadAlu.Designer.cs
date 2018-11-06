namespace prj_escola
{
    partial class FormConsCadAlu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsCadAlu));
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbEscolha = new System.Windows.Forms.ComboBox();
            this.lblEscolha = new System.Windows.Forms.Label();
            this.btnQtd = new System.Windows.Forms.Button();
            this.btnVisu = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dgvAlu = new System.Windows.Forms.DataGridView();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(532, 70);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(317, 20);
            this.txtPesquisar.TabIndex = 5;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // cbEscolha
            // 
            this.cbEscolha.FormattingEnabled = true;
            this.cbEscolha.Items.AddRange(new object[] {
            "Matrícula",
            "Nome",
            "Nascimento",
            "Endereço",
            "Número",
            "Bairro",
            "Cidade",
            "Cep",
            "RG",
            "Telefone",
            "Sexo",
            "CPF"});
            this.cbEscolha.Location = new System.Drawing.Point(338, 69);
            this.cbEscolha.Name = "cbEscolha";
            this.cbEscolha.Size = new System.Drawing.Size(121, 21);
            this.cbEscolha.TabIndex = 4;
            this.cbEscolha.Text = "Escolha";
            // 
            // lblEscolha
            // 
            this.lblEscolha.AutoSize = true;
            this.lblEscolha.Location = new System.Drawing.Point(102, 69);
            this.lblEscolha.Name = "lblEscolha";
            this.lblEscolha.Size = new System.Drawing.Size(181, 13);
            this.lblEscolha.TabIndex = 3;
            this.lblEscolha.Text = "Escolha o campo a ser pesquisado ::";
            // 
            // btnQtd
            // 
            this.btnQtd.Location = new System.Drawing.Point(732, 367);
            this.btnQtd.Name = "btnQtd";
            this.btnQtd.Size = new System.Drawing.Size(102, 59);
            this.btnQtd.TabIndex = 10;
            this.btnQtd.Text = "Quantidade de Selecionados";
            this.btnQtd.UseVisualStyleBackColor = true;
            this.btnQtd.Click += new System.EventHandler(this.btnQtd_Click);
            // 
            // btnVisu
            // 
            this.btnVisu.Image = ((System.Drawing.Image)(resources.GetObject("btnVisu.Image")));
            this.btnVisu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisu.Location = new System.Drawing.Point(105, 444);
            this.btnVisu.Name = "btnVisu";
            this.btnVisu.Size = new System.Drawing.Size(86, 44);
            this.btnVisu.TabIndex = 9;
            this.btnVisu.Text = "     Visualizar";
            this.btnVisu.UseVisualStyleBackColor = true;
            this.btnVisu.Click += new System.EventHandler(this.btnVisu_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(105, 367);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(86, 47);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "     Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // dgvAlu
            // 
            this.dgvAlu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlu.Location = new System.Drawing.Point(105, 116);
            this.dgvAlu.Name = "dgvAlu";
            this.dgvAlu.Size = new System.Drawing.Size(729, 214);
            this.dgvAlu.TabIndex = 7;
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
            // FormConsCadAlu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.btnQtd);
            this.Controls.Add(this.btnVisu);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dgvAlu);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbEscolha);
            this.Controls.Add(this.lblEscolha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsCadAlu";
            this.Text = "Consulta de Alunos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConsCadAlu_FormClosing);
            this.Load += new System.EventHandler(this.FormConsCadAlu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbEscolha;
        private System.Windows.Forms.Label lblEscolha;
        private System.Windows.Forms.Button btnQtd;
        private System.Windows.Forms.Button btnVisu;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvAlu;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}