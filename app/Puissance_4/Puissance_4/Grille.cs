using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance_4
{
    public class Grille
    {
        private static int nbLignes = 6;
        private static int nbColonnes = 7;

        private char[,] tabGrille = new char[nbLignes, nbColonnes];

        public void Init()
        {
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; i < nbColonnes; i++)
                {
                    tabGrille[i, j] = '0'; 
                }
            }
        }
    }
}
