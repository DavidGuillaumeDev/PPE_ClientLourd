using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Demarrage_PPE
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Email { get; set; }

        public Participant()
        {
            Nom = Nom;
            Prenom = Prenom;
            Email = Email;
        }

        public String getParticipant()
        {
            return Nom.ToUpper() + "\n" + Prenom + "\n" + Email;
        }

        public void Save(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            if (ParticipantID > 0)
                UpdateParticipant(DataBaseConnection, TheReader);
            else
                AddParticipant(DataBaseConnection, TheReader);
        }

        public void Delete(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            try
            {
                String sqlString = "DELETE FROM participant WHERE Id = ParticipantID";
                sqlString = Tools.PrepareLigne(sqlString, "ParticipantID", Tools.PrepareChamp(ParticipantID.ToString(), "Nombre"));
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
            int NewId = 0;
            try
            {
                String sqlString = "SELECT MAX(Id) FROM participant;";
                var cmd = new MySqlCommand(sqlString, DataBaseConnection.Connection);
                TheReader = cmd.ExecuteReader();

                while (TheReader.Read())
                { NewId = TheReader.GetInt32(0); }
                TheReader.Close();
                NewId++;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write("Erreur N° " + ex.Number + " : " + ex.Message);
            }
            return NewId;
        }

        private void AddParticipant(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            try
            {
                ParticipantID = GiveNewID(DataBaseConnection, TheReader);
                String sqlString = "INSERT INTO participant(Nom,Prenom,Email) VALUES(?Nom,?Prenom,?Email)";
                sqlString = Tools.PrepareLigne(sqlString, "?Nom", Tools.PrepareChamp(Nom, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?Prenom", Tools.PrepareChamp(Prenom, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?Email", Tools.PrepareChamp(Email, "Chaine"));
                var cmd = new MySqlCommand(sqlString, DataBaseConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write("Erreur N° " + ex.Number + " : " + ex.Message);
            }

        }

        private void UpdateParticipant(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            try
            {
                String sqlString = "UPDATE participant SET Nom = ?Nom,Prenom = ?Prenom,Email = ?Email WHERE Id = ParticipantID";
                sqlString = Tools.PrepareLigne(sqlString, "?Nom", Tools.PrepareChamp(Nom, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?Prenom", Tools.PrepareChamp(Prenom, "Chaine"));
                sqlString = Tools.PrepareLigne(sqlString, "?Email", Tools.PrepareChamp(Email, "Chaine"));
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
