using System;

namespace Puissance_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            Grille partie = new Grille();

            char joueur = '1';
            int colonne;

            bool bouclePartie = true;
            bool boucleSaisiePartie;

            while (bouclePartie)
            {
                System.Console.Clear();
                partie.Afficher();

                do
                {
                    boucleSaisiePartie = true;

                    Console.WriteLine("Joueur " + joueur + ": ");

                    if (Int32.TryParse(Console.ReadLine(), out colonne))
                    {
                        if (1 <= colonne && colonne <= 7)
                        {
                            if (partie.Positionner(joueur, colonne))
                            {
                                boucleSaisiePartie = false;
                            }
                            else
                            {
                                System.Console.Clear();
                                partie.Afficher();
                                Console.WriteLine("\nCette colonne est pleine.");
                            }
                        }
                        else
                        {
                            System.Console.Clear();
                            partie.Afficher();
                            Console.WriteLine("\nL'entier saisi doit etre entre 1 et 7");
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        partie.Afficher();
                        Console.WriteLine("\nSaisir un entier entre 1 et 7");
                    }
                } while (boucleSaisiePartie);

                if (partie.TestGagner(joueur))
                {
                    System.Console.Clear();
                    partie.Afficher();
                    Console.WriteLine("Le joueur " + joueur + " a gagne !");
                    Console.WriteLine("Appuyez sur Entree pour quitter");
                    bouclePartie = false;
                }
                else if (partie.GrillePleine())
                {
                    System.Console.Clear();
                    partie.Afficher();
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

}
