using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GYM_Project
{
    public partial class Rechercher : Form
    {
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYM; Integrated Security = True");
        
        public Rechercher()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                if (comboBox1.SelectedIndex == 0)
                {

                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmd = new SqlCommand("Recherche_M", con);
                    cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dataGridView1.DataSource = dt;
                }
                if (comboBox1.SelectedIndex == 1)
                {

                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    DataTable dt = new DataTable();

                    SqlCommand cmd = new SqlCommand("Recherche_E", con);
                    cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    con.Close();
                    dataGridView1.DataSource = dt;
                }
                if (comboBox1.SelectedIndex == 2)
                {

                    int id;
                    if (int.TryParse(textBox1.Text, out id))
                    {
                        if (con.State == ConnectionState.Open) con.Close();
                        con.Open();
                        DataTable dt = new DataTable();

                        SqlCommand cmd = new SqlCommand("Recherche_P", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sdr = cmd.ExecuteReader();
                        dt.Load(sdr);
                        con.Close();
                        dataGridView1.DataSource = dt;

                    }
                    else dataGridView1.DataSource = null;
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    int id;
                    if (int.TryParse(textBox1.Text, out id))
                    {

                        if (con.State == ConnectionState.Open) con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("Recherche_A", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sdr = cmd.ExecuteReader();
                        dt.Load(sdr);
                        con.Close();
                        dataGridView1.DataSource = dt;

                    }
                    else dataGridView1.DataSource = null;

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
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
