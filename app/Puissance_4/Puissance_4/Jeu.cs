using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance_4
{
    public class Jeu
    {
        //Attributs
        private string _nomJeu;

        //Accesseur
        public string NomJeu { get => _nomJeu; set => _nomJeu = value; }

        //Constructeur
        public Jeu(string nomJeu)
        {
            _nomJeu = nomJeu;
        }
    }
}
