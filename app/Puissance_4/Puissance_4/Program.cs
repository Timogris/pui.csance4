using System;

namespace Puissance_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            MoteurJeu partie = new MoteurJeu();

            char joueur = '1';
            int colonne;

            bool bouclePartie = true;
            bool boucleSaisiePartie;

            while (bouclePartie)
            {
                System.Console.Clear();
                partie.AfficherGrille();

                do
                {
                    boucleSaisiePartie = true;

                    Console.WriteLine("Joueur " + joueur + ": ");

                    if (Int32.TryParse(Console.ReadLine(), out colonne))
                    {
                        if (1 <= colonne && colonne <= 7)
                        {
                            if (partie.AjouterJetonDansGrille(joueur, colonne))
                            {
                                boucleSaisiePartie = false;
                            }
                            else
                            {
                                System.Console.Clear();
                                partie.AfficherGrille();
                                Console.WriteLine("\nCette colonne est pleine.");
                            }
                        }
                        else
                        {
                            System.Console.Clear();
                            partie.AfficherGrille();
                            Console.WriteLine("\nL'entier saisi doit etre entre 1 et 7");
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        partie.AfficherGrille();
                        Console.WriteLine("\nSaisir un entier entre 1 et 7");
                    }
                } while (boucleSaisiePartie);

                if (partie.QuatreALaSuite(joueur))
                {
                    System.Console.Clear();
                    partie.AfficherGrille();
                    Console.WriteLine("Le joueur " + joueur + " a gagne !");
                    Console.WriteLine("Appuyez sur Entree pour quitter");
                    bouclePartie = false;
                }
                else if (partie.GrillePleine())
                {
                    System.Console.Clear();
                    partie.AfficherGrille();
                    Console.WriteLine("Egalite.");
                    Console.WriteLine("Appuyez sur Entree pour quitter");
                    bouclePartie = false;
                }
                else
                {
                    joueur = joueur == '1' ? '2' : '1';
                }
            }
            Console.ReadKey();
        }
    }

    class MoteurJeu // On cree la classe du moteur de jeu
    {
        const int nbLignes = 6, nbColonnes = 7; // On donne le nombre de lignes et colonnes, ici 6*7
        const char caseVide = ' ', caseJoueur1 = '1', caseJoueur2 = '2'; // Les cases vides seront indiquees par un 0, celles jouees par le joueur 1, un 1, etc.

        private char[,] grilleJeu; // On initialise le tableau a deux dimensions qu'est la grille de jeu

        int compteurJeton;

        public MoteurJeu() // On cree la methode du moteur de jeu
        {
            grilleJeu = new char[nbLignes, nbColonnes]; // La grille a maintenant des dimensions definies

            for (int i = 0; i < nbLignes; i++)
                for (int j = 0; j < nbColonnes; j++)
                    grilleJeu[i, j] = caseVide; // On initialise chaque case de la grille avec un case vide.
        }

        public void AfficherGrille() // Methode pour afficher la grille sur la console
        {
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    Console.Write(grilleJeu[i, j]);
                    Console.Write('|');
                }
                Console.WriteLine("");
            }
        }

        public bool AjouterJetonDansGrille(char joueur, int colonne) // retourne true si le jeton peut etre joue dans cette colonne
        {
            colonne--;

            if (grilleJeu[0, colonne] != caseVide) // La case n'est pas vide, elle ne peut donc pas etre jouee : retourne faux
                return false;

            for (int i = 0; i < nbLignes; i++)
            {
                if ((i == nbLignes - 1) || (grilleJeu[i + 1, colonne] != caseVide)) // La boucle check toutes les cases de la colonne pour voir s'il reste de la place
                {
                    grilleJeu[i, colonne] = joueur; // Puis applique le jeton du joueur a cette place
                    break;
                }
            }

            compteurJeton++;
            return true;
        }

        public bool QuatreALaSuite(char joueur) // Methode qui check l'apparition d'une suite de 4 jetons
        {
            // Check horizontal
            for (int i = 0; i < nbLignes; i++)
                for (int j = 0; j < 4; j++)
                    if (grilleJeu[i, j] == joueur && grilleJeu[i, j + 1] == joueur)
                        if (grilleJeu[i, j + 2] == joueur && grilleJeu[i, j + 3] == joueur)
                        return true;

            // Check vertical
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < nbColonnes; j++)
                    if (grilleJeu[i, j] == joueur && grilleJeu[i + 1, j] == joueur)
                        if (grilleJeu[i + 2, j] == joueur && grilleJeu[i + 3, j] == joueur)
                            return true;

            // Check diagonal
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    if (grilleJeu[i, j] == joueur)
                    {
                        // Diagonale gauche
                        try
                        {
                            if (grilleJeu[i + 1, j - 1] == joueur)
                            {
                                if (grilleJeu[i + 2, j - 2] == joueur)
                                {
                                    if (grilleJeu[i + 3, j - 3] == joueur)
                                        return true;
                                }

                            }
                        }
                        catch (IndexOutOfRangeException) {}

                        // Diagonale droite
                        try
                        {
                            if (grilleJeu[i + 1, j + 1] == joueur)
                            {
                                if (grilleJeu[i + 2, j + 2] == joueur)
                                {
                                    if (grilleJeu[i + 3, j + 3] == joueur)
                                        return true;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException) {}
                    }
                }
            }

            return false; // Si aucune des boucles ne retournent true
        }

        public bool GrillePleine()
        {
            return compteurJeton >= nbColonnes * nbLignes;
        }

    }

}
