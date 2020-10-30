using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_Project
{
    public partial class Form1 : Form
    {
        public static string lst = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new Member().Show();
            this.Hide();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            new Equipement().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new Paiement().Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Achat().Show();
            this.Hide();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new Rechercher().Show();
            this.Hide();
        }

        private void memberRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lst = "Membre";
            new Consultation().Show();
            this.Hide();

        }

        private void purchaseRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lst = "Equipement";
            new Consultation().Show();
            this.Hide();
        }

        private void feesRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lst = "Paiement";
            new Consultation().Show();
            this.Hide();
        }

        private void expenseRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lst = "Achats";
            new Consultation().Show();
            this.Hide();
        }
    }
}
