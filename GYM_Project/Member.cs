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
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GYM;Integrated Security=True");
        public int Id;
       

        private bool Isvalid()
        {
            if (textBoxFname.Text == string.Empty )
            {
                MessageBox.Show("Veuillez entrer le nom complet afin de procéder.", "avertissement!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbGENDER.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir le sexe du membre  afin de procéder.", "avertissement!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbGYMTIME.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une heure afin de procéder.", "avertissement!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

       

        private void Member_Load(object sender, EventArgs e)
        {
            try
            {
                getmembersdata();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void getmembersdata()
        {

            SqlCommand cmd = new SqlCommand("Select* from Membre", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView2.DataSource = dt;
        }

        
       
       

        private void Retour(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
        private void Ajouter(object sender, EventArgs e)
        {
            try
            {
                if (Isvalid())
                {

                    SqlCommand cmd = new SqlCommand("Add_Membre", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom", textBoxFname.Text);
                    cmd.Parameters.AddWithValue("@gender", cmbGENDER.Text);
                    cmd.Parameters.AddWithValue("@adress", textBoxADDRESS.Text);
                    cmd.Parameters.AddWithValue("@DateN", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@DateI", dateTimePicker2.Text);
                    cmd.Parameters.AddWithValue("@Heure", cmbGYMTIME.Text);
                    cmd.Parameters.AddWithValue("@Tel", textBoxCONTACT.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Enregistré avec succès dans la base de données, cliquez sur OK pour continuer", "enregistré", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getmembersdata();
                    resetdata();

                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
          
        }

        private void Nouveau(object sender, EventArgs e)
        {
            resetdata();
        }

        private void resetdata()
        {
            textBoxFname.Clear();

            textBoxADDRESS.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            textBoxCONTACT.Clear();
            textBoxFname.Focus();
            cmbGENDER.ResetText();
            cmbGYMTIME.ResetText();

        }

        private void Modifier(object sender, EventArgs e)
        {
            try{
                if (Id > 0)
                {
                    if (MessageBox.Show("Voulez-vous vraiment modifié ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    SqlCommand cmd = new SqlCommand("Mod_Membre", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom", textBoxFname.Text);
                    cmd.Parameters.AddWithValue("@gender", cmbGENDER.Text);
                    cmd.Parameters.AddWithValue("@adress", textBoxADDRESS.Text);
                    cmd.Parameters.AddWithValue("@DateN", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@DateI", dateTimePicker2.Text);
                    cmd.Parameters.AddWithValue("@Heure", cmbGYMTIME.Text);
                    cmd.Parameters.AddWithValue("@Tel", textBoxCONTACT.Text);
                    cmd.Parameters.AddWithValue("@id", this.Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Mise à jour réussie, cliquez sur OK pour Proceede", "Actualisé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getmembersdata();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un membre parmi la liste ci-dessous pour mettre à jour", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                textBoxFname.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                cmbGENDER.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBoxCONTACT.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                textBoxADDRESS.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker2.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
                cmbGYMTIME.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();

            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
           
            
            
        }

        private void Suprimer(object sender, EventArgs e)
        {
            try
            {
                if (Id > 0)
                {
                    if (MessageBox.Show("Voulez-vous vraiment supprimé ?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    SqlCommand cmd = new SqlCommand("Del_Membre", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", this.Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Supprimé avec succès! , cliquez sur OK pour Proceede", "Supprimé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getmembersdata();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un membre parmi la liste ci-dessous pour supprimé", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
            
        }
    }
}