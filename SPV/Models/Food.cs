namespace SPV.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public List<Alergen> Alergens { get; set; }
        public string OpisHrane { get; set; }

        public Food()
        {

        }
    }
}
