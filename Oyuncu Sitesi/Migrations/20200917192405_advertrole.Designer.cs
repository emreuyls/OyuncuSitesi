﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.DataAccess.EntityFramework;

namespace Oyuncu_Sitesi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200917192405_advertrole")]
    partial class advertrole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web.Entity.Advert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GamesID")
                        .HasColumnType("int");

                    b.Property<string>("MinAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nick")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("GamesID");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("Web.Entity.AdvertRole", b =>
                {
                    b.Property<int>("AdvertID")
                        .HasColumnType("int");

                    b.Property<int>("RolesID")
                        .HasColumnType("int");

                    b.HasKey("AdvertID", "RolesID");

                    b.HasIndex("RolesID");

                    b.ToTable("AdvertRole");
                });

            modelBuilder.Entity("Web.Entity.GameRole", b =>
                {
                    b.Property<int>("GamesID")
                        .HasColumnType("int");

                    b.Property<int>("RolesID")
                        .HasColumnType("int");

                    b.HasKey("GamesID", "RolesID");

                    b.HasIndex("RolesID");

                    b.ToTable("GameRole");
                });

            modelBuilder.Entity("Web.Entity.GameTypes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Types")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("Web.Entity.Games", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Web.Entity.Roles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Web.Entity.Advert", b =>
                {
                    b.HasOne("Web.Entity.Games", "Games")
                        .WithMany()
                        .HasForeignKey("GamesID");
                });

            modelBuilder.Entity("Web.Entity.AdvertRole", b =>
                {
                    b.HasOne("Web.Entity.Advert", "Advert")
                        .WithMany("AdvertRoles")
                        .HasForeignKey("AdvertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Entity.Roles", "Roles")
                        .WithMany("AdvertRoles")
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web.Entity.GameRole", b =>
                {
                    b.HasOne("Web.Entity.Games", "Games")
                        .WithMany("GameRoles")
                        .HasForeignKey("GamesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Entity.Roles", "Roles")
                        .WithMany("GameRoles")
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
