using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikOyunu
{
    internal class Islem
    {     

        static public int sayiuret(int seviye)
        {
            Random rndm = new Random();
            int sayi = rndm.Next(0, seviye *10);
            return sayi;
        }

        static public int sayiuretsifirsiz(int seviye)
        {
            Random rndm = new Random();
            int sayi = rndm.Next(1,seviye * 5);
            return sayi;
        }

        static public string operatoruret(string[] operators)
        {
            Random random = new Random();
            string secilenop = operators[random.Next(0, operators.Length)];
            return secilenop;
        }

        static public double sonuccikar(int sayi1, int sayi2, string ope)
        {
            double sonuc = 0;       
                switch (ope)
                {
                    case "+":
                        sonuc = sayi1 + sayi2;
                        break;
                    case "-":
                        sonuc = sayi1 - sayi2;
                        break;
                    case "*":
                        sonuc = sayi1 * sayi2;
                        break;
                    // eğer operatörümüz bölme ve sayi1'miz 0 ise sonucu 0 olarak yapıyoruz.
                    case "/":
                        if (sayi1 == 0)
                        {
                            sonuc = 0;                      
                        }
                        else
                        {
                            sonuc = Math.Ceiling((double)sayi1 / sayi2);
                        }
                        break;
                }            
            return sonuc;
        }



    }
}
