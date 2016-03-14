using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class HotKeys
    {
        private static string keyF = "F";
        public static string Fold
        {
            get { return keyF; }
            set { keyF = value; }
        }
        private static string keyH = "H";

        public static string Check
        {
            get { return keyH; }
            set { keyH = value; }
        }
        private static string keyC = "C";

        public static string Call
        {
            get { return keyC; }
            set { keyC = value; }
        }
        private static string keyR = "R";

        public static string Raise
        {
            get { return keyR; }
            set { keyR = value; }
        }
    }
}
