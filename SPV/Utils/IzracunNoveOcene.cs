using SPV.Models;

namespace SPV.Utils
{
    //class za izračun nove ocene
    public class Ocena
    {
        public int StaraOcena { get; private set; }
        public int NovaOcena { get; private set; }

        public Ocena(int staraOcena, int novaOcena)
        {
            StaraOcena = staraOcena;
            NovaOcena = novaOcena;
        }
    }

    public class IzracunNoveOcene
    {
        public static int IzracunOcene(int staraOcena, int novaOcena)
        {
            int koncnaOcena = (staraOcena + novaOcena) / 2;
            return koncnaOcena;
        }
    }
        


}
