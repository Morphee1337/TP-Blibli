using System;
using System.Collections.Generic;

namespace TP_Bibliotheque_SIO
{
    // PARTIE 1 – Créer la structure Livre
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
            // PARTIE 2 – Créer la liste de livres
            List<Livre> bibliotheque = new List<Livre>();

            // Initialisation de 3 livres (Partie 1.2 & 2.2)
            Livre l1;
            l1.Titre = "1984";
            l1.Auteur = "George Orwell";
            l1.Annee = 1949;
            l1.Pages = 328;
            l1.EstDisponible = true;

            Livre l2;
            l2.Titre = "Le Petit Prince";
            l2.Auteur = "Antoine de Saint-Exupéry";
            l2.Annee = 1943;
            l2.Pages = 93;
            l2.EstDisponible = true;

            Livre l3;
            l3.Titre = "Le Silmarillion";
            l3.Auteur = "J.R.R. Tolkien";
            l3.Annee = 1977;
            l3.Pages = 450;
            l3.EstDisponible = false;

            bibliotheque.Add(l1);
            bibliotheque.Add(l2);
            bibliotheque.Add(l3);
            bool quitter = false;
            while (!quitter)
            {
                Console.Clear();
                Console.WriteLine("--- GESTIONNAIRE DE BIBLIOTHÈQUE ---");
                Console.WriteLine("1. Afficher tous les livres");
                Console.WriteLine("2. Filtrages (Dispos, +300p, après 2000)");
                Console.WriteLine("3. Calculs (Total pages & dispos)");
                Console.WriteLine("4. Rechercher un livre");
                Console.WriteLine("5. Emprunter un livre");
                Console.WriteLine("6. Ajouter un livre (Saisie clavier)");
                Console.WriteLine("0. Quitter");
                Console.Write("\nVotre choix : ");
                
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        // PARTIE 2 – Parcourir la liste
                        Console.WriteLine("\n--- Liste complète ---");
                        foreach (var l in bibliotheque)
                        {
                            Console.WriteLine($"{l.Titre} - {l.Auteur} ({l.Annee})");
                        }
                        break;

                    case "2":
                        // PARTIE 3 – Filtrages
                        Console.WriteLine("\n--- Livres disponibles ---");
                        foreach (var l in bibliotheque) if (l.EstDisponible) Console.WriteLine(l.Titre);

                        Console.WriteLine("\n--- Plus de 300 pages ---");
                        foreach (var l in bibliotheque) if (l.Pages > 300) Console.WriteLine(l.Titre);

                        Console.WriteLine("\n--- Publiés après 2000 ---");
                        foreach (var l in bibliotheque) if (l.Annee > 2000) Console.WriteLine(l.Titre);
                        break;

                    case "3":
                        // PARTIE 4 – Calculs
                        int totalPages = 0;
                        int nbDispo = 0;
                        foreach (var l in bibliotheque)
                        {
                            totalPages += l.Pages;
                            if (l.EstDisponible) nbDispo++;
                        }
                        Console.WriteLine($"\nNombre total de pages : {totalPages}");
                        Console.WriteLine($"Nombre de livres disponibles : {nbDispo}");
                        break;

                    case "4":
                        // PARTIE 5 – Recherche
                        Console.Write("\nEntrez le titre recherché : ");
                        string recherche = Console.ReadLine().ToLower();
                        bool trouve = false;
                        foreach (var l in bibliotheque)
                        {
                            if (l.Titre.ToLower() == recherche)
                            {
                                Console.WriteLine($"Trouvé : {l.Titre}, Auteur : {l.Auteur}, Dispo : {l.EstDisponible}");
                                trouve = true;
                                break;
                            }
                        }
                        if (!trouve) Console.WriteLine("Livre introuvable.");
                        break;

                    case "5":
                        // PARTIE 6 – Emprunt
                        Console.Write("\nTitre à emprunter : ");
                        string titreEmp = Console.ReadLine().ToLower();
                        bool empruntOk = false;
                        for (int i = 0; i < bibliotheque.Count; i++)
                        {
                            if (bibliotheque[i].Titre.ToLower() == titreEmp && bibliotheque[i].EstDisponible)
                            {
                                Livre temp = bibliotheque[i];
                                temp.EstDisponible = false;
                                bibliotheque[i] = temp;
                                empruntOk = true;
                                Console.WriteLine("Emprunt validé !");
                                break;
                            }
                        }
                        if (!empruntOk) Console.WriteLine("Emprunt impossible (titre incorrect ou déjà pris).");
                        break;

                    case "6":
                        // PARTIE 7 – Ajout via clavier
                        Livre nouveau;
                        Console.Write("Titre : "); nouveau.Titre = Console.ReadLine();
                        Console.Write("Auteur : "); nouveau.Auteur = Console.ReadLine();
                        Console.Write("Année : "); nouveau.Annee = int.Parse(Console.ReadLine());
                        Console.Write("Pages : "); nouveau.Pages = int.Parse(Console.ReadLine());
                        nouveau.EstDisponible = true;
                        bibliotheque.Add(nouveau);
                        Console.WriteLine("Livre ajouté !");
                        break;

                    case "0":
                        quitter = true;
                        break;
                }
                if (!quitter) { Console.WriteLine("\nAppuyez sur une touche..."); Console.ReadKey(); }
            }
        }
    }
}