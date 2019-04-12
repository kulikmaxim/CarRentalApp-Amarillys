﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(CarRentalAppContext))]
    [Migration("20190331130119_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class");

                    b.Property<string>("Mark");

                    b.Property<string>("Model");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int>("ReleaseYear");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = "A",
                            Mark = "BMW",
                            Model = "X5",
                            RegistrationNumber = "d12e",
                            ReleaseYear = 1998
                        },
                        new
                        {
                            Id = 2,
                            Class = "B",
                            Mark = "Volkswagen",
                            Model = "B3",
                            RegistrationNumber = "d12e123",
                            ReleaseYear = 1991
                        },
                        new
                        {
                            Id = 3,
                            Class = "C",
                            Mark = "Reno",
                            Model = "Megane",
                            RegistrationNumber = "qwerty",
                            ReleaseYear = 2006
                        });
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("RentalBeginDate");

                    b.Property<DateTime>("RentalEndDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            Comment = "Some comment 1",
                            RentalBeginDate = new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RentalEndDate = new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            Comment = "Some comment 2",
                            RentalBeginDate = new DateTime(2019, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RentalEndDate = new DateTime(2019, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CarId = 3,
                            Comment = "Some comment 3",
                            RentalBeginDate = new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RentalEndDate = new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("DrivingLicenseNumber");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1977, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DrivingLicenseNumber = "123-abcd",
                            FirstName = "John",
                            LastName = "Wick"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1980, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DrivingLicenseNumber = "456-wert",
                            FirstName = "Vasya",
                            LastName = "Petrov"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1990, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DrivingLicenseNumber = "789-dsff",
                            FirstName = "Ivan",
                            LastName = "Ivanov"
                        });
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.HasOne("DAL.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}