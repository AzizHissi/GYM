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
    public partial class Liste_Equipement : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GYM;Integrated Security=True");
        public Liste_Equipement()
        {
            InitializeComponent();
        }

        private void Liste_Equipement_Load(object sender, EventArgs e)
        {
            List_Equipement();
        }
        private void List_Equipement()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();

                SqlCommand cmd = new SqlCommand("liste_eqi", con);
                DataTable dt = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                dataGridView2.DataSource = dt;

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            if(con.State==ConnectionState.Open) con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("Recherche", con);
            
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            
            
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridView2.DataSource = dt;
        }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }

}

        private void button7_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
    }
}
