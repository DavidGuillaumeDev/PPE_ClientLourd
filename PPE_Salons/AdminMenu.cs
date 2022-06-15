using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_Salons
{
    public partial class AdminMenu : Form
    {
        public int TypeCo;
        public AdminMenu(int LeTypeCo)
        {
            TypeCo = LeTypeCo;
            InitializeComponent();
            loadListeParticipants();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser adminPage = new AddUser(TypeCo);
            adminPage.ShowDialog();
        }

        private void loadListeParticipants()
        {
            DBConnection dbCon = DBConnection.Connect(TypeCo); 
            if (dbCon.IsConnect())
            {
                string query = "SELECT id, nom, niveau FROM utilisateur ORDER BY id";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();//Remplissage du curseur
                List<Utilisateur> users = new List<Utilisateur>();
                while (reader.Read())
                {
                    Utilisateur user = new Utilisateur
                    {
                        Id = (int)reader["id"],
                        Nom = (string)reader["nom"],
                        Niveau = (int)reader["niveau"],
                    };
                    users.Add(user);
                }

                MaGrid.DataSource = null;
                MaGrid.DataSource = users;
                FormaterListe();
                reader.Close();
                dbCon.Close();
                MaGrid.Visible = true;

            }
        }

        private void FormaterListe()
        {
            MaGrid.Columns["Nom"].HeaderText = "Nom d'utilisateur";
            MaGrid.Columns["Pass"].Visible = false;
            MaGrid.MultiSelect = false;
            MaGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MaGrid.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Utilisateur UnParticipant = row.DataBoundItem as Utilisateur;
                if (UnParticipant.Supprimer(TypeCo))
                    MessageBox.Show("Utilisateur Supprimé !");
                // Ici on rafraîchit la liste....
                else
                    MessageBox.Show("Impossible de  Supprimer !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Utilisateur UnUtilisateur = row.DataBoundItem as Utilisateur;
                PageUtilisateur MonFormParticipant = new PageUtilisateur(UnUtilisateur, TypeCo);
                MonFormParticipant.Show();
            }
        }
    }
}
