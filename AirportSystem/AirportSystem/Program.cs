using AirportSystem.Data;
using AirportSystem.Data.Models;
using AirportSystem.Services;

namespace AirportSystem;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AirportDbContext())
        {
            AirportService service = new AirportService(context);

            Task<List<Flight>> flightsTask = service.GetAllFlightsAsync();

            flightsTask.Wait();

            var allFlights = flightsTask.Result;

            foreach (Flight flight in allFlights)
            {
                Console.WriteLine(flight.FlightDuration);
                Console.WriteLine(flight.FlightDate);
                Console.WriteLine();
            }
        }
    }
}
