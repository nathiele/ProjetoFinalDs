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
    public partial class ConsAnaMen : Form
    {
        OleDbConnection conn = Conexao.obterConexao();

        OleDbDataReader dr_menc;
        BindingSource bs_menc = new BindingSource();

        OleDbDataReader dr_reg_notas;
        BindingSource bs_reg_notas = new BindingSource();

        String _query;
        int flag = 0;

        public ConsAnaMen()
        {
            InitializeComponent();
        }

        private void carregar_mencao()
        {
            _query = "SELECT * from Mencao order by mencao";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_menc = _dataCommand.ExecuteReader();

            if (dr_menc.HasRows == true)
            {
                bs_menc.DataSource = dr_menc;
                cbEscolha.DataSource = bs_menc;
                cbEscolha.DisplayMember = "Mencao";
                cbEscolha.ValueMember = "Mencao";
            }

            else
            {
                MessageBox.Show("Não temos Menções Cadastradas !!!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                dgvMen.DataSource = bs_reg_notas;

            }
            else
            {
                MessageBox.Show("Não temos essa menção!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ConsAnaMen_Load(object sender, EventArgs e)
        {
            carregar_grid();
            carregar_mencao();
            flag = 1;

        }

        private void cbEscolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                _query = "SELECT Alunos.Nome, Disciplinas.sigla, Disciplinas.descricao, Registro_Mencoes.mencao FROM Disciplinas INNER JOIN (Alunos INNER JOIN Registro_Mencoes ON Alunos.Matricula = Registro_Mencoes.matricula) ON Disciplinas.cod_disciplina = Registro_Mencoes.cod_disciplina WHERE Registro_Mencoes.mencao = '" + cbEscolha.SelectedValue.ToString() + "' ORDER BY Alunos.Nome";
                OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
                dr_reg_notas = _dataCommand.ExecuteReader();
                if (dr_reg_notas.HasRows == true)
                {
                    bs_reg_notas.DataSource = dr_reg_notas;
                    dgvMen.DataSource = bs_reg_notas;

                }
                else
                {
                    MessageBox.Show("Não temos esse registro!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
    }
}
