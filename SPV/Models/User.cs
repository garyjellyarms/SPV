namespace SVP_BackEnd.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username{ get; set; }
        public string? Password { get; set; }
        public DateTime TimeCreated { get; set; }
        public string? Salt { get; set; }

    }

    class Uporabnik
    {
        public int Id_uporabnika { get; set; }
        public string? Uporabnisko_ime { get; set; }
        public string? Uporabnisko_geslo { get; set; }
        public string? Ime_uporabnika { get; set; }
        public string? Priimek_uporabnika { get; set; }
        public string? Email_uporabnika { get; set; }
        public DateTime? Nastanek_uporabnika { get; set; }
        public string? Salt_uporabnika { get; set; }

    }

    class Restavracije
    {
        public int Id_restavracije { get; set; }
        public string? Ime_restavracije { get; set; }

        //za lokacijo restavracije 
        public double X_kordinata { get; set; }
        public double Y_kordinata { get; set; }

        //ce je restavracija sploh odprta
        public double Odprto_od { get; set; }
        public double Odprto_do { get; set; }

        //manjka se atribut za seznam hrane
        public string Seznam_hrane { get; set; }
    }

    class Hrana
    {
        public int Id_hrane { get; set; }
        public string Slika_hrane { get; set; }
        public string Ime_hrane { get; set; }
    }
}
