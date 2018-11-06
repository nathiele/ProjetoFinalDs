using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prj_escola
{
    public partial class frmControle : Form
    {
        public frmControle()
        {
            InitializeComponent();
        }


        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlunos frmAlu = new frmAlunos();
            frmAlu.MdiParent = this;
            frmAlu.Show();
        }

        private void frmControle_Load(object sender, EventArgs e)
        {
            lblData.Text = "Data :" + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora :" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmDisc frmDisc = new frmDisc();
            frmDisc.MdiParent = this;
            frmDisc.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAlunos frmAlu = new frmAlunos();
            frmAlu.MdiParent = this;
            frmAlu.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmDisc frmDisc = new frmDisc();
            frmDisc.MdiParent = this;
            frmDisc.Show();
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsCadDisc frmCons = new FrmConsCadDisc();
            frmCons.MdiParent = this;
            frmCons.Show();
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsCadAlu frmCons = new FormConsCadAlu();
            frmCons.MdiParent = this;
            frmCons.Show();
        }

        private void registrarMençõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegMen frmReg = new frmRegMen();
            frmReg.MdiParent = this;
            frmReg.Show();
        }

        private void consultatoolStripButton3_Click(object sender, EventArgs e)
        {
            FormConsCadAlu frmCons = new FormConsCadAlu();
            frmCons.MdiParent = this;
            frmCons.Show();
        }

        private void registrotoolStripButton4_Click(object sender, EventArgs e)
        {
            frmRegMen frmReg = new frmRegMen();
            frmReg.MdiParent = this;
            frmReg.Show();
        }

        private void alunosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelCadAlu RelAlu = new RelCadAlu();
            RelAlu.MdiParent = this;
            RelAlu.Show();
        }

        private void disciplinasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelCadDisciplina RelDisc = new RelCadDisciplina();
            RelDisc.MdiParent = this;
            RelDisc.Show();
        }

        
        private void MenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelAnaMen RelMen = new RelAnaMen();
            RelMen.MdiParent = this;
            RelMen.Show();
        }

        private void DiscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelAnaDisc RelDisc = new RelAnaDisc();
            RelDisc.MdiParent = this;
            RelDisc.Show();
        }

        private void BolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boletim bol = new Boletim();
            bol.MdiParent = this;
            bol.Show();
        }

        private void AluUmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsAnaAlu alu = new ConsAnaAlu();
            alu.MdiParent = this;
            alu.Show();
        }

        private void DiscDoisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsAnaDisc disc = new ConsAnaDisc();
            disc.MdiParent = this;
            disc.Show();
        }

        private void MenTrêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsAnaMen men = new ConsAnaMen();
            men.MdiParent = this;
            men.Show();
        }

       

      

        


       
    }
}
