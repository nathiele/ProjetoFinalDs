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
    public partial class RelCadDisciplina : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_disc;
        BindingSource bs_disc = new BindingSource();
        String _query;

        public int pag = 1;
        int registro, linha = 0;
        int fim = 0;

        public RelCadDisciplina()
        {
            InitializeComponent();
        }

        public void carregar_grid()
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
                MessageBox.Show("Não temos Disciplinas cadastradas !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void RelCadDisciplina_Load(object sender, EventArgs e)
        {
            carregar_grid();
            fim = bs_disc.Count;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow reg_grid;
            reg_grid = dgvDisc.CurrentRow;

            e.Graphics.DrawImage(Image.FromFile("materia.PNG"), 50, 25);
            // texto = objimpressao.DrawString(string,fonte,cor,coluna,linha)
            e.Graphics.DrawString("RELATÓRIO GERAL DE DISCIPLINAS", new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 400, 170);
            //linha – cor, espessura, posição x – ponto inicial(coluna e linha), posição y – ponto final (coluna e linha)

            linha = 210;

            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 200, 800, 200);
            // cabeçalho de colunas
            e.Graphics.DrawString("Cód  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, linha);
            e.Graphics.DrawString("Descrição   ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, linha);
            e.Graphics.DrawString("Sigla ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 500, linha);

            linha = 230;

            while ((linha < 1075) & (registro != fim))
            {
                // código
                e.Graphics.DrawString(reg_grid.Cells["cod_disciplina"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, linha);
                // descrição
                e.Graphics.DrawString(reg_grid.Cells["descricao"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 100, linha);
                // sigla
                e.Graphics.DrawString(reg_grid.Cells["sigla"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 500, linha);

                bs_disc.MoveNext(); // movendo para o próximo registro

                reg_grid = dgvDisc.CurrentRow;  // atualizando a linha da grid para impressão

                registro += 1;   // incrementando a variável contadora de registros

                linha += 20; // incrementando a variável para pular linha
            }

            //***************************** 
            //imprime o rodapé do relatório 
            //***************************** 
            e.Graphics.DrawString("Total de Registros: " + registro.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 550, 1100);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 1), 50, 1115, 800, 1115);
            e.Graphics.DrawString("Data: " + System.DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 50, 1120);
            e.Graphics.DrawString("Pág: " + pag.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 550, 1120);

            pag += 1;  // reajustando contadores de pag

            // trocando de página
            if ((pag > 1) & (registro < fim))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                pag = 1;
                registro = 0;
                bs_disc.MoveFirst();
            }
           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument1.Print();   

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Text = " Visualizando a impressão";   // título da janela
            printPreviewDialog1.WindowState = FormWindowState.Maximized;  // status da janela do preview
            printPreviewDialog1.PrintPreviewControl.Columns = 2;   //  quantas páginas serão mostradas na tela
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.6;   //  zoom inicial do preview
            printPreviewDialog1.ShowDialog();

        }


    }
}
