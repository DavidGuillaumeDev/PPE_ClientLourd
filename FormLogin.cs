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
    public partial class FormLogin : Form
    {
        public string StrLevel;
        public string NomUtilisateur;
        public string Password;

        public object labelResponse { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                dbCon.Server = "127.0.0.1";
                dbCon.DatabaseName = "ppesalons";
                dbCon.UserName = "root";
                dbCon.Password = "";//Pour éviter d'afficher le mot de passe en clair dans le code
                int Identifiant = -1;
                if (dbCon.IsConnect())
                {
                    String sqlString = "ChercherUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = textBoxName.Text;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = textBoxPassword.Text;

                    cmd.Parameters.Add("@IdSortie", MySqlDbType.Int32);
                    cmd.Parameters["@IdSortie"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    Identifiant = (int)cmd.Parameters["@IdSortie"].Value;
                    /*
                    this.StrLevel = "";
                    this.NomUtilisateur = textBoxName.Text;
                    this.Password = textBoxPassword.Text;
                    */
                    if (Identifiant > 0)
                    {
                        //labelResponse.Text = "Bienvenue";
                        this.DialogResult = DialogResult.OK;//Modale est validée par OK
                    }
                    else //labelResponse.Text = "Je ne vous connais pas";
                    dbCon.Close();


                }
                dbCon.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erreur");
            }
        }
    }
}
