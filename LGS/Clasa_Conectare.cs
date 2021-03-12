using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS
{
    class Clasa_Conectare
    {
        private static string var;
        public static string variabila
        {
            get { return var; }
            set { var = value; }
        }

        private static string email;
        public static string conectat
        {
            get { return email; }
            set { email = value; }
        }

        private static string nume;
        public static string nume_utilizator
        {
            get { return nume; }
            set { nume = value; }
        }

        private static int status;
        public static int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
