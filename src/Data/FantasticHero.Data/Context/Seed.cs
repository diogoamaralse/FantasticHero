using FantasticHero.Data.Adventure;
using Microsoft.EntityFrameworkCore;
using System;

namespace FantasticHero.Data.Context
{
    public class Seed
    {

        public Seed()
        {

        }
        public ModelBuilder GenerateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gamezone>().HasData(
                            new Gamezone
                            {
                                CoreObjectID = Guid.NewGuid(),
                                Option = 1,
                                ScenarioName = "Mars",
                                Height = 30,
                                Width = 50
                            },
                            new Gamezone
                            {
                                CoreObjectID = Guid.NewGuid(),
                                Option = 2,
                                ScenarioName = "Saturn",
                                Height = 25,
                                Width = 40
                            },
                            new Gamezone
                            {
                                CoreObjectID = Guid.NewGuid(),
                                Option = 3,
                                ScenarioName = "Jupiter",
                                Height = 50,
                                Width = 30
                            },
                            new Gamezone
                            {
                                CoreObjectID = Guid.NewGuid(),
                                Option = 4,
                                ScenarioName = "Uranus",
                                Height = 60,
                                Width = 60
                            }
                        );


            modelBuilder.Entity<HeroType>().HasData(
                new HeroType
                {
                    CoreObjectID = Guid.NewGuid(),
                    HeroTypeName = "Tragic"
                },
                new HeroType
                {
                    CoreObjectID = Guid.NewGuid(),
                    HeroTypeName = "Superhero"
                },
                new HeroType
                {
                    CoreObjectID = Guid.NewGuid(),
                    HeroTypeName = "Epic"
                }
            );


            modelBuilder.Entity<Hero>().HasData(
                new Hero
                {
                    CoreObjectID = Guid.NewGuid(),
                    Name = "Super Man",
                    Option = 1
                },
                new Hero
                {
                    CoreObjectID = Guid.NewGuid(),
                    Name = "Invisible Woman",
                    Option = 2
                },
                new Hero
                {
                    CoreObjectID = Guid.NewGuid(),
                    Name = "Allien",
                    Option = 3
                }
            );

            return modelBuilder;
        }
    }
}
