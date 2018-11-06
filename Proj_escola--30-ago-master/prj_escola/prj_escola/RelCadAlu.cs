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
    public partial class RelCadAlu : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_alunos;
        BindingSource bs_alunos = new BindingSource();
        String _query;

        public int pag = 1;
        int registro, linha = 0;
        int fim = 0;
        int flag = 0;

        public RelCadAlu()
        {
            InitializeComponent();
        }

        public void carregar_grid()
        {
            _query = "Select * from Alunos";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_alunos = _dataCommand.ExecuteReader();
            if (dr_alunos.HasRows == true)
            {
                bs_alunos.DataSource = dr_alunos;
                dgvAluno.DataSource = bs_alunos;

            }
            else
            {
                MessageBox.Show("Não temos esse aluno cadastrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void RelCadAlu_Load(object sender, EventArgs e)
        {
            carregar_grid();
            fim = bs_alunos.Count;
            printDocument1.DefaultPageSettings.Landscape = true;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataGridViewRow reg_grid;
            reg_grid = dgvAluno.CurrentRow;

            e.Graphics.DrawImage(Image.FromFile("aluno.PNG"), 50, 15);
            // texto = objimpressao.DrawString(string,fonte,cor,coluna,linha)
            e.Graphics.DrawString("RELATÓRIO GERAL DE ALUNOS", new System.Drawing.Font("Times new roman", 14, FontStyle.Bold), Brushes.Black, 500, 180);
            //linha – cor, espessura, posição x – ponto inicial(coluna e linha), posição y – ponto final (coluna e linha)

            linha = 230;

            // cabeçalho de colunas
            e.Graphics.DrawString("Matricula  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 50, linha);
            e.Graphics.DrawString("Nome  ", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 130, linha);
            e.Graphics.DrawString("Nasc", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 250, linha);
            e.Graphics.DrawString("Endereco", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 350, linha);
            e.Graphics.DrawString("numero", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 550, linha);
            e.Graphics.DrawString("bairro", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 650, linha);
            e.Graphics.DrawString("cidade", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 750, linha);
            e.Graphics.DrawString("cep", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 850, linha);
            e.Graphics.DrawString("RG", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 950, linha);
            e.Graphics.DrawString("telefone", new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Black, 1050, linha);

            linha = 260;

            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 2), 50, 220, 1120, 220);

            while ((linha < 750) & (registro != fim))
            {
                // código
                e.Graphics.DrawString(reg_grid.Cells["Matricula"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, linha);
                // descrição
                e.Graphics.DrawString(reg_grid.Cells["Nome"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 130, linha);
                // sigla
                e.Graphics.DrawString(String.Format("{0:dd/MM/yyyy}", reg_grid.Cells["nasc"].Value), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 250, linha);
                e.Graphics.DrawString(reg_grid.Cells["Endereco"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 350, linha);
                e.Graphics.DrawString(reg_grid.Cells["numero"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 550, linha);
                e.Graphics.DrawString(reg_grid.Cells["bairro"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 650, linha);
                e.Graphics.DrawString(reg_grid.Cells["cidade"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 750, linha);
                e.Graphics.DrawString(reg_grid.Cells["cep"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 850, linha);
                e.Graphics.DrawString(reg_grid.Cells["RG"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 950, linha);
                e.Graphics.DrawString(reg_grid.Cells["telefone"].Value.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1050, linha);

                bs_alunos.MoveNext(); // movendo para o próximo registro

                reg_grid = dgvAluno.CurrentRow;  // atualizando a linha da grid para impressão

                registro += 1;   // incrementando a variável contadora de registros

                linha += 20; // incrementando a variável para pular linha
            }

            //***************************** 
            //imprime o rodapé do relatório 
            //***************************** 
            e.Graphics.DrawString("Total de Registros: " + registro.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 980, 765);
            e.Graphics.DrawLine(new Pen(Color.DarkBlue, 1), 50, 780, 1120, 780);
            e.Graphics.DrawString("Data: " + System.DateTime.Now.ToString("dd/MM/yyyy"), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 50, 790);
            e.Graphics.DrawString("Pág: " + pag.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Blue, 980, 790);

            pag += 1;  // reajustando contadores de pag

            // trocando de página
            if ((pag > 1) & (registro < fim))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                registro = 0;
                pag = 1;
                bs_alunos.MoveFirst();
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
