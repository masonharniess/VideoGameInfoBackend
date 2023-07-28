﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameInfo.API.DbContexts;

#nullable disable

namespace VideoGameInfo.API.Migrations
{
    [DbContext(typeof(VideoGameInfoContext))]
    partial class VideoGameInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("VideoGameInfo.API.Entities.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Naughty Dog, LLC (formerly JAM Software, Inc.) is an American first-party video game developer based in Santa Monica, California.",
                            Name = "Naughty Dog"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Rockstar North Limited (formerly DMA Design Limited) is a British video game development company and a studio of Rockstar Games based in Edinburgh.",
                            Name = "Rockstar North"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Konami Group Corporation, commonly known as Konami, is a Japanese multinational video game and entertainment company headquartered in Chūō, Tokyo.",
                            Name = "Konami"
                        });
                });

            modelBuilder.Entity("VideoGameInfo.API.Entities.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Last of Us Part II is a 2020 action-adventure game developed by Naughty Dog and published by Sony Interactive Entertainment for the PlayStation 4.",
                            DeveloperId = 1,
                            Title = "The Last of Us Part I"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Uncharted 4: A Thief's End is a 2016 action-adventure game developed by Naughty Dog and published by Sony Computer Entertainment.",
                            DeveloperId = 1,
                            Title = "Uncharted 4: A Thief's End"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games.",
                            DeveloperId = 2,
                            Title = "Grand Theft Auto V"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games.",
                            DeveloperId = 2,
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Metal Gear Solid is an action-adventure stealth video game developed and published by Konami for the PlayStation in 1998.",
                            DeveloperId = 3,
                            Title = "Metal Gear Solid"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Silent Hill is a 1999 survival horror game developed by Team Silent and published by Konami.",
                            DeveloperId = 3,
                            Title = "Silent Hill"
                        });
                });

            modelBuilder.Entity("VideoGameInfo.API.Entities.VideoGame", b =>
                {
                    b.HasOne("VideoGameInfo.API.Entities.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("VideoGameInfo.API.Entities.Developer", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}