﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerManager.Client.Data;

namespace SoccerManager.Client.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230627110007_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("SoccerManager.Client.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("SoccerManager.Client.Models.Fan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fans");
                });

            modelBuilder.Entity("SoccerManager.Client.Models.FanClub", b =>
                {
                    b.Property<int>("FanId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FanId", "ClubId");

                    b.HasIndex("ClubId");

                    b.ToTable("FanClubs");
                });

            modelBuilder.Entity("SoccerManager.Client.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClubId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Snils")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("ClubId1");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SoccerManager.Client.Models.FanClub", b =>
                {
                    b.HasOne("SoccerManager.Client.Models.Club", "Club")
                        .WithMany("FanClubs")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoccerManager.Client.Models.Fan", "Fan")
                        .WithMany("FanClubs")
                        .HasForeignKey("FanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoccerManager.Client.Models.Player", b =>
                {
                    b.HasOne("SoccerManager.Client.Models.Club", null)
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoccerManager.Client.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId1");
                });
#pragma warning restore 612, 618
        }
    }
}
