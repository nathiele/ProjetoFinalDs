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
    public partial class frmDisc : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_disciplinas;
        BindingSource bs_disciplinas = new BindingSource();
        String _query;

        public frmDisc()
        {
            InitializeComponent();
        }

        private void frmDisc_FormClosing(object sender, FormClosingEventArgs e)
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
            dr_disciplinas = _dataCommand.ExecuteReader();
            if (dr_disciplinas.HasRows == true)
            {
                bs_disciplinas.DataSource = dr_disciplinas;
                dgvDisc.DataSource = bs_disciplinas;
                igualar_text();
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastrados !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void igualar_text()
        {
            lblDisc.DataBindings.Add("Text", bs_disciplinas, "cod_disciplina");
            lblDisc.DataBindings.Clear();
            txtDesc.DataBindings.Add("Text", bs_disciplinas, "descricao");
            txtDesc.DataBindings.Clear();
            txtSigla.DataBindings.Add("Text", bs_disciplinas, "sigla");
            txtSigla.DataBindings.Clear();
            txtSerie.DataBindings.Add("Text", bs_disciplinas, "série");
            txtSerie.DataBindings.Clear();
           
        }

        private void frmDisc_Load(object sender, EventArgs e)
        {
            carregar_grid();
        }

        private void dgvDisc_Click(object sender, EventArgs e)
        {
            igualar_text();
        }

        private void dgvDisc_KeyUp(object sender, KeyEventArgs e)
        {
            igualar_text();
        }

        private void btnPrim_Click(object sender, EventArgs e)
        {
            bs_disciplinas.MoveFirst();
            igualar_text();
        }

        private void btnAnt_Click(object sender, EventArgs e)
        {
            if (bs_disciplinas.Position == 0)
                MessageBox.Show("Inicio de arquivo encontrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                bs_disciplinas.MovePrevious();
            igualar_text();
        }

        private void btnProx_Click(object sender, EventArgs e)
        {
            if (bs_disciplinas.Count == bs_disciplinas.Position + 1)
                MessageBox.Show("Fim de arquivo encontrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                bs_disciplinas.MoveNext();
            igualar_text();
        }

        private void btnUlt_Click(object sender, EventArgs e)
        {
            bs_disciplinas.MoveLast();
            igualar_text();
        }

        private void limpar()
        {
            lblDisc.Text = "";
            txtDesc.Clear();
            txtSigla.Clear();
            txtSerie.Clear();
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
            txtDesc.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _query = "delete from Disciplinas where cod_disciplina like '" + lblDisc.Text + "'";
            try
            {
                OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                _dataCommand.ExecuteNonQuery();
                carregar_grid();
                MessageBox.Show("Excluido com sucesso !!!!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Problemas com a Exclusão  !!!!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

         private bool valida()
        {
            bool erro = true;
            if (txtDesc.Text == "")
            {
                MessageBox.Show("Descrição inválida. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDesc.Focus();
            }

            else if (txtSigla.Text == "")
            {
                MessageBox.Show("Sigla inválida. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSigla.Focus();
            }

            else if (txtSerie.Text == "")
            {
                MessageBox.Show("Série inválida. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSerie.Focus();
            }

            else
            {
                erro = false;
            }
            return erro;
        }

         private void btnAlterar_Click(object sender, EventArgs e)
         {
             bool teste;
             teste = valida();
             if (teste == false)
             {
                 _query = "Update Disciplinas set descricao ='" + txtDesc.Text + "',";
                 _query += "sigla = '" + txtSigla.Text + "',";
                 _query += "série = '" + txtSerie.Text + "'";
                 _query += "where cod_disciplina like '" + lblDisc.Text + "'";

                 try
                 {
                     OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                     _dataCommand.ExecuteNonQuery();
                     carregar_grid();
                     MessageBox.Show("Alterado com sucesso !!!!", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 }
                 catch (Exception)
                 {
                     MessageBox.Show("Problemas com a Alteração  !!!!", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
         }

         private void btnIncluir_Click(object sender, EventArgs e)
         {
             bool teste;
             teste = valida();
             if (teste == false)
             {
                 _query = "Insert into Disciplinas (descricao, sigla, série) Values ";
                 _query += "('" + txtDesc.Text + "','" + txtSigla.Text + "','" + txtSerie.Text + "')";

                 try
                 {
                     OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                     _dataCommand.ExecuteNonQuery();
                     carregar_grid();
                     MessageBox.Show("Incluido com sucesso !!!!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 }
                 catch (Exception)
                 {
                     MessageBox.Show("Problemas com a Inclusão  !!!!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
         }

         private void txtPesquisar_TextChanged(object sender, EventArgs e)
         {
             _query = "Select * from Disciplinas where descricao like '" + txtPesquisar.Text + "%'";
             OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
             dr_disciplinas = _dataCommand.ExecuteReader();

             if (dr_disciplinas.HasRows == true)
             {
                 bs_disciplinas.DataSource = dr_disciplinas;
             }
             else
             {
                 MessageBox.Show("Não temos disciplina cadastrada com este nome !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtPesquisar.Text = "";
             }
         }

        

        
       
    }
}
