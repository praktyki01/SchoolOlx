namespace SchoolOlx.Models
{
    public class Sprzedajacy
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int KlasaId { get; set; }
        public Klasa? Klasa { get; set; } = null!;
        public string DaneKontaktowe { get; set; }
        ICollection<Ogloszenia> Ogloszenias { get; } = new List<Ogloszenia>();
    }
}
