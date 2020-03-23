using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKAVXF_Beadando
{
    class SorbaTxtLetre
    {
        int hossz;
        int suly;

        public int Hossz
        {
            get
            {
                return hossz;
            }

            set
            {
                hossz = value;
            }
        }

        public int Suly
        {
            get
            {
                return suly;
            }

            set
            {
                suly = value;
            }
        }
        public SorbaTxtLetre(int hossz, int suly)
        {
            this.suly = suly;
            this.hossz = hossz;
        }
        public void Adatok()
        {
            Console.WriteLine("{0} | {1}", hossz, suly);
        }//Kiiratáshoz segédmetódus
    }
}
