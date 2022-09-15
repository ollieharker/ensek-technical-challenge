﻿// <auto-generated />
using System;
using Ensek.TechnicalTest.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ensek.TechnicalTest.Db.Migrations
{
    [DbContext(typeof(EnsekDbContext))]
    partial class EnsekDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ensek.TechnicalTest.Db.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 2344,
                            FirstName = "Tommy",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2233,
                            FirstName = "Barry",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 8766,
                            FirstName = "Sally",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2345,
                            FirstName = "Jerry",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2346,
                            FirstName = "Ollie",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2347,
                            FirstName = "Tara",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2348,
                            FirstName = "Tammy",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2349,
                            FirstName = "Simon",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2350,
                            FirstName = "Colin",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2351,
                            FirstName = "Gladys",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2352,
                            FirstName = "Greg",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2353,
                            FirstName = "Tony",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2355,
                            FirstName = "Arthur",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 2356,
                            FirstName = "Craig",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 6776,
                            FirstName = "Laura",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 4534,
                            FirstName = "JOSH",
                            LastName = "TEST"
                        },
                        new
                        {
                            Id = 1234,
                            FirstName = "Freya",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1239,
                            FirstName = "Noddy",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1240,
                            FirstName = "Archie",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1241,
                            FirstName = "Lara",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1242,
                            FirstName = "Tim",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1243,
                            FirstName = "Graham",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1244,
                            FirstName = "Tony",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1245,
                            FirstName = "Neville",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1246,
                            FirstName = "Jo",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1247,
                            FirstName = "Jim",
                            LastName = "Test"
                        },
                        new
                        {
                            Id = 1248,
                            FirstName = "Pam",
                            LastName = "Test"
                        });
                });

            modelBuilder.Entity("Ensek.TechnicalTest.Db.Models.MeterReading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("MeterReadings");
                });

            modelBuilder.Entity("Ensek.TechnicalTest.Db.Models.MeterReading", b =>
                {
                    b.HasOne("Ensek.TechnicalTest.Db.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
