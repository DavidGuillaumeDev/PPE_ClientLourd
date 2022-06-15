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
        public AdminMenu()
        {
            InitializeComponent();
            loadListeParticipants();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser adminPage = new AddUser();
            adminPage.ShowDialog();
        }

        private void loadListeParticipants()
        {
            DBConnection dbCon = new DBConnection();
            dbCon.Server = "127.0.0.1";
            dbCon.DatabaseName = "ppe_client_lourd";
            dbCon.UserName = "root";
            dbCon.Password = "";//Crypto.Decrypt("MGgAtv/61oXwMgJN47ilHg==");//Pour éviter d'afficher le mot de passe en clair dans le code
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
            MaGrid.MultiSelect = false;
            MaGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MaGrid.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MaGrid.SelectedRows)
            {
                Utilisateur UnParticipant = row.DataBoundItem as Utilisateur;
                if (UnParticipant.Supprimer())
                    MessageBox.Show("Participant Supprimé !");
                // Ici on rafraîchit la liste....
                else
                    MessageBox.Show("Impossible de  Supprimer !");
            }
        }
    }
}
