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
    public partial class frmRegMen : Form
    {
        OleDbConnection conn = Conexao.obterConexao();
        OleDbDataReader dr_alu;
        BindingSource bs_alu = new BindingSource();
        OleDbDataReader dr_disc;
        BindingSource bs_disc = new BindingSource();
        OleDbDataReader dr_menc;
        BindingSource bs_menc = new BindingSource();
        OleDbDataReader dr_reg_notas;
        BindingSource bs_reg_notas = new BindingSource();
        String _query;


        public frmRegMen()
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
                cbAluno.DataSource = bs_alu;
                cbAluno.DisplayMember = "Nome";
                cbAluno.ValueMember = "Matricula";
                lblMat.Text = cbAluno.SelectedValue.ToString();

            }
            else
            {
                MessageBox.Show("Não temos alunos cadastrados!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void carregar_disciplina()
        {
            _query = "SELECT * from Disciplinas order by descricao";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_disc = _dataCommand.ExecuteReader();

            if (dr_disc.HasRows == true)
            {
                bs_disc.DataSource = dr_disc;
                cbDisc.DataSource = bs_disc;
                cbDisc.DisplayMember = "sigla";
                cbDisc.ValueMember = "cod_disciplina";
                lblCod.Text = cbDisc.SelectedValue.ToString();

            }
            else
            {
                MessageBox.Show("Não temos disciplinas cadastradas!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void carregar_mencao()
        {
            _query = "SELECT * from Mencao order by Mencao";
            OleDbCommand _dataCommand = new OleDbCommand(_query, conn);
            dr_menc = _dataCommand.ExecuteReader();

            if (dr_menc.HasRows == true)
            {
                bs_menc.DataSource = dr_menc;
                cbMencao.DataSource = bs_menc;
                cbMencao.DisplayMember = "Mencao";

            }
            else
            {
                MessageBox.Show("Não temos essa menção!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                dgvMencao.DataSource = bs_reg_notas;
              
            }
            else
            {
                MessageBox.Show("Não temos esse registro!!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
          
           
                _query = "Insert into Registro_Mencoes (matricula, cod_disciplina, mencao) Values ";
                _query += "('" + lblMat.Text + "','" + lblCod.Text + "','" + cbMencao.Text + "')";

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

        private void frmRegMen_Load(object sender, EventArgs e)
        {
            carregar_aluno();
            carregar_disciplina();
            carregar_grid();
            carregar_mencao();
        }

        private void cbAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMat.Text = cbAluno.SelectedValue.ToString();
        }

        private void cbDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCod.Text = cbDisc.SelectedValue.ToString();
        }

        

       
    }
}
