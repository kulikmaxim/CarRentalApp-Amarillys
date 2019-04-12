using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Wick",
                    BirthDate = new DateTime(1977, 10, 12),
                    DrivingLicenseNumber = "123-abcd"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Vasya",
                    LastName = "Petrov",
                    BirthDate = new DateTime(1980, 4, 19),
                    DrivingLicenseNumber = "456-wert"
                }, 
                new User
                {
                    Id = 3,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    BirthDate = new DateTime(1990, 7, 27),
                    DrivingLicenseNumber = "789-dsff"
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Class = "A",
                    Mark = "BMW",
                    Model = "X5",
                    RegistrationNumber = "d12e",
                    ReleaseYear = 1998
                },
                new Car
                {
                    Id = 2,
                    Class = "B",
                    Mark = "Volkswagen",
                    Model = "B3",
                    RegistrationNumber = "d12e123",
                    ReleaseYear = 1991
                },
                new Car
                {
                    Id = 3,
                    Class = "C",
                    Mark = "Reno",
                    Model = "Megane",
                    RegistrationNumber = "qwerty",
                    ReleaseYear = 2006
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CarId = 1,
                    UserId = 1,
                    Comment = "Some comment 1",
                    RentalBeginDate = new DateTime(2019, 1, 26),
                    RentalEndDate = new DateTime(2019, 2, 1)
                },
                new Order
                {
                    Id = 2,
                    CarId = 2,
                    UserId = 2,
                    Comment = "Some comment 2",
                    RentalBeginDate = new DateTime(2019, 2, 13),
                    RentalEndDate = new DateTime(2019, 2, 14)
                },
                new Order
                {
                    Id = 3,
                    CarId = 3,
                    UserId = 3,
                    Comment = "Some comment 3",
                    RentalBeginDate = new DateTime(2019, 3, 26),
                    RentalEndDate = new DateTime(2019, 3, 30)
                }
            );
        }
    }
}
