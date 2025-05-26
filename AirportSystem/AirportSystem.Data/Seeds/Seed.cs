using System;
using System.Collections.Generic;
using AirportSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportSystem.Data.Seeds
{
    public static class Seed
    {
        public static readonly DateTimeOffset BaseDate = new DateTimeOffset(2025, 4, 8, 10, 55, 0, TimeSpan.Zero);
        public static readonly DateTimeOffset Tomorrow = BaseDate.AddDays(1);
        public static readonly DateTimeOffset NextWeek = BaseDate.AddDays(7);

        // Seed data collections
        public static List<Continent> Continents = new List<Continent>
        {
            new Continent { Id = 1, ContinentName = "Europe", CreatedAt = BaseDate },
            new Continent { Id = 2, ContinentName = "North America", CreatedAt = BaseDate },
            new Continent { Id = 3, ContinentName = "Asia", CreatedAt = BaseDate }
        };

        public static List<Country> Countries = new List<Country>
        {
            new Country { Id = 1, CountryName = "United Kingdom", ContinentId = 1, CreatedAt = BaseDate },
            new Country { Id = 2, CountryName = "United States", ContinentId = 2, CreatedAt = BaseDate },
            new Country { Id = 3, CountryName = "Japan", ContinentId = 3, CreatedAt = BaseDate },
            new Country { Id = 4, CountryName = "Germany", ContinentId = 1, CreatedAt = BaseDate }
        };

        public static List<City> Cities = new List<City>
        {
            new City { Id = 1, CityName = "London", CountryId = 1, CreatedAt = BaseDate },
            new City { Id = 2, CityName = "New York", CountryId = 2, CreatedAt = BaseDate },
            new City { Id = 3, CityName = "Tokyo", CountryId = 3, CreatedAt = BaseDate },
            new City { Id = 4, CityName = "Berlin", CountryId = 4, CreatedAt = BaseDate },
            new City { Id = 5, CityName = "Los Angeles", CountryId = 2, CreatedAt = BaseDate }
        };

        public static List<Airport> Airports = new List<Airport>
        {
            new Airport { Id = 1, AirportName = "Heathrow Airport", CityId = 1, CreatedAt = BaseDate },
            new Airport { Id = 2, AirportName = "JFK International Airport", CityId = 2, CreatedAt = BaseDate },
            new Airport { Id = 3, AirportName = "Narita International Airport", CityId = 3, CreatedAt = BaseDate },
            new Airport { Id = 4, AirportName = "Berlin Brandenburg Airport", CityId = 4, CreatedAt = BaseDate },
            new Airport { Id = 5, AirportName = "LAX", CityId = 5, CreatedAt = BaseDate }
        };

        public static List<Airplane> Airplanes = new List<Airplane>
        {
            new Airplane { Id = 1, SeatsCount = 150, CreatedAt = BaseDate },
            new Airplane { Id = 2, SeatsCount = 200, CreatedAt = BaseDate },
            new Airplane { Id = 3, SeatsCount = 300, CreatedAt = BaseDate }
        };

        public static List<FlightStatus> FlightStatuses = new List<FlightStatus>
        {
            new FlightStatus { Id = 1, Status = "Scheduled", CreatedAt = BaseDate },
            new FlightStatus { Id = 2, Status = "Boarding", CreatedAt = BaseDate },
            new FlightStatus { Id = 3, Status = "Departed", CreatedAt = BaseDate },
            new FlightStatus { Id = 4, Status = "In Air", CreatedAt = BaseDate },
            new FlightStatus { Id = 5, Status = "Landed", CreatedAt = BaseDate },
            new FlightStatus { Id = 6, Status = "Delayed", CreatedAt = BaseDate },
            new FlightStatus { Id = 7, Status = "Cancelled", CreatedAt = BaseDate }
        };

        public static List<Role> Roles = new List<Role>
        {
            new Role { Id = 1, RoleName = "Pilot", CreatedAt = BaseDate },
            new Role { Id = 2, RoleName = "Co-Pilot", CreatedAt = BaseDate },
            new Role { Id = 3, RoleName = "Flight Attendant", CreatedAt = BaseDate },
            new Role { Id = 4, RoleName = "Air Marshal", CreatedAt = BaseDate }
        };

        public static List<Crew> Crews = new List<Crew>
        {
            new Crew { Id = 1, Name = "John Smith", RoleId = 1, CreatedAt = BaseDate },
            new Crew { Id = 2, Name = "Jane Doe", RoleId = 2, CreatedAt = BaseDate },
            new Crew { Id = 3, Name = "Mike Johnson", RoleId = 3, CreatedAt = BaseDate },
            new Crew { Id = 4, Name = "Sarah Williams", RoleId = 3, CreatedAt = BaseDate },
            new Crew { Id = 5, Name = "Robert Brown", RoleId = 4, CreatedAt = BaseDate }
        };

        public static List<Flight> Flights = new List<Flight>
        {
            new Flight { 
                Id = 1, 
                FlightDuration = 480, // in minutes
                FlightDate = Tomorrow,
                PassengerCount = 120,
                AirplaneId = 1,
                CreatedAt = BaseDate
            },
            new Flight { 
                Id = 2, 
                FlightDuration = 720, // in minutes
                FlightDate = Tomorrow.AddHours(6),
                PassengerCount = 180,
                AirplaneId = 2,
                CreatedAt = BaseDate
            },
            new Flight { 
                Id = 3, 
                FlightDuration = 600, // in minutes
                FlightDate = NextWeek,
                PassengerCount = 250,
                AirplaneId = 3,
                CreatedAt = BaseDate
            }
        };

        public static List<FlightStatusChange> FlightStatusChanges = new List<FlightStatusChange>
        {
            new FlightStatusChange { 
                Id = 1, 
                FlightId = 1, 
                FlightStatusId = 1, 
                ChangedAt = new DateTime(2025,04,04),
                CreatedAt = BaseDate
            },
            new FlightStatusChange { 
                Id = 2, 
                FlightId = 2, 
                FlightStatusId = 1, 
                ChangedAt = new DateTime(2025,04,04),
                CreatedAt = BaseDate
            },
            new FlightStatusChange { 
                Id = 3, 
                FlightId = 3, 
                FlightStatusId = 6, 
                ChangedAt = new DateTime(2025,04,04),
                CreatedAt = BaseDate
            }
        };

        public static List<Passenger> Passengers = new List<Passenger>
        {
            new Passenger { Id = 1, Name = "Alice Johnson", CreatedAt = BaseDate },
            new Passenger { Id = 2, Name = "Bob Williams", CreatedAt = BaseDate },
            new Passenger { Id = 3, Name = "Charlie Davis", CreatedAt = BaseDate },
            new Passenger { Id = 4, Name = "Diana Miller", CreatedAt = BaseDate },
            new Passenger { Id = 5, Name = "Edward Wilson", CreatedAt = BaseDate }
        };

        public static List<Ticket> Tickets = new List<Ticket>
        {
            new Ticket { 
                Id = 1, 
                TicketPrice = 350.00M, 
                Type = "Economy", 
                SeatNumber = 15, 
                PaymentSuccess = true,
                FlightId = 1,
                PassengerId = 1,
                CreatedAt = BaseDate
            },
            new Ticket { 
                Id = 2, 
                TicketPrice = 750.00M, 
                Type = "Business", 
                SeatNumber = 3, 
                PaymentSuccess = true,
                FlightId = 1,
                PassengerId = 2,
                CreatedAt = BaseDate
            },
            new Ticket { 
                Id = 3, 
                TicketPrice = 450.00M, 
                Type = "Economy", 
                SeatNumber = 22, 
                PaymentSuccess = true,
                FlightId = 2,
                PassengerId = 3,
                CreatedAt = BaseDate
            },
            new Ticket { 
                Id = 4, 
                TicketPrice = 1250.00M, 
                Type = "First Class", 
                SeatNumber = 1, 
                PaymentSuccess = true,
                FlightId = 3,
                PassengerId = 4,
                CreatedAt = BaseDate
            },
            new Ticket { 
                Id = 5, 
                TicketPrice = 495.00M, 
                Type = "Economy Plus", 
                SeatNumber = 10, 
                PaymentSuccess = false,
                FlightId = 3,
                PassengerId = 5,
                CreatedAt = BaseDate
            }
        };

        public static List<Payroll> Payrolls = new List<Payroll>
        {
            new Payroll { 
                Id = 1, 
                Total = 350.00, 
                PassengerId = 1, 
                TicketId = 1,
                CreatedAt = BaseDate
            },
            new Payroll { 
                Id = 2, 
                Total = 750.00, 
                PassengerId = 2, 
                TicketId = 2,
                CreatedAt = BaseDate
            },
            new Payroll { 
                Id = 3, 
                Total = 450.00, 
                PassengerId = 3, 
                TicketId = 3,
                CreatedAt = BaseDate
            },
            new Payroll { 
                Id = 4, 
                Total = 1250.00, 
                PassengerId = 4, 
                TicketId = 4,
                CreatedAt = BaseDate
            }
        };
        public static void SeedAllData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>().HasData(Continents);
            modelBuilder.Entity<Country>().HasData(Countries);
            modelBuilder.Entity<City>().HasData(Cities);
            modelBuilder.Entity<Airport>().HasData(Airports);
            modelBuilder.Entity<Airplane>().HasData(Airplanes);
            modelBuilder.Entity<FlightStatus>().HasData(FlightStatuses);
            modelBuilder.Entity<Role>().HasData(Roles);
            modelBuilder.Entity<Crew>().HasData(Crews);
            modelBuilder.Entity<Flight>().HasData(Flights);
            modelBuilder.Entity<FlightStatusChange>().HasData(FlightStatusChanges);
            modelBuilder.Entity<Passenger>().HasData(Passengers);
            modelBuilder.Entity<Ticket>().HasData(Tickets);
            modelBuilder.Entity<Payroll>().HasData(Payrolls);
        }
    }
} 