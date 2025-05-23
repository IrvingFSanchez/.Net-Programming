﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PokeDudesApp.Migrations
{
    [DbContext(typeof(PokeDbContext))]
    [Migration("20250501063906_RecreateInitial")]
    partial class RecreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokeDudesApp.Models.PokeDude", b =>
                {
                    b.Property<int>("PokeDudeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokeDudeId"));

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PokeDudeId");

                    b.ToTable("PokeDudes");
                });

            modelBuilder.Entity("PokeDudesApp.Models.PokePal", b =>
                {
                    b.Property<int>("PokePalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokePalId"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokeDudeId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PokePalId");

                    b.HasIndex("PokeDudeId");

                    b.ToTable("PokePals");
                });

            modelBuilder.Entity("PokeDudesApp.Models.PokePal", b =>
                {
                    b.HasOne("PokeDudesApp.Models.PokeDude", "PokeDude")
                        .WithMany("PokePals")
                        .HasForeignKey("PokeDudeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokeDude");
                });

            modelBuilder.Entity("PokeDudesApp.Models.PokeDude", b =>
                {
                    b.Navigation("PokePals");
                });
#pragma warning restore 612, 618
        }
    }
}
