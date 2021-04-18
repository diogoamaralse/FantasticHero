using FantasticHero.Data.Adventure;
using Microsoft.EntityFrameworkCore;

namespace FantasticHero.Data.Context
{
    public class GameContext : DbContext
    {
        public DbSet<Gamezone> GameZones { get; set; }
        public DbSet<Hero> Heros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\temp\FantasticHero.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed seed = new Seed();
            seed.GenerateSeed(modelBuilder);
        }


    }
}
