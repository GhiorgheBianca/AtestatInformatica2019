using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS
{
    public class Class3
    {
        private static string[] titlu;
        public static string[] Titlu
        {
            get { return titlu; }
            set { titlu = value; }
        }

        private static string parola;
        public static string Parola
        {
            get { return parola; }
            set { parola = value; }
        }

        private static bool adevarat;
        public static bool Adevarat
        {
            get { return adevarat; }
            set { adevarat = value; }
        }

        private static bool test_acomodare = false;
        public static bool Test_acomodare
        {
            get { return test_acomodare; }
            set { test_acomodare = value; }
        }
    }
}
