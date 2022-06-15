using System;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace PPE_Salons
{
    public  class DBConnection
    {


        public DBConnection()
        {
        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }

        public static DBConnection Connect(int isLocal)
        {
            DBConnection dbCon = new DBConnection();
            if (isLocal == 0)
            {
                dbCon.Server = "127.0.0.1";
                dbCon.DatabaseName = "ppe_client_lourd";
                dbCon.UserName = "root";
                dbCon.Password = "";
            }
            else
            {
                dbCon.Server = "ppebelletablecerfal.chaisgxhr4z6.eu-west-3.rds.amazonaws.com";
                dbCon.DatabaseName = "PPE_Guillaume";
                dbCon.UserName = "admin";
                dbCon.Password = Crypto.Decrypt("tr9y0URXywxHt1XgTEn4yg==");//Pour éviter d'afficher le mot de passe en clair dans le code
            }
            return dbCon;
        }

        
        public void Close()
        {
            Connection.Close();
        }
    }
}
