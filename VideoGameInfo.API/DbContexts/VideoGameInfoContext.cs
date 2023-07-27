using Microsoft.EntityFrameworkCore;
using VideoGameInfo.API.Entities;

namespace VideoGameInfo.API.DbContexts
{
    public class VideoGameInfoContext : DbContext
    {
        public VideoGameInfoContext(DbContextOptions<VideoGameInfoContext> options) : base(options) { }

        public DbSet<Developer> Developers { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasData(
                new Developer("Naughty Dog")
                {
                    Id = 1,
                    Description = "Naughty Dog, LLC (formerly JAM Software, Inc.) is an American " +
                    "first-party video game developer based in Santa Monica, California."
                },
                new Developer("Rockstar North")
                {
                    Id = 2, 
                    Description = "Rockstar North Limited (formerly DMA Design Limited) is a British " +
                    "video game development company and a studio of Rockstar Games based in Edinburgh."
                },
                new Developer("Konami")
                {
                    Id = 3,
                    Description = "Konami Group Corporation, commonly known as Konami, is a Japanese " +
                    "multinational video game and entertainment company headquartered in Chūō, Tokyo."
                }
                );

            modelBuilder.Entity<Game>().HasData(
                new Game("The Last of Us Part I")
                {
                    Id = 1,
                    DeveloperId = 1,
                    Description = "The Last of Us Part II is a 2020 action-adventure game developed by " +
                    "Naughty Dog and published by Sony Interactive Entertainment for the PlayStation 4."
                },
                new Game("Uncharted 4: A Thief's End")
                {
                    Id = 2,
                    DeveloperId = 1,
                    Description = "Uncharted 4: A Thief's End is a 2016 action-adventure game developed " +
                    "by Naughty Dog and published by Sony Computer Entertainment."
                },
                new Game("Grand Theft Auto V")
                {
                    Id = 3,
                    DeveloperId = 2,
                    Description = "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar " +
                    "North and published by Rockstar Games."
                },
                new Game("Red Dead Redemption 2")
                {
                    Id = 4,
                    DeveloperId = 2,
                    Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and " +
                    "published by Rockstar Games."
                },
                new Game("Metal Gear Solid")
                {
                    Id = 5,
                    DeveloperId = 3,
                    Description = "Metal Gear Solid is an action-adventure stealth video game developed " +
                    "and published by Konami for the PlayStation in 1998."
                },
                new Game("Silent Hill")
                {
                    Id = 6,
                    DeveloperId = 3,
                    Description = "Silent Hill is a 1999 survival horror game developed by Team Silent " +
                    "and published by Konami."
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
