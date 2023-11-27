namespace SchoolOlx.Models
{
    public class Klasa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Ogloszenia> Ogloszenias { get; } = new List<Ogloszenia>();
        ICollection<Sprzedajacy> Sprzedajacys { get; } = new List<Sprzedajacy>();
    }
}
