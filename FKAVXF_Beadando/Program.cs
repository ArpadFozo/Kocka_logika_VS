using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FKAVXF_Beadando
{
    class Program
    {
        static Random rnd = new Random();

        static AlapTxtBeolv[] BeAllomanyBeolvas()
        {
            StreamReader sr = new StreamReader("BeAllomany.txt");
            AlapTxtBeolv[] tomb=AlapTxtBeolv.Beolv(sr);
            sr.Close();
            return tomb;
        }//Beolvassa a létrehozott állományt
        static void KiiratAlap(AlapTxtBeolv[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i].Adatok();
            }
        }//A program készítése közben kellett ,hogy lehessen látni konzolon ,hogy mit csinál a program
        static void KiiratRendezett(SorbaTxtLetre[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i].Adatok();
            }
        }//A program készítése közben kellett ,hogy lehessen látni konzolon ,hogy mit csinál a program
        static SorbaTxtLetre[] RendezesHossz(AlapTxtBeolv[] tomb)
        {
            SorbaTxtLetre seged;
            SorbaTxtLetre[] kiiratniValo = new SorbaTxtLetre[tomb.Length];
            //bemeneti tömb értékadása a kimeneti tömbnek
            for (int i = 0; i < tomb.Length; i++)
            {
                kiiratniValo[i] = new SorbaTxtLetre(tomb[i].Hossz, tomb[i].Suly);
            }

            for (int i = 0; i < tomb.Length; i++)
            {
                for (int j = 0; j < tomb.Length; j++)
                {
                    if (kiiratniValo[i].Hossz>kiiratniValo[j].Hossz)
                    {
                        seged = kiiratniValo[i];
                        kiiratniValo[i] = kiiratniValo[j];
                        kiiratniValo[j] = seged;
                    }
                }
            }
            return kiiratniValo;
        }//Sorba rendezi az alaptömböt hossz alapján
        static SorbaTxtLetre[] RendezesSuly(AlapTxtBeolv[] tomb)
        {
            SorbaTxtLetre seged;
            SorbaTxtLetre[] kiiratniValo = new SorbaTxtLetre[tomb.Length];
            //bemeneti tömb értékadása a kimeneti tömbnek
            for (int i = 0; i < tomb.Length; i++)
            {
                kiiratniValo[i] = new SorbaTxtLetre(tomb[i].Hossz, tomb[i].Suly);
            }

            for (int i = 0; i < tomb.Length; i++)
            {
                for (int j = 0; j < tomb.Length; j++)
                {
                    if (kiiratniValo[i].Suly > kiiratniValo[j].Suly)
                    {
                        seged = kiiratniValo[i];
                        kiiratniValo[i] = kiiratniValo[j];
                        kiiratniValo[j] = seged;
                    }
                }
            }
            return kiiratniValo;
        }//Sorba rendezi az alaptömböt súly alapján
        static SorbaTxtLetre[] RendezesVegeHossz(SorbaTxtLetre[] tomb)
        {
            for (int i = 0; i < tomb.Length-1; i++)
            {
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[i].Suly<tomb[j].Suly)
                    {
                        tomb[j] = tomb[i];
                    }
                }
            }
            return tomb;
        }//A hossz alapján sorbarendezett tömbben kitörli azokat a kockákat amelyeknek nagyobb a súlyuk mint az előzőnek
        static SorbaTxtLetre[] RendezesVegeSuly(SorbaTxtLetre[] tomb)
        {
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[i].Hossz < tomb[j].Hossz || tomb[i].Hossz == tomb[j].Hossz)
                    {
                        tomb[j] = tomb[i];
                    }
                }
            }
            return tomb;
        }//A hossz alapján sorbarendezett tömbben kitörli azokat a kockákat amelyeknek nagyobb a hosszuk mint az előzőnek
        static SorbaTxtLetre[] IsmKiszur(SorbaTxtLetre[] tomb)
        {
            int db = 0;
            int j = 0;
            SorbaTxtLetre[] seged = new SorbaTxtLetre[tomb.Length];
            seged[db] = tomb[0];
            for (int i = 0; i < tomb.Length; i++)
            {
                while (seged[i] == tomb[j]&&j<tomb.Length-1)
                {
                    j++;
                }
                if (db < tomb.Length-1)
                {
                    db++;
                }
                seged[db] = tomb[j];
            }
            return seged;
        }//A tömbben kiszűri az ismétlődéseket
        static int IsmKiszurDb(SorbaTxtLetre[] tomb)
        {
            int i = 0;
            int db = 0;
            while (tomb[i]!=tomb[i+1]&&i<tomb.Length-1)
            {
                i++;
                db++;
            }
            return db+1;
        }//Visszaadja a torony magasságát, megszámlálja hány ismétlődés nélküli elem van a tömbben
        static bool MelyikHosszabb(AlapTxtBeolv[] tomb)
        {
            if(IsmKiszurDb(IsmKiszur(RendezesVegeSuly(RendezesSuly(tomb)))) > IsmKiszurDb(IsmKiszur(RendezesVegeHossz(RendezesHossz(tomb)))))
            {
                return true;//ha true Suly alapján rendezett a magasabb
            }
            else
            {
                return false;//ha false a Hossz alapján rendezett magasabb
            }
        } //Eldönti a hossz alapján rendezett vagy a súly alapján rendezett tömbből lehet nagyobb tornyot építeni
        static void Kiirat(AlapTxtBeolv[] tomb)
        {
            SorbaTxtLetre [] sulyAlapjan= IsmKiszur(RendezesVegeSuly(RendezesSuly(tomb)));
            SorbaTxtLetre[] hosszAlapjan = IsmKiszur(RendezesVegeHossz(RendezesHossz(tomb)));
            if (MelyikHosszabb(tomb))
            {
                StreamWriter sw = new StreamWriter("Eredmeny.txt");
                sw.WriteLine(IsmKiszurDb(IsmKiszur(RendezesVegeSuly(RendezesSuly(tomb)))));
                for (int i = 0; i < IsmKiszurDb(IsmKiszur(RendezesVegeSuly(RendezesSuly(tomb)))); i++)
                {
                    sw.WriteLine(sulyAlapjan[i].Hossz + " " + sulyAlapjan[i].Suly);
                }
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter("Eredmeny.txt");
                sw.WriteLine(IsmKiszurDb(IsmKiszur(RendezesVegeHossz(RendezesHossz(tomb)))));
                for (int i = 0; i < IsmKiszurDb(IsmKiszur(RendezesVegeHossz(RendezesHossz(tomb)))); i++)
                {
                    sw.WriteLine(hosszAlapjan[i].Hossz + " " +  hosszAlapjan[i].Suly);
                }
                sw.Close();
            }
        }//A MelyikHosszabb metódus alapján eldönti melyik tömböt irassa ki txt-be
        static void Main(string[] args)
        {
            TxtLetre.BeAllomanyLetrehozas();
            AlapTxtBeolv[] tomb = BeAllomanyBeolvas();
            Kiirat(tomb);
            //Console.ReadLine();
        }
    }
}
