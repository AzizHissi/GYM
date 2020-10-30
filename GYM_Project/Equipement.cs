using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace GYM_Project
{
    public partial class Equipement : Form
    {
        public Equipement()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYM; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("Add_Equipments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@Muscle", textBox3.Text);
                cmd.Parameters.AddWithValue("@Descr", textBox2.Text);
                cmd.Parameters.AddWithValue("@prix", textBox4.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Enregistré avec succès dans la base de données, cliquez sur OK pour continuer", "Enregistré", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void Retour(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            new Form1().Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Liste_Equipement().Show();
        }
    }
}
