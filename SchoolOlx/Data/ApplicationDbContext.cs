using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolOlx.Models;

namespace SchoolOlx.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SchoolOlx.Models.Sprzedajacy>? Sprzedajacy { get; set; }
        public DbSet<SchoolOlx.Models.Kategoria>? Kategoria { get; set; }
        public DbSet<SchoolOlx.Models.Klasa>? Klasa { get; set; }
        public DbSet<SchoolOlx.Models.Ogloszenia>? Ogloszenia { get; set; }
        public DbSet<SchoolOlx.Models.Stan>? Stan { get; set; }
        public DbSet<SchoolOlx.Models.Wydawnictwo>? Wydawnictwo { get; set; }

    }
}