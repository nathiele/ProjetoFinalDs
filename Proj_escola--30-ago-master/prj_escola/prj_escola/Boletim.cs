using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace prj_escola
{
    public partial class Boletim : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_bol;
        BindingSource bs_bol = new BindingSource();
        OleDbDataReader dr_reg_boletim;
        BindingSource bs_reg_boletim = new BindingSource();
        String _query, desc_a, sigla_a, nome_a, matricula, nome, sigla, desc, men;

        public int pag = 1;
        int registro = 0, linha = 0;
        int fim = 0;
        int cont = 0;
        int flag = 0;

        public Boletim()
        {
            InitializeComponent();
        }

        private void carregar_grid()
        {
            _query = "SELECT Alunos.Nome, Alunos.Matricula, Registro_Mencoes.mencao, Disciplinas.sigla, Disciplinas.descricao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Alunos.Nome;";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_bol = _dataCommand.ExecuteReader();
            if (dr_bol.HasRows == true)
            {
                bs_bol.DataSource = dr_bol;
                dgvBoletim.DataSource = bs_bol;
            }
            else
            {
                MessageBox.Show("Não temos boletim cadastrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void Boletim_Load(object sender, EventArgs e)
        {
            carregar_grid();
            flag = 1;
            fim = bs_bol.Count;

        }

        private void cbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query = "SELECT Alunos.Nome, Alunos.Matricula, Registro_Mencoes.mencao, Disciplinas.sigla, Disciplinas.descricao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Alunos.Nome;";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_bol = _dataCommand.ExecuteReader();
            if (dr_bol.HasRows == true)
            {
                bs_bol.DataSource = dr_bol;
                dgvBoletim.DataSource = bs_bol;
            }
            else
            {
                MessageBox.Show("Não temos boletim cadastrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow reg_grid;
            reg_grid = dgvBoletim.CurrentRow;

            if (cbEscolha.SelectedItem.ToString().Equals("Boletim"))
            {
                if (pag < 2)
                {
                    nome = reg_grid.Cells["nome"].Value.ToString(); ;
                    matricula = reg_grid.Cells["matricula"].Value.ToString(); ;
                }
                e.Graphics.DrawImage(Image.FromFile("disciplinas.jpg"), 50, 113);
                e.Graphics.DrawString("Boletim do Aluno", new System.Drawing.Font("Times new roman", 20, FontStyle.Bold), Brushes.Black, 300, 150);
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 230, 1150, 230);

                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 230, 1150, 230);
                e.Graphics.DrawString("Nome: " + nome, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 75, 235);
                e.Graphics.DrawString("Matricula: " + matricula, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 500, 235);
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 275, 1150, 275);
                linha = 285;

                //  colunas
                e.Graphics.DrawString("Sigla  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 50, linha);
                e.Graphics.DrawString("Descrição   ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 200, linha);
                e.Graphics.DrawString("Menção ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 550, linha);
                linha = 305;

                while ((linha < 1075) & (registro != fim))
                {
                    nome_a = reg_grid.Cells["nome"].Value.ToString();
                    matricula = reg_grid.Cells["matricula"].Value.ToString();
                    if (nome.Equals(nome_a) == false)
                    {
                        linha += 15;
                        e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                        linha = 1776;
                    }

                    else
                    {

                        cont++;
                        e.Graphics.DrawString(reg_grid.Cells["sigla"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, linha);

                        e.Graphics.DrawString(reg_grid.Cells["descricao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 200, linha);

                        e.Graphics.DrawString(reg_grid.Cells["mencao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 550, linha);

                        bs_bol.MoveNext();
                        reg_grid = dgvBoletim.CurrentRow;

                        registro += 1;

                        linha += 20;

                    }
                }

            }

            //imprime o rodapé do relatório 
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 1), 50, 1115, 800, 1115);
            e.Graphics.DrawString("Data: " + System.DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 350, 1120);

            pag += 1;

            // trocando de página
            if ((pag > 1) & (registro < fim))
            {
                //Reinicia o PrintDocument
                e.HasMorePages = true;
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                linha += 15;
                e.Graphics.DrawString("Nome " + nome, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 75, linha);
                e.Graphics.DrawString("Matricula " + matricula, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 200, linha);
                linha += 30;
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                linha += 15;

                // colunas
                e.Graphics.DrawString("Sigla  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 50, linha);
                e.Graphics.DrawString("Descrição  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 200, linha);
                e.Graphics.DrawString("Menção ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 550, linha);

                linha += 20;
                nome = nome_a;
                cont = 0;
            }
            else
            {
                registro = 0;
                pag = 1;
                bs_bol.MoveFirst();
                e.HasMorePages = false;
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument1.Print();

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Text = " Visualizando a impressão";
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Columns = 2;
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.6;
            printPreviewDialog1.ShowDialog();

        }
    }
}
