﻿namespace JeuStarWars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Classe Personnage
    /// </summary>
    public class Obiwan
    {
        #region Variable
        private string nom;
        private int vie;
        private bool alignement;
        private int pM;
        private int attaque;
        private bool etat;

       
        #endregion

        #region GetterAndSetter
        public string Nom
        {
            get
            {
                return nom;
            }
        }
        public int Vie
        {
            get
            {
                return vie;
            }
        }

        public bool Alignement
        {
            get
            {
                return alignement;
            }
        }

        public int PM
        {
            get
            {
                return pM;
            }
        }

        public bool Etat
        {
            get
            {
                return etat;
            }
        }

        public int Attaque
        {
            get
            {
                return attaque;
            }
        }
        #endregion

        #region Constructeur
        public Obiwan()
        {
            this.nom = "Obiwan";
            this.vie = 10;
            this.alignement = true;
            this.pM = 3;
            this.etat = true;
            this.attaque = 6;
        }
        #endregion


    }
}

