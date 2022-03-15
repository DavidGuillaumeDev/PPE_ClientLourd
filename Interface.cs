using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using QRCoder;
using MySql;


namespace Demarrage_PPE
{
    interface Interface
    {
        public static int MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue au salon");
            Console.WriteLine("1. Ajouter un participant");
            Console.WriteLine("2. Rechercher un participant");
            Console.WriteLine("3. Créer le badge d'un participant");
            Console.WriteLine("4. Quitter");
            Console.WriteLine("");
            try
            {
                int Choix = int.Parse(Console.ReadLine());
                return Choix;
            }
            catch
            {
                return 0;
            }
            
        }
        public static int Afficher()
        {
            int choixUser;
            Console.Clear();
            Console.WriteLine("1. Rechercher un Participant");
            Console.WriteLine("2. Ajouter un Participant");
            Console.WriteLine("3. Quitter");
            Console.WriteLine("Votre Choix : ");
            choixUser = int.Parse(Console.ReadLine());
            return choixUser;
        }

        public static void TraiterChoix(int choixUser)
        {
            switch (choixUser)
            {
                case 0:
                    Console.WriteLine("Les choix possibles sont 1, 2 ou 3. Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Vous souhaitez ajouter un participant. Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    AjouterClient(DataBaseConnection, TheReader);
                    break;
                case 2:
                    Console.WriteLine("Vous souhaitez rechercher un participant. Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Au revoir...");
                    break;
                default:
                    break;
            }
        }

        public static void FabriquerBadge(int TheparticipantID)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(TheparticipantID.ToString(),QRCodeGenerator.ECCLevel.Q );
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);
            Console.WriteLine("Le QrCode en base 64 est : " + qrCodeImageAsBase64);
            StreamWriter monStreamWriter = new StreamWriter(@"QRCode.txt");
            monStreamWriter.Write(qrCodeImageAsBase64);
            monStreamWriter.Close();
            Console.WriteLine("Le QrCode est généré. Appuyer sur une touche pour continuer");
            Console.ReadKey();
        }

        public static void AjouterParticipant(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            Participant UnParticipant = new Participant();
            String NomParticipant, PrenomParticipant, EmailParticipant;
            Console.Clear();
            Console.WriteLine(".............................................");
            Console.Write("..............Nom du Participant?");
            NomParticipant = Console.ReadLine();
            Console.Write("..............Prenom du Participant?");
            PrenomParticipant = Console.ReadLine();
            Console.Write("..............Email du Participant?");
            EmailParticipant = Console.ReadLine();
            Console.Write("..............Voulez-vous enregistrer ce participant ?");
            String Reponse = "";
            do
            {
                try
                {
                    Reponse = Console.ReadLine();
                    Reponse = Reponse.ToUpper();
                    if (Reponse == "O")
                    {
                        //Enregistrement dans la BDD
                        UnParticipant.Init(NomParticipant, PrenomParticipant, EmailParticipant);
                        UnParticipant.Save(DataBaseConnection, TheReader);
                    }
                }
                catch
                {
                    
                }
            }
        }
    }
}
