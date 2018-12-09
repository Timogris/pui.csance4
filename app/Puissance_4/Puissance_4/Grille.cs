using System;

namespace Puissance_4
{
    public class Grille
    {

        private int _nbLignes, _nbColonnes, _compteurJeton;
        private char _caseVide, _caseJoueur1, _caseJoueur2;
        private char[,] _grilleJeu;

        public int NbLignes
        {
            get => _nbLignes;
            set => _nbLignes = value;
        }

        public int NbColonnes
        {
            get => _nbColonnes;
            set => _nbColonnes = value;
        }

        public int CompteurJeton
        {
            get => _compteurJeton;
            set => _compteurJeton = value;
        }
  
        public char CaseVide
        {
            get => _caseVide;
            set => _caseVide = value;
        }

        public char CaseJoueur1
        {
            get => _caseJoueur1;
            set => _caseJoueur1 = value;
        }

        public char CaseJoueur2
        {
            get => _caseJoueur2;
            set => _caseJoueur2 = value;
        }

        public char[,] GrilleJeu
        {
            get => _grilleJeu;
            set => _grilleJeu = value;
        }

        public Grille()
        {
            _nbLignes = 6;
            _nbColonnes = 7;
            _compteurJeton = 0;

            _caseVide = ' ';
            _caseJoueur1 = '1';
            _caseJoueur2 = '2';

            _grilleJeu = new char[_nbLignes, _nbColonnes];
            
        }

        public void Init()
        {
            for (int i = 0; i < _nbLignes; i++)
                for (int j = 0; j < _nbColonnes; j++)
                    _grilleJeu[i, j] = _caseVide; // On initialise chaque case de la grille avec un case vide.
        }

        public void Afficher() // Methode pour afficher la grille sur la console
        {
            for (int i = 0; i < _nbLignes; i++)
            {
                for (int j = 0; j < _nbColonnes; j++)
                {
                    Console.Write(_grilleJeu[i, j]);
                    Console.Write('|');
                }
                Console.WriteLine("");
            }
        }

        public bool GrillePleine()
        {
            return _compteurJeton >= _nbColonnes * _nbLignes;
        }


        public bool Positionner(char _joueur, int _colonne) // retourne true si le jeton peut etre joue dans cette colonne
        {
            _colonne--;

            if (_grilleJeu[0, _colonne] != _caseVide) // La case n'est pas vide, elle ne peut donc pas etre jouee : retourne faux
                return false;

            for (int i = 0; i < _nbLignes; i++)
            {
                if ((i == _nbLignes - 1) || (_grilleJeu[i + 1, _colonne] != _caseVide)) // La boucle check toutes les cases de la colonne pour voir s'il reste de la place
                {
                    _grilleJeu[i, _colonne] = _joueur; // Puis applique le jeton du joueur a cette place
                    break;
                }
            }

            _compteurJeton++;
            return true;
        }

        public bool TestGagner(char joueur) // Methode qui check l'apparition d'une suite de 4 jetons
        {
            // Check horizontal
            for (int i = 0; i < _nbLignes; i++)
                for (int j = 0; j < 4; j++)
                    if (_grilleJeu[i, j] == joueur && _grilleJeu[i, j + 1] == joueur)
                        if (_grilleJeu[i, j + 2] == joueur && _grilleJeu[i, j + 3] == joueur)
                        return true;

            // Check vertical
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < _nbColonnes; j++)
                    if (_grilleJeu[i, j] == joueur && _grilleJeu[i + 1, j] == joueur)
                        if (_grilleJeu[i + 2, j] == joueur && _grilleJeu[i + 3, j] == joueur)
                            return true;

            // Check diagonal
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < _nbColonnes; j++)
                {
                    if (_grilleJeu[i, j] == joueur)
                    {
                        // Diagonale gauche
                        try
                        {
                            if (_grilleJeu[i + 1, j - 1] == joueur)
                            {
                                if (_grilleJeu[i + 2, j - 2] == joueur)
                                {
                                    if (_grilleJeu[i + 3, j - 3] == joueur)
                                        return true;
                                }

                            }
                        }
                        catch (IndexOutOfRangeException) {}

                        // Diagonale droite
                        try
                        {
                            if (_grilleJeu[i + 1, j + 1] == joueur)
                            {
                                if (_grilleJeu[i + 2, j + 2] == joueur)
                                {
                                    if (_grilleJeu[i + 3, j + 3] == joueur)
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

    }
}
