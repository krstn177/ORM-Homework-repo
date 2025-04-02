using Cars.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Seed
{
    public class Seeder
    {
        private static List<Fuel> fuelsList = new List<Fuel>()
        {
            new Fuel()
            {
                Id = 1,
                Type = "Diesel"
            },
            new Fuel()
            {
                Id = 2,
                Type = "Petrol"
            },
            new Fuel()
            {
                Id = 3,
                Type = "Hybrid"
            },
        };
        private static List<Engine> enginesList = new List<Engine>()
        {
            new Engine()
            {
                Id = 1,
                Name = "BMW N45B16",
                MaxRPM = 90,
                HorsePower = 122,
                FuelId = fuelsList[0].Id
            },
            new Engine
            {
                Id = 2,
                Name = "Audi 2.0 TDI",
                MaxRPM = 110,
                HorsePower = 150,
                FuelId = fuelsList[1].Id
            },
            new Engine
            {
                Id = 3,
                Name = "Toyota 1.8 VVT-i Hybrid",
                MaxRPM = 72,
                HorsePower = 122,
                FuelId = fuelsList[2].Id
            }
        };


        private static List<Car> carsList = new List<Car>()
        {
            new Car()
            {
                Id = 1,
                YearOfManufacture = 2006,
                Name = "BMW"
                
            },
            new Car
            {
                Id = 2,
                YearOfManufacture = 2015,
                Name = "Audi"
            },
            new Car
            {
                Id = 3,
                YearOfManufacture = 2020,
                Name = "Toyota"
            }
        };

        private static List<Model> modelsList = new List<Model>()
        {
            new Model
            {
                Id = 1,
                Name = "116i",
                MaxSpeed = 210,
                Weight = 1280,
                Length = 4200,
                CarId = carsList[0].Id
            },
            new Model
            {
                Id = 2,
                Name = "A4",
                MaxSpeed = 250,
                Weight = 1420,
                Length = 4700,
                CarId = carsList[1].Id
            },
            new Model
            {
                Id = 3,
                MaxSpeed = 180,
                Weight = 1340,
                Length = 4350,
                Name = "Corolla",
                CarId = carsList[2].Id
            }
        };

        private static List<CarEngine> carEnginesList = new List<CarEngine>()
        {
            new CarEngine
            {
                CarId = carsList[0].Id,
                EngineId = enginesList[0].Id
            },
            new CarEngine
            {
                CarId = carsList[1].Id,
                EngineId = enginesList[1].Id
            },
            new CarEngine
            {
                CarId = carsList[2].Id,
                EngineId = enginesList[2].Id
            }
        };

        private static List<ModelEngine> modelEnginesList = new List<ModelEngine>()
        {
            new ModelEngine
            {
                ModelId = modelsList[0].Id,
                EngineId = enginesList[0].Id
            },
            new ModelEngine
            {
                ModelId = modelsList[1].Id,
                EngineId = enginesList[1].Id
            },
            new ModelEngine
            {
                ModelId = modelsList[2].Id,
                EngineId = enginesList[2].Id
            }
        };
        public static void ExampleSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fuel>().HasData(fuelsList);
            modelBuilder.Entity<Engine>().HasData(enginesList);
            modelBuilder.Entity<Model>().HasData(modelsList);
            modelBuilder.Entity<Car>().HasData(carsList);
            modelBuilder.Entity<CarEngine>().HasData(carEnginesList);
            modelBuilder.Entity<ModelEngine>().HasData(modelEnginesList);
        }
    }
}

