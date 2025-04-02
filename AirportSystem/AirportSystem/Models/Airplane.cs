using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Airplane:BaseModel
    {
        public ushort SeatsCount { get; set; }
        public ICollection<Airport> Airports { get; set; } = new List<Airport>();
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}