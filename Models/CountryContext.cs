using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "in", Name = "Indoor" },
                new Category { CategoryID = "ou", Name = "Outdoor" }
                );

            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "wo", Name = "Winter Olympics" },
                new Game { GameID = "so", Name = "Summer Olympics" },
                new Game { GameID = "pa", Name = "Paralympic Games" },
                new Game { GameID = "yog", Name = "Youth Olympic Games" }
                );

            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "can", Name = "Canada", CategoryID = "in", GameID = "wo", FlagImage = "canada.jpg" },
                new { CountryID = "swe", Name = "Sweden", CategoryID = "in", GameID = "wo", FlagImage = "sweden.jpg" },
                new { CountryID = "gb", Name = "Great Britain", CategoryID = "in", GameID = "wo", FlagImage = "great_britain.jpg" },
                new { CountryID = "jam", Name = "Jamaica", CategoryID = "ou", GameID = "wo", FlagImage = "jamaica.jpg" },
                new { CountryID = "ita", Name = "Italy", CategoryID = "ou", GameID = "wo", FlagImage = "italy.jpg" },
                new { CountryID = "jap", Name = "Japan", CategoryID = "ou", GameID = "wo", FlagImage = "japan.jpg" },
                new { CountryID = "ger", Name = "Germany", CategoryID = "in", GameID = "so", FlagImage = "germany.jpg" },
                new { CountryID = "chi", Name = "China", CategoryID = "in", GameID = "so", FlagImage = "china.jpg" },
                new { CountryID = "mex", Name = "Mexico", CategoryID = "in", GameID = "so", FlagImage = "mexico.jpg" },
                new { CountryID = "bra", Name = "Brazil", CategoryID = "ou", GameID = "so", FlagImage = "brazil.jpg" },
                new { CountryID = "net", Name = "Netherlands", CategoryID = "ou", GameID = "so", FlagImage = "netherlands.jpg" },
                new { CountryID = "usa", Name = "USA", CategoryID = "ou", GameID = "so", FlagImage = "united_states.jpg" },
                new { CountryID = "tha", Name = "Thailand", CategoryID = "in", GameID = "pa", FlagImage = "thailand.jpg" },
                new { CountryID = "uru", Name = "Uruguay", CategoryID = "in", GameID = "pa", FlagImage = "uruguay.jpg" },
                new { CountryID = "ukr", Name = "Ukraine", CategoryID = "in", GameID = "pa", FlagImage = "ukraine.jpg" },
                new { CountryID = "aus", Name = "Austria", CategoryID = "ou", GameID = "pa", FlagImage = "austria.jpg" },
                new { CountryID = "pak", Name = "Pakistan", CategoryID = "ou", GameID = "pa", FlagImage = "pakistan.jpg" },
                new { CountryID = "zim", Name = "Zimbabwe", CategoryID = "ou", GameID = "pa", FlagImage = "zimbabwe.jpg" },
                new { CountryID = "fra", Name = "France", CategoryID = "in", GameID = "yog", FlagImage = "france.jpg" },
                new { CountryID = "cyp", Name = "Cyprus", CategoryID = "in", GameID = "yog", FlagImage = "cyprus.jpg" },
                new { CountryID = "rus", Name = "Russia", CategoryID = "in", GameID = "yog", FlagImage = "russia.jpg" },
                new { CountryID = "fin", Name = "Finland", CategoryID = "ou", GameID = "yog", FlagImage = "finland.jpg" },
                new { CountryID = "slo", Name = "Slovakia", CategoryID = "ou", GameID = "yog", FlagImage = "slovakia.jpg" },
                new { CountryID = "por", Name = "Portugal", CategoryID = "ou", GameID = "yog", FlagImage = "portugal.jpg" }
                );
        }
    }
}
