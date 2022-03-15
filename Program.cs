using System;
using MySql;
using MySql.Data;

namespace Demarrage_PPE
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(args[0]);
                return;
            }

            DBConnection dbCon = new DBConnection();






            do
            {
                choixUser = Interface.Afficher();
            } while (choixUser >= 3);
        }
    }
}
