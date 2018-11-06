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
    public partial class RelAnaDisc : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_disc;
        BindingSource bs_disc = new BindingSource();
        OleDbDataReader dr_reg_disc;
        BindingSource bs_reg_disc = new BindingSource();
        String _query, desc_a, sigla_a, descricao, sigla;

        public int pag = 1;
        int registro = 0, linha = 0;
        int fim = 0;
        int cont = 0;
        int flag = 0;

        public RelAnaDisc()
        {
            InitializeComponent();
        }
        private void carregar_grid()
        {
            _query = "SELECT Registro_Mencoes.mencao, Alunos.Nome, Alunos.Matricula, Disciplinas.sigla, Disciplinas.descricao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Disciplinas.sigla;";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_disc = _dataCommand.ExecuteReader();
            if (dr_disc.HasRows == true)
            {
                bs_disc.DataSource = dr_disc;
                dgvDisc.DataSource = bs_disc;
            }
            else
            {
                MessageBox.Show("Não temos disciplinas cadastrados !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void RelAnaDisc_Load(object sender, EventArgs e)
        {
            carregar_grid();
            flag = 1;
            fim = bs_disc.Count;
        }

        private void cbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query = "SELECT Registro_Mencoes.mencao, Alunos.Nome, Alunos.Matricula, Disciplinas.sigla, Disciplinas.descricao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Disciplinas.sigla;";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_disc = _dataCommand.ExecuteReader();
            if (dr_disc.HasRows == true)
            {
                bs_disc.DataSource = dr_disc;
                dgvDisc.DataSource = bs_disc;
            }
            else
            {
                MessageBox.Show("Não temos disciplinas cadastradas !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow reg_grid;
            reg_grid = dgvDisc.CurrentRow;

            if (cbEscolha.SelectedItem.ToString().Equals("Agrupado por Disciplina"))
            {
                if (pag < 2)
                {
                    sigla = reg_grid.Cells["sigla"].Value.ToString(); ;
                    descricao = reg_grid.Cells["descricao"].Value.ToString(); ;
                }
                e.Graphics.DrawImage(Image.FromFile("disciplinas.jpg"), 50, 113);
                e.Graphics.DrawString("Relatório agrupado por disciplina ", new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 300, 150);
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 230, 1150, 230);

                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 230, 1150, 230);
                e.Graphics.DrawString("Sigla " + sigla, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 75, 235);
                e.Graphics.DrawString("Disciplina " + descricao, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 200, 235);
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 275, 1150, 275);
                linha = 285;

                //  colunas
                e.Graphics.DrawString("Matr  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 50, linha);
                e.Graphics.DrawString("Nome   ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 100, linha);
                e.Graphics.DrawString("Menção ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 250, linha);
                linha = 305;

                desc_a = reg_grid.Cells["descricao"].Value.ToString();
                sigla_a = reg_grid.Cells["sigla"].Value.ToString();
                while ((linha < 1075) & (registro != fim))
                {
                    desc_a = reg_grid.Cells["descricao"].Value.ToString();
                    sigla_a = reg_grid.Cells["sigla"].Value.ToString();
                    if (desc_a.Equals(descricao) == false)
                    {
                        e.Graphics.DrawString("Total da Disciplinas: " + cont, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 400, linha);
                        linha += 30;
                        e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                        linha += 15;
                        e.Graphics.DrawString("Sigla " + sigla_a, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 75, linha);
                        e.Graphics.DrawString("Disciplina " + desc_a, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 200, linha);
                        linha += 30;
                        e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                        linha += 15;

                        // colunas
                        e.Graphics.DrawString("Mat  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 50, linha);
                        e.Graphics.DrawString("Nome   ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 100, linha);
                        e.Graphics.DrawString("Menção ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 250, linha);

                        linha += 20;
                        descricao = desc_a;
                        sigla = sigla_a;

                        cont = 0;
                    }
                    cont++;
                    e.Graphics.DrawString(reg_grid.Cells["matricula"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, linha);

                    e.Graphics.DrawString(reg_grid.Cells["Nome"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 100, linha);

                    e.Graphics.DrawString(reg_grid.Cells["mencao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 250, linha);

                    bs_disc.MoveNext();
                    reg_grid = dgvDisc.CurrentRow;

                    registro += 1;

                    linha += 20;

                    if (registro == fim)
                        e.Graphics.DrawString("Total da Disciplina: " + cont, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 400, linha);

                }

            }


            //imprime o rodapé do relatório 
            e.Graphics.DrawString("Total de Registros: " + registro.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 550, 1100);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 1), 50, 1115, 800, 1115);
            e.Graphics.DrawString("Data: " + System.DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 50, 1120);
            e.Graphics.DrawString("Hora: " + System.DateTime.Now.ToString("HH:mm:ss"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 300, 1120);
            e.Graphics.DrawString("Pág: " + pag.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 550, 1120);

            pag += 1;

            // trocando de página
            if ((pag > 1) & (registro < fim))
            {
                //Reinicia o PrintDocument
                e.HasMorePages = true;
            }
            else
            {
                //Encerra a Ação do PrintDocument
                registro = 0;
                pag = 1;
                bs_disc.MoveFirst();
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
