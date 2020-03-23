using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FKAVXF_Beadando
{
    class TxtLetre
    {
        private static Random rnd = new Random();
        static public void BeAllomanyLetrehozas()
        {
            int db = rnd.Next(1, 1001);
            StreamWriter sw = new StreamWriter("BeAllomany.txt");
            sw.WriteLine(db);
            {
                for (int i = 0; i < db; i++)
                {
                    sw.WriteLine(rnd.Next(1, 2001) + " " + rnd.Next(1, 2001));
                }
            }
            sw.Close();
        } //hogy ne nekem kelljen feltölteni egy txt-t
    }
}
