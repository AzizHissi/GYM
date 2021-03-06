﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace GYM_Project
{
    public partial class Achat : Form
    {
        public Achat()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = GYM; Integrated Security = True");
        private int Id;

        private void Suprimer(object sender, EventArgs e)
        {
            try
            {
                if (Id > 0)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Del_Achat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", this.Id);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Supprimé avec succès! , cliquez sur OK pour Proceede", "Supprimé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Charger_Grid();
                    Binding();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une achat parmi la liste ci-dessous pour supprimé", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }



        private void Retour(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vraiment quitter?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new Form1().Show();
            }
          
        }



        private void Ajouter(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("Add_Achat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idm", cb_membre.SelectedValue);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@montant", txtb_montant.Text);
                cmd.Parameters.AddWithValue("@quantite", txt_qnt.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Enregistré avec succès dans la base de données, cliquez sur OK pour continuer", "Enregistré", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Charger_Grid();
                Binding();

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void Paiement_Load(object sender, EventArgs e)
        {
            Charger_Grid();
            Charger_Combo();

        }

        private void Charger_Grid()
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("list_Achat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        private void Charger_Combo()
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("list_equipement", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            cb_membre.DataSource = dt;
            cb_membre.DisplayMember = "id Equipement";
            cb_membre.ValueMember = "id Equipement";
            txt_nom.DataBindings.Add("Text", dt, "Nom Equipement");

        }

        private void Quitter(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }



        private void Modifier(object sender, EventArgs e)
        {
            try
            {
                if (Id >= 0)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Mod_Achat", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@idm", cb_membre.SelectedValue);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@montant", txtb_montant.Text);
                    cmd.Parameters.AddWithValue("@quantite", txt_qnt.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Mise à jour réussie, cliquez sur OK pour Proceede", "Actualisé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Charger_Grid();
                    Binding();

                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une achat parmi la liste ci-dessous pour mettre à jour", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Binding();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
           

        }

        private void Binding()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                cb_membre.SelectedValue = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtb_montant.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            }
            else
            {
                Vider();
            }
        }

        private void Nouveau(object sender, EventArgs e)
        {
            Vider();

        }

        private void Vider()
        {

            dateTimePicker1.ResetText();
            cb_membre.SelectedIndex = 0;
            txtb_montant.Clear();
        }
    }
}
