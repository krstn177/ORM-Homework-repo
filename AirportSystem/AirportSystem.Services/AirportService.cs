using AirportSystem.Data;
using AirportSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportSystem.Services
{
    public class AirportService
    {
        private AirportDbContext _context;
        public AirportService(AirportDbContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights.Include(flight => flight.Crews).ToListAsync();
        }

        public async Task<List<Flight>> GetFilteredFlightsAsync()
        {

        }
    }
}
