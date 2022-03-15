using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demarrage_PPE
{
    public class Client
    {
        public int ContactID { get; set; }
        public String ContactNom { get; set; }
        public String ContactAdresse { get; set; }
        public String ContactVille { get; set; }

        public void Save(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            if (ContactID > 0)
                UpdateContact(DataBaseConnection, TheReader);
            else
                AddContact(DataBaseConnection, TheReader);
        }

        public void Delete(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            try
            {
                String sqlString = "DELETE FROM client WHERE code_c = ?code_c";
                sqlString = Tools.PrepareLigne(sqlString, "?code_c", Tools.PrepareChamp(ContactID.ToString(), "Nombre"));
                var cmd = new MySqlCommand(sqlString, DataBaseConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write("Erreur N° " + ex.Number + " : " + ex.Message);
            }
        }

        private int GiveNewID(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            int NewCode_c = 0;
            try
            {
                String sqlString = "SELECT MAX(code_c) FROM client;";
                var cmd = new MySqlCommand(sqlString, DataBaseConnection.Connection);
                TheReader = cmd.ExecuteReader();

                while (TheReader.Read())
                { NewCode_c = TheReader.GetInt32(0); }
                TheReader.Close();
                NewCode_c++;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write("Erreur N° " + ex.Number + " : " + ex.Message);
            }
            return NewCode_c;
        }

        private void AddContact(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            try
            {
                ContactID = GiveNewID(DataBaseConnection, TheReader);
                String sqlString = "INSERT INTO client(code_c,nom,adresse,ville) VALUES(?code_c,?nom,?adresse,?ville)";
                sqlString = Tools.PrepareLigne(sqlString, "?code_c", Tools.PrepareChamp(ContactID.ToString(), "Nombre"));
                sqlString = Tools.PrepareLigne(sqlString, "?nom", Tools.PrepareChamp(ContactNom, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?adresse", Tools.PrepareChamp(ContactAdresse, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?ville", Tools.PrepareChamp(ContactVille, "Chaine"));
                var cmd = new MySqlCommand(sqlString, DataBaseConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write("Erreur N° " + ex.Number + " : " + ex.Message);
            }

        }

        private void UpdateContact(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            try
            {
                String sqlString = "UPDATE client SET nom = ?nom,ville = ?ville,adresse = ?adresse WHERE code_c = ?code_c";
                sqlString = Tools.PrepareLigne(sqlString, "?code_c", Tools.PrepareChamp(ContactID.ToString(), "Nombre"));
                sqlString = Tools.PrepareLigne(sqlString, "?nom", Tools.PrepareChamp(ContactNom, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?adresse", Tools.PrepareChamp(ContactAdresse, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?ville", Tools.PrepareChamp(ContactVille, "Chaine"));
                var cmd = new MySqlCommand(sqlString, DataBaseConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write("Erreur N° " + ex.Number + " : " + ex.Message);
            }
        }
    }
}
