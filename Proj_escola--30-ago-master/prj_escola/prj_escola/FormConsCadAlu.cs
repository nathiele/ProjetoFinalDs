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
    public partial class FormConsCadAlu : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_aluno;
        BindingSource bs_aluno = new BindingSource();
        String _query;

        public FormConsCadAlu()
        {

            InitializeComponent();
        }

        private void FormConsCadAlu_FormClosing(object sender, FormClosingEventArgs e)
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
            _query = "Select * from Alunos";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_aluno = _dataCommand.ExecuteReader();
            if (dr_aluno.HasRows == true)
            {
                bs_aluno.DataSource = dr_aluno;
                dgvAlu.DataSource = bs_aluno;

            }
            else
            {
                MessageBox.Show("Não temos esse aluno !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormConsCadAlu_Load(object sender, EventArgs e)
        {
            carregar_grid();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (cbEscolha.Text == "Matrícula")
            {
                _query = "Select * from alunos where Matricula like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Nome")
            {
                _query = "Select * from alunos where Nome like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Nascimento")
            {
                _query = "Select * from alunos where Nasc like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Endereço")
            {
                _query = "Select * from alunos where Endereco like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Número")
            {
                _query = "Select * from alunos where numero like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Bairro")
            {
                _query = "Select * from alunos where bairro like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Cidade")
            {
                _query = "Select * from alunos where cidade like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Cep")
            {
                _query = "Select * from alunos where cep like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "RG")
            {
                _query = "Select * from alunos where RG like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Telefone")
            {
                _query = "Select * from alunos where telefone like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "Sexo")
            {
                _query = "Select * from alunos where sexo like '" + txtPesquisar.Text + "%'";
            }
            else if (cbEscolha.Text == "CPF")
            {
                _query = "Select * from disciplinas where cpf like '" + txtPesquisar.Text + "%'";
            }
            else
            {
                MessageBox.Show("Escolha um campo pra pesquisar!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbEscolha.Focus();
            }

            txtPesquisar.Focus();
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_aluno = _dataCommand.ExecuteReader();

            if (dr_aluno.HasRows == true)
            {
                bs_aluno.DataSource = dr_aluno;
            }
            else
            {
                MessageBox.Show("Não temos nenhum aluno com esse parametro!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesquisar.Clear();
            }
        }

        private void btnQtd_Click(object sender, EventArgs e)
        {
            int a = bs_aluno.Count;
            MessageBox.Show("Quantidade: " + a, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow linha;
            linha = dgvAlu.CurrentRow;

            e.Graphics.DrawImage(Image.FromFile("aluno.PNG"), 50, 25);
            e.Graphics.DrawString("FICHA INDIVIDUAL DO ALUNO", new System.Drawing.Font("Times new roman", 16, FontStyle.Bold), Brushes.Black, 400, 255);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 280, 800, 280);

            e.Graphics.DrawString("MATRÍCULA:  " + linha.Cells["Matricula"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 300);
            e.Graphics.DrawString("NOME:   " + linha.Cells["Nome"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 320);
            e.Graphics.DrawString("NASCIMENTO : " + linha.Cells["Nasc"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 340);
            e.Graphics.DrawString("ENDEREÇO : " + linha.Cells["Endereco"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 360);
            e.Graphics.DrawString("NÚMERO : " + linha.Cells["numero"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 380);
            e.Graphics.DrawString("BAIRRO : " + linha.Cells["bairro"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 400);
            e.Graphics.DrawString("CIDADE : " + linha.Cells["cidade"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 420);
            e.Graphics.DrawString("CEP : " + linha.Cells["cep"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 440);
            e.Graphics.DrawString("RG : " + linha.Cells["RG"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 460);
            e.Graphics.DrawString("TELEFONE : " + linha.Cells["telefone"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 480);
            e.Graphics.DrawString("SEXO : " + linha.Cells["sexo"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 500);
            e.Graphics.DrawString("CPF : " + linha.Cells["cpf"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, 520);
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
