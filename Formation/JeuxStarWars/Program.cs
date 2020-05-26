namespace JeuxStarWars
{
    using System.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using static System.Console;
    using JeuxStarWars;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;


    /// <summary>
    /// Class se lancant au démarage de l'apli
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Méthode principale de la class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //testCo();
            ChoisirPersonnage();

        }

        #region mes fonctions


        private static string ChoisirPersonnage()
        {
            Console.Clear();
            Console.WriteLine("Liste des personnages");
            Console.WriteLine("1 - Obiwan");
            Console.WriteLine("2 - Anakin");
            Console.Write("\r\nveuillez sélectionner un personnage(numéro) :");


            switch (Console.ReadLine())
            {
                case "1":

                    Obiwan obiwan = new Obiwan();
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("nom : {0}             ", obiwan.Nom);
                    Console.WriteLine("point de vie: {0}     ", obiwan.Vie);
                    Console.WriteLine("attaque: {0}          ", obiwan.Attaque);
                    Console.WriteLine("pm: {0}               ", obiwan.PM);
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Voulez vous sélectionné ObiWan?");
                    Console.WriteLine("(entrer pour validé)");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {

                        AffichageMenuDemarage(SauvegardePersonnageChoisi(obiwan.Nom), recherchePartie(obiwan.Nom));

                    }
                    else
                    {
                        ChoisirPersonnage();
                    }
                    return "ObiWan";
                case "2":
                    Console.WriteLine("Vous avez sélectionné Anakin");
                    Anakin anakin = new Anakin();
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("nom : {0}             ", anakin.Nom);
                    Console.WriteLine("point de vie: {0}     ", anakin.Vie);
                    Console.WriteLine("attaque: {0}          ", anakin.Attaque);
                    Console.WriteLine("pm: {0}               ", anakin.PM);
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Voulez vous sélectionné Anakin?");
                    Console.WriteLine("(entrer pour validé)");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {

                        AffichageMenuDemarage(SauvegardePersonnageChoisi(anakin.Nom), recherchePartie(anakin.Nom));

                    }
                    else
                    {
                        ChoisirPersonnage();
                    }
                    return "Anakin";

                default:
                    ChoisirPersonnage();
                    return null;
            }

        }
        private static void AffichageMenuDemarage(string personnage, decimal[] value)
        {
            decimal longueur = value[0];
            decimal hauteur = value[1];
            Grille grille = new Grille();
            Console.Clear();
            Console.WriteLine("personnage choisi :{0}", personnage);
            Console.WriteLine("1 - nouvelle partie");
            Console.WriteLine("2 - changer de personnage");
            if (longueur > 0 || hauteur > 0)
            {
                Console.WriteLine("3 - charger partie ");
            }
            Console.Write("\r\nque souhaiter vous faire(numéro) :");

            string choix = Console.ReadLine();

            if (choix == "1")
            {
                Console.Clear();
                
                Grille.informationGrille(personnage);

            }
            else if (choix == "2")
            {
                ChoisirPersonnage();
            }
            else if(choix == "3")
            {
                Grille.GenererGrille(longueur, hauteur);
            }
            else
            {
                Console.WriteLine("le choix est incorrect");
            }

        }
        private static string SauvegardePersonnageChoisi(string personnage)
        {
            if (personnage == "Obiwan" || personnage == "Anakin")
            {

                return personnage;
            }
            else
            {
                return null;
            }
        }

        public static decimal[] recherchePartie(string personnage)
        {
            decimal longueur;
            decimal hauteur;
            decimal[] myArray = new decimal[2];
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = "Server=DESKTOP-261AUCN\\SQLEXPRESS;Database=Akka.Formations.Databases.JeuStarWars;Trusted_Connection=True;";
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT personnage, longueur, hauteur FROM Sauvegarde WHERE personnage ='" + personnage + "'";

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                longueur = reader.GetDecimal("longueur");
                                hauteur = reader.GetDecimal("hauteur");


                                myArray[0] = longueur;
                                myArray[1] = hauteur;

                            }

                            reader.Close();
                        }



                    }
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }

            }

            return myArray;
        }
        #endregion
    }
}
