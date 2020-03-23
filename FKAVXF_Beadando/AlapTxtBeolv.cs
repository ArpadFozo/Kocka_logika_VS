using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FKAVXF_Beadando
{
    class AlapTxtBeolv
    {
        int hossz;
        int suly;

        public int Hossz
        {
            get
            {
                return hossz;
            }
        }

        public int Suly
        {
            get
            {
                return suly;
            }
        }
        public AlapTxtBeolv(int hossz, int suly)
        {
            this.hossz = hossz;
            this.suly = suly;
        }
        public static AlapTxtBeolv [] Beolv(StreamReader sr)
        {
            string [] sor;
            int i = 0;
            int meret = int.Parse(sr.ReadLine());
            AlapTxtBeolv[] tomb = new AlapTxtBeolv[meret];
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine().Split(' ');
                tomb[i] = new AlapTxtBeolv(int.Parse(sor[0]), int.Parse(sor[1]));
                i++;
            }
            return tomb;
        }
        public void Adatok()
        {
            Console.WriteLine("{0} | {1}", hossz, suly);
        }//Kiiratáshoz segédmetódus
    }
}
