using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS
{
    public class Clasa_Intrebari
    {
        private static int limba;
        public static int Limba
        {
            get { return limba; }
            set { limba = value; }
        }

        private static int[] quest;
        public static int[] Questions
        {
            get { return quest; }
            set { quest = value; }
        }

        private static int corecte;
        public static int Corecte
        {
            get { return corecte; }
            set { corecte = value; }
        }

        private static int gresite;
        public static int Gresite
        {
            get { return gresite; }
            set { gresite = value; }
        }

        private static int nr_intreb;
        public static int Numar_Intrebare
        {
            get { return nr_intreb; }
            set { nr_intreb = value; }
        }

        private static int total;
        public static int Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
