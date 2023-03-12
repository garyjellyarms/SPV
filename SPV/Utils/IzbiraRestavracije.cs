using SPV.Models;
using Newtonsoft.Json;

namespace SPV.Utils
{
    public class IzbiraRestavracije
    {
        PreverjanjeOdprtostiRestavracije preverjanjeOdprtostiRestavracije = new PreverjanjeOdprtostiRestavracije();
        
        public List<Restaurant> UstrezneRestavracije(List<Restaurant> vseRestavracije, Food izbranaHrana)
        {
            //pripravimo se en seznam na katerga damo vse restavracije ki se ujemajo
            List<Restaurant> ustrezneRestavracije = new List<Restaurant>(); 
            //koncni seznam 


            //pregledamo vse restavracije 
            foreach (Restaurant restaurant in vseRestavracije)
            {
                //preberemo vse hrane ki jih ima restavracija
                string jsonString = restaurant.FoodList;
                List<Food> seznamHrane = JsonConvert.DeserializeObject<List<Food>>(jsonString);

                //gremo cez vso hrano v restavraciji
                foreach(Food hrana in seznamHrane)
                {
                    //ce se pojavi hrana na seznamu hrane v restavraciji
                    if (hrana == izbranaHrana)
                    {
                        //pregledam odprtost restavracije 
                        if (preverjanjeOdprtostiRestavracije.Odprtost(restaurant) == true)
                        {
                            //preverim lokacijo
                            ustrezneRestavracije.Add(restaurant);
                        }
                        //pregledam lokacijo 
                    }
                }

            }

            return ustrezneRestavracije;
        }
    }
}
