namespace SchoolOlx.Models
{
    public class Stan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Ogloszenia> Ogloszenias { get; } = new List<Ogloszenia>();
    }
}
