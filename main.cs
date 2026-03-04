using System;
using System.Collections.Generic;

namespace TP_Bibliotheque_SIO
{
    struct Livre
    {
        public string Titre;
        public string Auteur;
        public int Annee;
        public int Pages;
        public bool EstDisponible;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // PARTIE 1 & 2 : Création et Liste
            List<Livre> bibliotheque = new List<Livre>();

            Livre l1;
            l1.Titre = "Le Seigneur des Anneaux";
            l1.Auteur = "J.R.R. Tolkien";
            l1.Annee = 1954;
            l1.Pages = 1178;
            l1.EstDisponible = true;

            Livre l2;
            l2.Titre = "1984";
            l2.Auteur = "George Orwell";
            l2.Annee = 1949;
            l2.Pages = 328;
            l2.EstDisponible = false;

            Livre l3;
            l3.Titre = "Le Petit Prince";
            l3.Auteur = "Antoine de Saint-Exupéry";
            l3.Annee = 1943;
            l3.Pages = 93;
            l3.EstDisponible = true;

            bibliotheque.Add(l1);
            bibliotheque.Add(l2);
            bibliotheque.Add(l3);

            Console.WriteLine("=== Liste complète des livres ===");
            foreach (var livre in bibliotheque)
            {
                Console.WriteLine($"- {livre.Titre} ({livre.Auteur}, {livre.Annee})");
            }

            // PARTIE 3 : Filtrages
            Console.WriteLine("\n=== Livres disponibles ===");
            foreach (var livre in bibliotheque)
            {
                if (livre.EstDisponible) Console.WriteLine(livre.Titre);
            }

            Console.WriteLine("\n=== Livres de plus de 300 pages ===");
            foreach (var livre in bibliotheque)
            {
                if (livre.Pages > 300) Console.WriteLine(livre.Titre);
            }

            // PARTIE 4 : Calculs
            int totalPages = 0;
            int nbDispo = 0;
            foreach (var livre in bibliotheque)
            {
                totalPages += livre.Pages;
                if (livre.EstDisponible) nbDispo++;
            }
            Console.WriteLine($"\nTotal de pages dans la bibliothèque : {totalPages}");
            Console.WriteLine($"Nombre de livres dispos : {nbDispo}");

            // PARTIE 5 : Recherche
            Console.Write("\nEntrez un titre à rechercher : ");
            string recherche = Console.ReadLine();
            bool trouve = false;

            foreach (var livre in bibliotheque)
            {
                if (livre.Titre.ToLower() == recherche.ToLower())
                {
                    Console.WriteLine($"Trouvé ! Auteur : {livre.Auteur}, Dispo : {livre.EstDisponible}");
                    trouve = true;
                    break;
                }
            }
            if (!trouve) Console.WriteLine("Livre introuvable.");

            // PARTIE 6 : Emprunt 
            Console.Write("\nQuel titre souhaitez-vous emprunter ? ");
            string titreEmprunt = Console.ReadLine();
            bool empruntReussi = false;

            for (int i = 0; i < bibliotheque.Count; i++)
            {
                if (bibliotheque[i].Titre.ToLower() == titreEmprunt.ToLower() && bibliotheque[i].EstDisponible)
                {
                    Livre copieLivre = bibliotheque[i];
                    copieLivre.EstDisponible = false;
                    bibliotheque[i] = copieLivre;

                    empruntReussi = true;
                    Console.WriteLine("Emprunt validé !");
                    break;
                }
            }
            if (!empruntReussi) Console.WriteLine("Emprunt impossible (titre inexistant ou déjà pris).");

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}