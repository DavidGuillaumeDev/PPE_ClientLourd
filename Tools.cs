using System;
using System.Collections.Generic;
using System.Text;

namespace Demarrage_PPE
{
    class Tools
    {
        public static List<Client> CollectionVille(List<Client> contacts, string Laville)
        {
            List<Client> LesClientsdelaVille = new List<Client>();
            foreach (Client UnContact in contacts)
            {
                if (UnContact.ContactVille == Laville)
                    LesClientsdelaVille.Add(UnContact);
            }
            return LesClientsdelaVille;
        }

        public static String PrepareChamp(String LaValeur, String LeType)
        {
            string ValeurPreparee = "";
            switch (LeType)
            {
                case "Chaine":
                    ValeurPreparee = "'" + LaValeur + "'";
                    break;

                case "Nombre":
                    ValeurPreparee = LaValeur;
                    break;
            }
            return ValeurPreparee;
        }

        public static String PrepareLigne(String LaLigne, String LaColonne, String LaValeur)
        {
            string LignePreparee = "";
            LignePreparee = LaLigne.Replace(LaColonne, LaValeur);
            return LignePreparee;
        }
    }
}
