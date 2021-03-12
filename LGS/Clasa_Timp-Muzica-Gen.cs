using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGS
{
    public class Class2
    {
        private static int muzica = 0;
        public static int Muzica
        {
            get { return muzica; }
            set { muzica = value; }
        }

        private static int gen = 1;
        public static int Gen
        {
            get { return gen; }
            set { gen = value; }
        }


        private static int timeCs = 0;
        public static int TimeCs
        {
            get { return timeCs; }
            set { timeCs = value; }
        }

        private static int timeSec = 0;
        public static int TimeSec
        {
            get { return timeSec; }
            set { timeSec = value; }
        }

        private static int timeMin = 0;
        public static int TimeMin
        {
            get { return timeMin; }
            set { timeMin = value; }
        }
    }
}
