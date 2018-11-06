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
    public partial class ConsAnaDisc : Form
    {
        OleDbConnection conn = Conexao.obterConexao();

        OleDbDataReader dr_disc;
        BindingSource bs_disc = new BindingSource();

        OleDbDataReader dr_reg_notas;
        BindingSource bs_reg_notas = new BindingSource();

        String _query;

        int flag = 0;

        public ConsAnaDisc()
        {
            InitializeComponent();
        }

        private void carregar_disc()
        {
            _query = "SELECT * from Disciplinas order by sigla";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_disc = _dataCommand.ExecuteReader();

            if (dr_disc.HasRows == true)
            {
                bs_disc.DataSource = dr_disc;
                cbEscolha.DataSource = bs_disc;
                cbEscolha.DisplayMember = "sigla";
                cbEscolha.ValueMember = "Descricao";
                lblSigla.Text = cbEscolha.SelectedValue.ToString();
            }

            else
            {
                MessageBox.Show("Não temos Disciplinas Cadastradas !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void carregar_grid()
        {
            _query = "SELECT Alunos.Nome, Disciplinas.sigla, Disciplinas.descricao, Registro_Mencoes.mencao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina ORDER BY Alunos.Nome";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_reg_notas = _dataCommand.ExecuteReader();
            if (dr_reg_notas.HasRows == true)
            {
                bs_reg_notas.DataSource = dr_reg_notas;
                dgvDisc.DataSource = bs_reg_notas;

            }
            else
            {
                MessageBox.Show("Não temos essa disciplina!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void ConsAnaDisc_Load(object sender, EventArgs e)
        {
            carregar_grid();
            carregar_disc();
            flag = 1;

        }

        private void cbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSigla.Text = cbEscolha.SelectedValue.ToString();

            if (flag == 1)
            {
                lblSigla.Text = cbEscolha.SelectedValue.ToString();

                _query = "SELECT Alunos.Nome, Disciplinas.sigla, Disciplinas.descricao, Registro_Mencoes.mencao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina WHERE Disciplinas.descricao = '" + lblSigla.Text + "' ORDER BY Alunos.Nome";
                OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                dr_reg_notas = _dataCommand.ExecuteReader();
                if (dr_reg_notas.HasRows == true)
                {
                    bs_reg_notas.DataSource = dr_reg_notas;
                    dgvDisc.DataSource = bs_reg_notas;

                }
                else
                {
                    MessageBox.Show("Não temos esse registro!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
    }
}
