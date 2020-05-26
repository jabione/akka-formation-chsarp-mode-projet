using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JeuxStarWars
{
    public class Grille
    {
        public Grille()
        {

        }
        public static void GenererGrille(decimal largeur, decimal hauteur)
        {
            Console.Clear();
            for (int o = 0; o < hauteur; o++)
            {
                afficheSeparateur(largeur);
                afficherLigne(largeur);
            }
            afficheSeparateur(largeur);
            Console.ReadKey();
        }
        public static void informationGrille(string personnage)
        {
            Console.WriteLine("veuillez choisir une largeur a la grille :");
            string saisiLargeur = Console.ReadLine();
            if (Regex.IsMatch(saisiLargeur, @"^[0-9]+$"))
            {
                Console.WriteLine("largeur de la grille :{0}", saisiLargeur);
                Console.WriteLine("veuillez choisir une hauteur a la grille :");
                string saisiHauteur = Console.ReadLine();
                if (Regex.IsMatch(saisiHauteur, @"^[0-9]+$"))
                {
                    Sauvegarde sauvegarde = new Sauvegarde(personnage, Int32.Parse(saisiLargeur), Int32.Parse(saisiHauteur));
                    sauvegarde.enregistrementPartie(sauvegarde);
                    validationGrille(Int32.Parse(saisiLargeur), Int32.Parse(saisiHauteur));

                }
                else
                {
                    Console.Clear();
                    informationGrille(personnage);
                }
            }
            else
            {
                Console.Clear();
                informationGrille(personnage);
            }


        }
        private static void validationGrille(int saisiLargeur, int saisiHauteur)
        {
            Console.Clear();
            Console.WriteLine("largeur de la grille :{0}", saisiLargeur);
            Console.WriteLine("hauteur de la grille :{0}", saisiHauteur);
            Console.WriteLine("veuillez valider votre choix(touche entrer pour valider, touche echap pour annulé)");
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                GenererGrille(saisiLargeur, saisiHauteur);

            }
            else if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {

            }
            else
            {
                validationGrille(saisiLargeur, saisiHauteur);
            }
        }

        private static void afficheSeparateur(decimal n)
        {
            int i;

            for (i = 0; i < n; i++)
                Console.Write("+---");
            Console.WriteLine("+");
        }
        private static void afficherLigne(decimal largeur)
        {
            StringBuilder mystringBuilder = new StringBuilder();
            for (int i = 0; i < largeur; i++)
            {
                mystringBuilder.Append("|   ");
            }
            mystringBuilder.AppendLine("|");
            Console.Write(mystringBuilder);
        }



    }

}

