using System;
using System.Collections.Generic;
using System.IO;
using QRCoder;
using MySql.Data.MySqlClient;




namespace Demarrage_PPE
{
    interface Interface
    {
        public static int MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("...................Bienvenue au salon............");
            Console.WriteLine("1 : Ajouter un participant ");
            Console.WriteLine("2 : Rechercher un participant");
            Console.WriteLine("3 : Creér le badge d'un participant");
            Console.WriteLine("4 : Quitter");
            Console.WriteLine("");
            Console.Write("Votre choix : - ");
            try
            {
                String LeChoix = Console.ReadLine();
                return int.Parse(LeChoix);
            }
            catch
            {
                return 0; //Erreur de Saisie
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

        public static void TraiterChoix(int LeChoix, DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            switch (LeChoix)
            {
                case 0:
                    Console.WriteLine("Les choix possibles sont 1, 2, 3 ou 4. Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    break;

                case 1:
                    Console.WriteLine("Vous souhaitez ajouter un participant. Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    AjouterParticipant(DataBaseConnection, TheReader);
                    break;

                case 2:
                    Console.WriteLine("Vous souhaitez rechercher un participant. Appuyez sur une touche pour continuer");
                    Console.ReadKey();
                    RechercherParticipant(DataBaseConnection, TheReader);
                    break;

                case 3:
                    Console.WriteLine("Vous souhaitez générer le badge d'un participant");
                    Console.ReadKey();
                    FabriquerBadge(1, "Dav", "Gui");
                    break;

                case 4:
                    Console.WriteLine("Au revoir.....");
                    break;
            }
        }

        public static void FabriquerBadge(int TheparticipantID, String UnNom, String UnPrenom)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(TheparticipantID.ToString(),QRCodeGenerator.ECCLevel.Q );

            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20);

            StreamWriter monStreamWriter = new StreamWriter(@"BadgeSalon.html");

            String strImage = "<img src=\"data:image/png;base64," + qrCodeImageAsBase64 + "\">";
            monStreamWriter.WriteLine("<html>");
            monStreamWriter.WriteLine("<body>");
            string temptext = "<P>" + UnNom + "<P>";
            monStreamWriter.WriteLine(temptext);
            temptext = "<P>" + UnPrenom + "<P>";
            monStreamWriter.WriteLine(temptext);
            monStreamWriter.WriteLine(strImage);
            monStreamWriter.WriteLine("<body>");
            monStreamWriter.WriteLine("<html>");
            
            monStreamWriter.Close();
            Console.WriteLine("Le QrCode est généré. Appuyer sur une touche pour continuer");
            Console.ReadKey();
        }

        public static void RechercherParticipant(DBConnection DataBaseConnection, MySqlDataReader TheReader)
        {
            String NomParticipant;
            Console.Clear();
            Console.WriteLine(".....................................................");
            Console.Write("...................Nom du participant recherché ?");
            NomParticipant = Console.ReadLine();

            string query = "select id,nom,prenom,email from Participant where nom =?nom;";
            query = Tools.PrepareLigne(query, "?nom", Tools.PrepareChamp(NomParticipant, "Chaine"));

            var cmd = new MySqlCommand(query, DataBaseConnection.Connection);
            List<Participant> LesParticipantsTrouves = new List<Participant>();
            TheReader = cmd.ExecuteReader();//On est arrivé à la fin, il faut recharger le reader
            while (TheReader.Read())
            {
                Participant UnParticipant = new Participant
                {
                    ParticipantID = (int)TheReader["id"],
                    Nom = (string)TheReader["nom"],
                    Prenom = (string)TheReader["prenom"],
                    Email = (string)TheReader["email"]

                };
                LesParticipantsTrouves.Add(UnParticipant);
            }
            if (LesParticipantsTrouves.Count > 0)
            {
                Console.WriteLine("--------------------Participants Trouvés------------------");
                foreach (Participant UnParticipant in LesParticipantsTrouves)
                    Console.WriteLine(UnParticipant.ParticipantID.ToString() + ", " + UnParticipant.Prenom + ", " + UnParticipant.Nom + ", " + UnParticipant.Email);
            }
            else
                Console.WriteLine("Je n'ai trouvé personne.");
            Console.WriteLine("Appuyer sur une touche pour continuer");
            Console.ReadKey();
            TheReader.Close();

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
                try
                {
                    Reponse = Console.ReadLine();
                    Reponse = Reponse.ToUpper();//On convertit en majuscule
                    if (Reponse == "O")
                        //Ici on effectue l'enregistrement dans la BDD
                        //UnParticipant.Init(NomParticipant, PrenomParticipant, EmailParticipant);
                        UnParticipant.Save(DataBaseConnection, TheReader);
                        Console.WriteLine("Le participant est enregistré");
                        System.Threading.Thread.Sleep(2000);//On patiente deux secondes
                }
                catch
                {
                    Console.WriteLine("Choix incorrect");
                }
            while ((Reponse != "o") && (Reponse != "O") && (Reponse != "n") && (Reponse != "N"));
        }
    }
}
