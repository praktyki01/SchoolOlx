using System;

namespace SchoolOlx.Models
{
    public class Ogloszenia
    {
        public int Id { get; set; }
        public string NazwaOgloszenia { get; set; }
        public string Opis { get; set; }

        public int StanId { get; set; }
        public Stan? Stan { get; set; } = null!;

        public string Zdjecie { get; set; }

        public float Cena { get; set; }

        public int KlasaId { get; set; }
        public Klasa? Klasa { get; set; } = null!;

        public int KategoriaId { get; set; }
        public Kategoria? Kategoria { get; set; } = null!;

        public int WydawnictwoId { get; set; }
        public Wydawnictwo? Wydawnictwo { get; set; } = null!;

        public int SprzedajacyId { get; set; }
        public Sprzedajacy? Sprzedajacy { get; set; } = null!;
    }
}
