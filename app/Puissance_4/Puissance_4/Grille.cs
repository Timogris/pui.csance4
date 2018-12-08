using System;

namespace Puissance_4
{
    class Grille
    {
        public Grille()
        {
            private const int nbLignes = 6, nbColonnes = 7; // On donne le nombre de lignes et colonnes, ici 6*7
            private const char caseVide = ' ', caseJoueur1 = '1', caseJoueur2 = '2'; // Les cases vides seront indiquees par un 0, celles jouees par le joueur 1, un 1, etc.

            private char[,] grilleJeu; // On initialise le tableau a deux dimensions qu'est la grille de jeu

            private int compteurJeton;

        }

        public void Init()
        {
            grilleJeu = new char[nbLignes, nbColonnes]; // La grille a maintenant des dimensions definies

            for (int i = 0; i < nbLignes; i++)
                for (int j = 0; j < nbColonnes; j++)
                    grilleJeu[i, j] = caseVide; // On initialise chaque case de la grille avec un case vide.
        }

        public void Afficher() // Methode pour afficher la grille sur la console
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
    }
}
