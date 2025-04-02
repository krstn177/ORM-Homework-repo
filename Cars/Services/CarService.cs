using Cars.Context;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Services
{
    public class CarService
    {
        private readonly ApplicationDbContext _context;
        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id) 
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public Model GetModelById(int id)
        {
            return _context.Models.FirstOrDefault(m => m.Id == id);
        }

        public List<Engine> GetAllEngines()
        {
            return _context.Engines.ToList();
        }

        public List<Model> GetAllModels()
        {
            return _context.Models.ToList();
        }

        public List<Fuel> GetAllFuels()
        {
            return _context.Fuels.ToList();
        }
    }
}
