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
        public int Identifiant = -1;
        public int Level = 0;
        public int TypeCo;
        public FormLogin()
        {
            InitializeComponent();
            DefineCo_Load();
        }

        private void DefineCo_Load()
        {
            var ComboLevelSource = new List<ComboValue>();
            ComboLevelSource.Add(new ComboValue() { Name = "Locale", Value = "0" });
            ComboLevelSource.Add(new ComboValue() { Name = "Distante", Value = "1" });
            comboBoxTypeCo.DataSource = ComboLevelSource;
            comboBoxTypeCo.DisplayMember = "Name";
            comboBoxTypeCo.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComboValue MaComboValue = (ComboValue)comboBoxTypeCo.SelectedItem;
            TypeCo = int.Parse(MaComboValue.Value);
            DBConnection dbCon = DBConnection.Connect(TypeCo);
            try
            {
                if (dbCon.IsConnect())
                {
                    String sqlString = "ChercherUtilisateur";
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.CommandType = CommandType.StoredProcedure; //Il faut System.Data pour cette ligne

                    cmd.Parameters.Add("@NomEntree", MySqlDbType.VarChar);
                    cmd.Parameters["@NomEntree"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@NomEntree"].Value = textBoxLogin.Text;
                    cmd.Parameters.Add("@LePass", MySqlDbType.Text);
                    cmd.Parameters["@LePass"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@LePass"].Value = SHA.GenerateSHA1String(textBoxMdp.Text);

                    cmd.Parameters.Add("@IdSortie", MySqlDbType.Int32);
                    cmd.Parameters["@IdSortie"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@LevelSortie", MySqlDbType.Int32);
                    cmd.Parameters["@LevelSortie"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    Identifiant = (int)cmd.Parameters["@IdSortie"].Value;
                    if (Identifiant > 0)
                    {
                        Level = (int)cmd.Parameters["@LevelSortie"].Value;
                        labelResponse.Text = "Bienvenue";
                        this.DialogResult = DialogResult.OK;//Modale est validée par OK
                    }
                    else labelResponse.Text = "Identifiant et/ou mot de passe incorrect";
                    dbCon.Close();
                }
                dbCon.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Erreur");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;//Modale est Annulée OK 
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
