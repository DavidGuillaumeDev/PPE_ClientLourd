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
    public partial class PageUtilisateur : Form
    {
        Utilisateur LUtilisateur;

        public int TypeCo;
        public PageUtilisateur(Utilisateur unUtilisateur, int LeTypeCo)
        {
            InitializeComponent();
            LoadLvl(unUtilisateur);
            LUtilisateur = unUtilisateur;
            tbNom.Text = unUtilisateur.Nom;
            comboBoxNiveau.SelectedItem = unUtilisateur.Niveau;
            TypeCo = LeTypeCo;
        }

        private void Enregistrer_Click(object sender, EventArgs e)
        {
            ComboValue MaComboValue = (ComboValue)comboBoxNiveau.SelectedItem;
            int LevelUser = int.Parse(MaComboValue.Value);
            LUtilisateur.UpdateUtilisateur(TypeCo);
        }

        private void LoadLvl(Utilisateur UnUtilisateur)
        {
            var ComboLevelSource = new List<ComboValue>();
            if (UnUtilisateur.Niveau == 0)
            {
                ComboLevelSource.Add(new ComboValue() { Name = "Utilisateur", Value = "0" });
                ComboLevelSource.Add(new ComboValue() { Name = "Admin", Value = "1" });
            }
            else
            {
                ComboLevelSource.Add(new ComboValue() { Name = "Admin", Value = "1" });
                ComboLevelSource.Add(new ComboValue() { Name = "Utilisateur", Value = "0" });
            }
            comboBoxNiveau.DataSource = ComboLevelSource;
            comboBoxNiveau.DisplayMember = "Name";
            comboBoxNiveau.ValueMember = "Value";
        }

        private void Prenom_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
