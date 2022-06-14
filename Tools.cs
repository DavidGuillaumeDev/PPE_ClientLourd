using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace PPE_Salons
{
    public static class Tools
    {
       

        public static String PrepareChamp( String LaValeur,String LeType)
        {
            string ValeurPreparee = "";
            switch (LeType)
            {
                case "Chaine":
                    ValeurPreparee = "'" + LaValeur + "'";
                    break;

                case "Nombre":
                    ValeurPreparee =  LaValeur;
                    break;
            }
            return ValeurPreparee;
}

        public static String PrepareLigne(String LaLigne,String LeMotCle,String LaValeur)
        {
            string LignePreparee = "";
            LignePreparee = LaLigne.Replace(LeMotCle, LaValeur);
            return LignePreparee;
        }

   
    }
}
