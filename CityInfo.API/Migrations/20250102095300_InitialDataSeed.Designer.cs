﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(ApplicantInfoContext))]
    [Migration("20250102095300_InitialDataSeed")]
    partial class InitialDataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CityInfo.API.Entities.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Vrn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Applicants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "tegan.o'connor@informed.com",
                            Name = "Tegan O'Connor",
                            Vrn = 123
                        });
                });
#pragma warning restore 612, 618
        }
    }
}