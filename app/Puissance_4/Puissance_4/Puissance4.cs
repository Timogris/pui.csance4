﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance_4
{
    public class Puissance4 : Jeu
    {
        public Puissance4() : base("Jeu")
        {
        }

        public void Demarrer()
        {
            var saisie;

            do
            {
                Console.WriteLine("Commencer une nouvelle partie ? [y/n]");
                saisie = Console.ReadLine();
            }

        }
    }
}
