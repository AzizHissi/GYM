using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_Project
{
    public partial class Consultation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GYM;Integrated Security=True");
        public Consultation()
        {
            InitializeComponent();
        }

        private void Consultation_Load(object sender, EventArgs e)
        {
            try
            {
                if (Form1.lst == "Membre")
                {
                    SqlCommand cmd = new SqlCommand("Select * from Membre", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dataGridView1.DataSource = dt;
                    label1.Text = "Liste Des Membres";

                }
                else if (Form1.lst == "Equipement")
                {
                    SqlCommand cmd = new SqlCommand("Select * from Equipement", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dataGridView1.DataSource = dt;
                    label1.Text = "Liste Des Equipements";
                }
                else if (Form1.lst == "Paiement")
                {
                    SqlCommand cmd = new SqlCommand("Select * from Paiement", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dataGridView1.DataSource = dt;
                    label1.Text = "Liste Des Paiements";

                }
                else if (Form1.lst == "Achats")
                {
                    SqlCommand cmd = new SqlCommand("Select * from Achat", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dataGridView1.DataSource = dt;
                    label1.Text = "Liste Des Achats";
                }

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
    }
}
