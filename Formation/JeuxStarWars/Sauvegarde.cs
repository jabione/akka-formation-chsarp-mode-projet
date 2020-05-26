using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JeuxStarWars
{
    public class Sauvegarde
    {
        
        private string personnage;
        private int longueur;
        private int hauteur;

        
        public string Personnage { get => personnage; set => personnage = value; }
        public int Longueur { get => longueur; set => longueur = value; }
        public int Hauteur { get => hauteur; set => hauteur = value; }

        public Sauvegarde( string personnage, int longueur, int hauteur)
        {
            
            this.personnage = personnage;
            this.longueur = longueur;
            this.hauteur = hauteur;
        }

        public void enregistrementPartie(Sauvegarde sauvegarde)
        {
            string chaineCo = "Server=DESKTOP-261AUCN\\SQLEXPRESS;Database=Akka.Formations.Databases.JeuStarWars;Trusted_Connection=True;";

                using (SqlConnection connection = new SqlConnection())
            {
                try 
                {
                    connection.ConnectionString = chaineCo;
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {

                        command.CommandText = string.Format("INSERT INTO [dbo].[Sauvegarde]" +
                            "([personnage],[longueur],[hauteur])" +
                            " VALUES" +
                            "('{0}','{1}','{2}')", sauvegarde.personnage, sauvegarde.longueur, sauvegarde.hauteur);

                        // command.CommandText = string.Format("UPDATE [dbo].[Sauvegarde] SET [longueur] = {0},[hauteur] = {1} WHERE[personnage] ='" + sauvegarde.Personnage + "'",sauvegarde.longueur, sauvegarde.hauteur);

                        command.ExecuteNonQuery();
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
            
        }

        
    }
}
