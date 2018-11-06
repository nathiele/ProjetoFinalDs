using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;



namespace prj_escola
{
    public partial class FrmConsCadDisc : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_disc;
        BindingSource bs_disc = new BindingSource();
        String _query;

        public FrmConsCadDisc()
        {
            InitializeComponent();
        }

        private void FrmConsCadDisc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Sair??", "Título ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MessageBox.Show("Saindo");
            else
            {
                MessageBox.Show("Ficando");
                e.Cancel = true;
            }
        }

        private void carregar_grid()
        {
            _query = "Select * from Disciplinas";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_disc = _dataCommand.ExecuteReader();
            if (dr_disc.HasRows == true)
            {
                bs_disc.DataSource = dr_disc;
                dgvDisc.DataSource = bs_disc;
                
            }
            else
            {
                MessageBox.Show("Não temos essa disciplina !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmConsCadDisc_Load(object sender, EventArgs e)
        {
            carregar_grid();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (cbEscolha.Text == "Sigla")
            {
                _query = "Select * from disciplinas where sigla like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Descrição")
            {
                _query = "Select * from disciplinas where descricao like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Código da Disciplina")
            {
                _query = "Select * from disciplinas where cod_disciplina like '" + txtPesquisar.Text + "%'";
            }
            else 
            {
                MessageBox.Show("Escolha um campo pra pesquisar!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbEscolha.Focus();
            }

            txtPesquisar.Focus();
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_disc = _dataCommand.ExecuteReader();

            if (dr_disc.HasRows == true)
            {
                bs_disc.DataSource = dr_disc;
            }
            else
            {
                MessageBox.Show("Não temos nenhuma disciplina com esse parametro!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesquisar.Clear();
            }
        }

        private void btnQtd_Click(object sender, EventArgs e)
        {
            int a = bs_disc.Count;
            MessageBox.Show("Quantidade: " + a, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow linha;
            linha = dgvDisc.CurrentRow;

            e.Graphics.DrawImage(Image.FromFile("disciplinas.JPG"), 20, 20);
            e.Graphics.DrawString("FICHA INDIVIDUAL DE DISCIPLINA", new System.Drawing.Font("Times new roman", 16, FontStyle.Bold), Brushes.Black, 440, 120);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 150, 800, 150);
            e.Graphics.DrawString("CÓDIGO DA DISCIPLINA:  " + linha.Cells["cod_disciplina"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 250);
            e.Graphics.DrawString("DESCRIÇÃO:   " + linha.Cells["descricao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 270);
            e.Graphics.DrawString("SIGLA : " + linha.Cells["sigla"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 290);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 1100, 800, 1100);

        }

        private void btnVisu_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Text = " Visualizando a impressão";   
            printPreviewDialog1.WindowState = FormWindowState.Maximized;  
            printPreviewDialog1.PrintPreviewControl.Columns = 2;   
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.6;   
            printPreviewDialog1.ShowDialog();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument1.Print();                             

        }

        

    }
}
