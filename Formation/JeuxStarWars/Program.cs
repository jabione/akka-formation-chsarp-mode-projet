namespace JeuxStarWars
{
    using System.Diagnostics;
    using System;
    using System.Runtime.CompilerServices;
    using static System.Console;
    using JeuxStarWars;
    using System.Text;
    using System.Text.RegularExpressions;


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
            ChoisirPersonnage();
        }

        #region mes fonctions
        private static bool ChoisirPersonnage()
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
                        AffichageMenuDemarage(SauvegardePersonnageChoisi(obiwan.Nom));

                    }
                    else
                    {
                        ChoisirPersonnage();
                    }
                    return true;
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
                        AffichageMenuDemarage(SauvegardePersonnageChoisi(anakin.Nom));

                    }
                    else
                    {
                        ChoisirPersonnage();
                    }
                    return true;

                default:
                    ChoisirPersonnage();
                    return false;
            }

        }
        private static void AffichageMenuDemarage(string personnage)
        {

            Console.Clear();
            Console.WriteLine("personnage choisi :{0}", personnage);
            Console.WriteLine("1 - nouvelle partie");
            Console.WriteLine("2 - changer de personnage");
            Console.Write("\r\nque souhaiter vous faire(numéro) :");

            string choix = Console.ReadLine();

            if (choix == "1")
            {
                Console.Clear();
                Grille grille = new Grille();
                Grille.informationGrille();
               
            }
            else if (choix == "2")
            {
                ChoisirPersonnage();
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
       
        #endregion
    }
}
