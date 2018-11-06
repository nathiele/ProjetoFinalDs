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
    public partial class ConsAnaAlu : Form
    {
        OleDbConnection conn = Conexao.obterConexao();

        OleDbDataReader dr_alu;
        BindingSource bs_alu = new BindingSource();

        OleDbDataReader dr_reg_notas;
        BindingSource bs_reg_notas = new BindingSource();

        String _query;

        int flag = 0;

        public ConsAnaAlu()
        {
            InitializeComponent();
        }

        private void carregar_aluno()
        {
            _query = "SELECT * from Alunos order by Nome";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_alu = _dataCommand.ExecuteReader();

            if (dr_alu.HasRows == true)
            {
                bs_alu.DataSource = dr_alu;
                cbEscolha.DataSource = bs_alu;
                cbEscolha.DisplayMember = "Nome";
                cbEscolha.ValueMember = "Matricula";
                lblAlu.Text = cbEscolha.SelectedValue.ToString();
            }

            else
            {
                MessageBox.Show("Não temos Alunos Cadastrados !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                dgvAlu.DataSource = bs_reg_notas;

            }
            else
            {
                MessageBox.Show("Não temos esse registro!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ConsAnaAlu_Load(object sender, EventArgs e)
        {
            carregar_grid();
            carregar_aluno();
            flag = 1;

        }

        private void cbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                lblAlu.Text = cbEscolha.SelectedValue.ToString();

                _query = "SELECT Alunos.Nome, Disciplinas.sigla, Disciplinas.descricao, Registro_Mencoes.mencao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina WHERE Alunos.Matricula = " + lblAlu.Text + " ORDER BY Alunos.Nome";
                OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                dr_reg_notas = _dataCommand.ExecuteReader();
                if (dr_reg_notas.HasRows == true)
                {
                    bs_reg_notas.DataSource = dr_reg_notas;
                    dgvAlu.DataSource = bs_reg_notas;

                }
                else
                {
                    MessageBox.Show("Não temos esse aluno!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
    }
}
