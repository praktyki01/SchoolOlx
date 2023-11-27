namespace SchoolOlx.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string NazwaKategori { get; set; }
        ICollection<Ogloszenia> Ogloszenias { get; } = new List<Ogloszenia>();
    }
}
