using System;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Demarrage_PPE
{
    class Program
    {
        static void Main(string[] args)
        {
            int choixUser = 0;
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
                return;
            }

            DBConnection dbCon = new DBConnection();
            dbCon.Server = "127.0.0.1";
            dbCon.DatabaseName = "sucrerie";
            dbCon.UserName = "root";
            dbCon.Password = "";

            if (dbCon.IsConnect())
            {
                //Parcours Classique d'un curseur, adressage des colonnes par leur position ordinale dans la requête
                string query = "select code_c, nom, adresse, ville from client;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var TheReader = cmd.ExecuteReader();//Remplissage du curseur
                Console.WriteLine("--------------------Parcours Classique du reader------------------");
                while (TheReader.Read()) //On affiche le contenu de chaque ligne
                {
                    string someStringFromColumnZero = TheReader.GetString(0);
                    string someStringFromColumnOne = TheReader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                TheReader.Close();

                do
                {
                    choixUser = Interface.MenuPrincipal();
                    Interface.TraiterChoix(choixUser, dbCon, TheReader);
                } while (choixUser != 3);
            }
        }
    }
}
