namespace SPV.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //za lokacijo restavracije 
        public double X_coordinate { get; set; }
        public double Y_coordinate { get; set; }

        //ce je restavracija sploh odprta
        public double OpeningTime { get; set; }
        public double ClosingTime { get; set; }

        //ocena restavracije
        public int Ocena { get; set; }  

        //manjka se atribut za seznam hrane
        public string? FoodList { get; set; }
        public Restaurant() { }
    }
}
