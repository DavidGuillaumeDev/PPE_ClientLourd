using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Pass { get; set; }
        public int Niveau { get; set; }


        public void UpdateUtilisateur(int TypeCo)
        {
            try
            {
                DBConnection dbCon = DBConnection.Connect(TypeCo); 
                if (dbCon.IsConnect())
                {
                    String sqlString = "UPDATE utilisateur SET nom = ?nom_P,niveau = ?niveau_P WHERE id = ?id_P";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    sqlString = Tools.PrepareLigne(sqlString, "?nom_P", Tools.PrepareChamp(Nom, "Chaine"));
                    sqlString = Tools.PrepareLigne(sqlString, "?niveau_P", Tools.PrepareChamp(Niveau.ToString(), "Chaine"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    dbCon.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

        public bool Supprimer(int TypeCo)
        {
            try
            {
                DBConnection dbCon = DBConnection.Connect(TypeCo); 
                if (dbCon.IsConnect())
                {
                    String sqlString = "DELETE FROM utilisateur  WHERE id = ?id_P";
                    sqlString = Tools.PrepareLigne(sqlString, "?id_P", Tools.PrepareChamp(Id.ToString(), "Nombre"));
                    var cmd = new MySqlCommand(sqlString, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }
    }
}
