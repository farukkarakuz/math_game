using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikOyunu
{
    internal class Soru

    {
        private int sayi1;
        private int sayi2;
        public string op;

        public int Sayi1
        {
            get { return sayi1; }   
            set { sayi1 = value; }  
        }

        public int Sayi2
        {
            get { return sayi2; }
            set { sayi2 = value; }
        }

    }

}
