using SPV.Models;

namespace SPV.Utils
{
    public class PreverjanjeOdprtostiRestavracije
    {

        public bool Odprtost(Restaurant restaurant)
        {
            DateTime TrenutniCas = DateTime.Now;
            TimeSpan time = TrenutniCas.TimeOfDay;

            //dobimo double za primerjat
            double hour = time.TotalHours;

            //preverimo ce je cas sploh vnesen 
            if(restaurant.OpeningTime == 0 || restaurant.OpeningTime == null )
            {
                return false;
            }
            else if (restaurant.ClosingTime == 0 || restaurant.ClosingTime == null)
            {
                return false;
            }

            //preverimo ker del dneva je 
            if(hour < 4.30)
            {
                if (restaurant.OpeningTime > hour && restaurant.ClosingTime > hour)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(hour > 4.30)
            {
                if (restaurant.OpeningTime < hour && restaurant.ClosingTime > hour)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(hour == 4.30)
            {
                if (restaurant.OpeningTime > hour && restaurant.ClosingTime > hour)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
            


        }
    }
}
