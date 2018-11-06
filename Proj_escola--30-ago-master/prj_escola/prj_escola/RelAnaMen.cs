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
    public partial class RelAnaMen : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_menc;
        BindingSource bs_menc = new BindingSource();
        OleDbDataReader dr_reg_notas;
        BindingSource bs_reg_notas = new BindingSource();
        String _query, menc_a, menc;

        public int pag = 1;
        int registro = 0, linha = 0;
        int fim = 0;
        int cont = 0;
        int flag = 0;

        public RelAnaMen()
        {
            InitializeComponent();
        }

        private void carregar_grid()
        {
            _query = "SELECT Registro_Mencoes.mencao, Alunos.Nome, Alunos.Matricula, Disciplinas.sigla, Disciplinas.descricao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Registro_Mencoes.mencao;";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_menc = _dataCommand.ExecuteReader();
            if (dr_menc.HasRows == true)
            {
                bs_menc.DataSource = dr_menc;
                dgvMen.DataSource = bs_menc;
            }
            else
            {
                MessageBox.Show("Não temos alunos cadastrados !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
 

        private void RelAnaMen_Load(object sender, EventArgs e)
        {
            carregar_grid();
            flag = 1;
            fim = bs_menc.Count;

        }

        private void cbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query = "SELECT Registro_Mencoes.mencao, Alunos.Nome, Alunos.Matricula, Disciplinas.sigla, Disciplinas.descricao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Registro_Mencoes.mencao;";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_menc = _dataCommand.ExecuteReader();
            if (dr_menc.HasRows == true)
            {
                bs_menc.DataSource = dr_menc;
                dgvMen.DataSource = bs_menc;
            }
            else
            {
                MessageBox.Show("Não temos disciplinas cadastradas !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow reg_grid;
            reg_grid = dgvMen.CurrentRow;

            if (cbEscolha.SelectedItem.ToString().Equals("Agrupado por Menção"))
            {
                if (pag < 2)
                {
                    menc = reg_grid.Cells["mencao"].Value.ToString(); ;
                }
                e.Graphics.DrawImage(Image.FromFile("disciplinas.jpg"), 50, 113);
                e.Graphics.DrawString("Relatório agrupado por menção ", new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 300, 150);
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 230, 1150, 230);

                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 230, 1150, 230);
                e.Graphics.DrawString("Menção " + menc, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 75, 235);
                e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 275, 1150, 275);
                linha = 285;

                //  colunas
                e.Graphics.DrawString("Matr  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 50, linha);
                e.Graphics.DrawString("Nome   ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 100, linha);
                e.Graphics.DrawString("Sigla ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 250, linha);
                e.Graphics.DrawString("Descrição ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 370, linha);
                linha = 305;
                while ((linha < 1075) & (registro != fim))
                {

                    menc_a = reg_grid.Cells["mencao"].Value.ToString();
                    if (menc_a.Equals(menc) == false)
                    {
                        e.Graphics.DrawString("Total de Menções: " + cont, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 400, linha);
                        linha += 30;
                        e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                        linha += 15;
                        e.Graphics.DrawString("Menção " + menc_a, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 75, linha);
                        linha += 30;
                        e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, linha, 1150, linha);
                        linha += 15;

                        // colunas
                        e.Graphics.DrawString("Matr  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 50, linha);
                        e.Graphics.DrawString("Nome   ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 100, linha);
                        e.Graphics.DrawString("Sigla ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 250, linha);
                        e.Graphics.DrawString("Descrição ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Blue, 370, linha);

                        linha += 20;
                        menc = menc_a;
                        cont = 0;
                    }
                    cont++;
                    e.Graphics.DrawString(reg_grid.Cells["matricula"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, linha);

                    e.Graphics.DrawString(reg_grid.Cells["nome"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 100, linha);

                    e.Graphics.DrawString(reg_grid.Cells["sigla"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 250, linha);

                    e.Graphics.DrawString(reg_grid.Cells["descricao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 370, linha);

                    bs_menc.MoveNext();

                    reg_grid = dgvMen.CurrentRow;

                    registro += 1;

                    linha += 20;
                    if (registro == fim)
                        e.Graphics.DrawString("Total de Menções: " + cont, new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 400, linha);

                }
            }
            else if (cbEscolha.SelectedItem.ToString() == "Agrupado por Disciplinas")
            {
                //disiciplinas
            }
            else if (cbEscolha.SelectedItem.ToString() == "Boletim")
            {
                //boletim

            }


            //imprime o rodapé do relatório 
            e.Graphics.DrawString("Total de Registros: " + registro.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 550, 1100);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 1), 50, 1115, 800, 1115);
            e.Graphics.DrawString("Data: " + System.DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 50, 1120);
            e.Graphics.DrawString("Hora: " + System.DateTime.Now.ToString("HH:mm:ss"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 300, 1120);
            e.Graphics.DrawString("Pág: " + pag.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 550, 1120);

            pag += 1;

            
            if ((pag > 1) & (registro < fim))
            {
                e.HasMorePages = true;
            }
            else
            {
                
                registro = 0;
                pag = 1;
                bs_menc.MoveFirst();
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
