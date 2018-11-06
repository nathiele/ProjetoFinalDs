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
    public partial class frmAlunos : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_alunos;
        BindingSource bs_alunos = new BindingSource();
        String _query;

        public frmAlunos()
        {
            InitializeComponent();
        }

        private void frmAlunos_FormClosing(object sender, FormClosingEventArgs e)
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
            dr_alunos = _dataCommand.ExecuteReader();
            if (dr_alunos.HasRows == true)
            {
                bs_alunos.DataSource = dr_alunos;
                dgvAluno.DataSource = bs_alunos;
                igualar_text();
            }
            else
            {
                MessageBox.Show("Não temos Alunos cadastrados !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void igualar_text()
        {
            lblMat.DataBindings.Add("Text", bs_alunos, "Matricula");
            lblMat.DataBindings.Clear();
            txtNome.DataBindings.Add("Text", bs_alunos, "Nome");
            txtNome.DataBindings.Clear();
            txtEnd.DataBindings.Add("Text", bs_alunos, "Endereco");
            txtEnd.DataBindings.Clear();
            txtNum.DataBindings.Add("Text", bs_alunos, "numero");
            txtNum.DataBindings.Clear();
            txtBairro.DataBindings.Add("Text", bs_alunos, "bairro");
            txtBairro.DataBindings.Clear();
            txtCid.DataBindings.Add("Text", bs_alunos, "cidade");
            txtCid.DataBindings.Clear();
            txtCpf.DataBindings.Add("Text", bs_alunos, "cpf");
            txtCpf.DataBindings.Clear();
            cbSexo.DataBindings.Add("Text", bs_alunos, "sexo");
            cbSexo.DataBindings.Clear();
            mskRg.DataBindings.Add("Text", bs_alunos, "RG");
            mskRg.DataBindings.Clear();
            mskTel.DataBindings.Add("Text", bs_alunos, "telefone");
            mskTel.DataBindings.Clear();
            mskCep.DataBindings.Add("Text", bs_alunos, "cep");
            mskCep.DataBindings.Clear();
            dtmNasc.DataBindings.Add("Text", bs_alunos, "Nasc");
            dtmNasc.DataBindings.Clear();
        }

        private void frmAlunos_Load(object sender, EventArgs e)
        {
            carregar_grid();
        }

        private void dgvAluno_Click(object sender, EventArgs e)
        {
            igualar_text();
        }

        private void dgvAluno_KeyUp(object sender, KeyEventArgs e)
        {
            igualar_text();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            _query = "Select * from Alunos where nome like '" + txtPesquisar.Text + "%'";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_alunos = _dataCommand.ExecuteReader();

            if (dr_alunos.HasRows == true)
            {
                bs_alunos.DataSource = dr_alunos;
            }
            else
            {
                MessageBox.Show("Não temos aluno cadastrado com este nome !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPesquisar.Text = "";
            }

        }

        private void btnPrim_Click(object sender, EventArgs e)
        {
            bs_alunos.MoveFirst();
            igualar_text();
        }

        private void btnAnt_Click(object sender, EventArgs e)
        {

            if (bs_alunos.Position == 0)
                MessageBox.Show("Inicio de arquivo encontrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                bs_alunos.MovePrevious();
            igualar_text();

        }

        private void btnProx_Click(object sender, EventArgs e)
        {
            if (bs_alunos.Count == bs_alunos.Position + 1)
                MessageBox.Show("Fim de arquivo encontrado !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                bs_alunos.MoveNext();
            igualar_text();    

        }

        private void btnUlt_Click(object sender, EventArgs e)
        {
            bs_alunos.MoveLast();
            igualar_text();
        }

        private void limpar()
        {
            lblMat.Text = "";
            txtNome.Clear();
            txtEnd.Clear();
            txtNum.Clear();
            txtBairro.Clear();
            txtCid.Clear();
            txtCpf.Clear();
            mskCep.Clear();
            mskRg.Clear();
            mskTel.Clear();
            cbSexo.SelectedIndex= 0;
            dtmNasc.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
            txtNome.Focus();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _query = "delete from Alunos where matricula like '" + lblMat.Text + "'";
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
            if (txtNome.Text == "")
            {
                MessageBox.Show("Nome inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
            }

            else if (txtEnd.Text == "")
            {
                MessageBox.Show("Endereço inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEnd.Focus();
            }

            else if (txtCpf.Text == "")
            {
                MessageBox.Show("Cpf inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpf.Focus();
            }


            else if (txtNum.Text == "")
            {
                MessageBox.Show("Número da residência inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNum.Focus();
            }

            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Bairro inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBairro.Focus();
            }

            else if (txtCid.Text == "")
            {
                MessageBox.Show("Cidade inválida. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCid.Focus();
            }

            else if (mskCep.MaskFull == false)
            {
                MessageBox.Show("Cep inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCep.Focus();
            }

            else if (mskRg.MaskFull == false)
            {
                MessageBox.Show("RG inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskRg.Focus();
            }

            else if (mskTel.MaskFull == false)
            {
                MessageBox.Show("Telefone inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskTel.Focus();
            }

            else if (cbSexo.Text == "")
            {
                MessageBox.Show("Sexo inválido. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbSexo.Focus();
            }

            else if (dtmNasc.Text == "")
            {
                MessageBox.Show("Data de nascimento inválida. Redigite !!", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtmNasc.Focus();
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
                        _query = "Update Alunos set Nome ='" + txtNome.Text + "',";
                        _query += "Nasc = '" + dtmNasc.Text + "',";
                        _query += "cpf = '" + txtCpf.Text + "',";
                        _query += "sexo = '" + cbSexo.SelectedItem + "',";
                        _query += "numero = '" + txtNum.Text + "',";
                        _query += "RG = '" + mskRg.Text + "',";
                        _query += "cep = '" + mskCep.Text + "',";
                        _query += "Endereco = '" + txtEnd.Text + "',";
                        _query += "telefone = '" + mskTel.Text + "',";
                        _query += "bairro = '" + txtBairro.Text + "',";
                        _query += "cidade = '" + txtCid.Text + "'";
                        _query += "where Matricula like '" + lblMat.Text + "'";

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
                        _query = "Insert into Alunos (Nome, Nasc, Endereco, sexo, numero, RG, cpf, bairro, telefone, cidade, cep) Values ";
                        _query += "('" + txtNome.Text + "','" + dtmNasc.Text + "','" + txtEnd.Text + "','" + mskCep.Text + "','" + cbSexo.Text + "','" + txtNum.Text + "','" + mskRg.Text + "','" + txtCpf.Text + "','" + txtBairro.Text + "','" + mskTel.Text + "','" + txtCid.Text + "')";

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


    }
}
