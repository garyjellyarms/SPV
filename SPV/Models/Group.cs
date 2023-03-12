using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPV.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public DateTime Created { get; set; }

        private List<User> usersList = new List<User>();
        private List<Food> foodList = new List<Food>();
        public Dictionary<Food, double> FoodRating = new Dictionary<Food, double>();


        public static List<Group> Groups = new List<Group>();

        public List<User> Users
        {
            get { return usersList; }
            set { usersList = value; }
        }

        public List<Food> Foods
        {
            get { return foodList; }
            set { foodList = value; }
        }

        public Group() {
            Users = new List<User>();
            Foods = new List<Food>();
        }


        public void CreateNewGroup()
        {
            Guid = Guid.NewGuid();
            Created = DateTime.Now;

            Users = new List<User>();
            List<Food> FoodsTemp = new List<Food>();

            SelectFoodOptionsForGroup();
        }

        public void SelectFoodOptionsForGroup()
        {
            // 1. Od vseh uporabnikov pregledamo katera je njihova izbrana hrana
            
            // 2. Prešetejmo št. kolikokrat se pojavi katera opcija
            Dictionary<Food, int> keyValuePairs = new Dictionary<Food, int>();
            foreach(Food food in Foods)
            {

            }

            // 3. Upoštevamo tudi alergene
            CheckForAllergens();

            // 4. Izberemo katera se pojavi največkrat (če se pojavijo enakokrat uporabimo funkcijo random)



        }

        public void RateFoodOptions()
        {
            // Dobimo seznam(slovar) posameznega uporabnika kako je ocenil katero hrano

            foreach (KeyValuePair<Food, double> kvp in FoodRating)
            {

            }

            // Posodobimo povrečno oceno posamezne hrane/izbire

            // Če je kateri uporabil funckijo "Absolutno ne želi" kličemo funkcijo 'AbsolutelyDoesNotWantTo'
        }

        public void AbsolutelyDoesNotWantTo(int food_id)
        {
            // Izbrano hrano brišemo iz seznama 
            var hrana = Foods.Where(f => f.Id == food_id).FirstOrDefault();

            if (hrana != null)
            {
                Foods.Remove(hrana);
            }

            
        }

        public void CheckForAllergens()
        {
            // Preverimo alergene posameznikov v skupini glede njihovih zahtev za alergene

            throw new NotImplementedException();
        }


    }
}
