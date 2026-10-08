using System;
using System.Collections.Generic;
using System.Text;

namespace Tp2Algo3
{
    public class Piste
    {
         Difficultes Difficulte { get; set; }
        private int ID { get; set; }
        private string Nom { get; set; }
       

        public Piste(int id, string nom, Difficultes difficultes)
        {
            this.ID = id;
            this.Nom = nom;
            this.Difficulte = difficultes;
        }
    }
}
