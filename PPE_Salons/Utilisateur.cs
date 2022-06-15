using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace PPE_Salons
{
    class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Niveau { get; set; }

        public bool Supprimer()
        {
            try
            {
                DBConnection dbCon = new DBConnection();
                dbCon.Server = "127.0.0.1";
                dbCon.DatabaseName = "ppe_client_lourd";
                dbCon.UserName = "root";
                dbCon.Password = "";//Crypto.Decrypt("MGgAtv/61oXwMgJN47ilHg==");//Pour éviter d'afficher le mot de passe en clair dans le code
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
