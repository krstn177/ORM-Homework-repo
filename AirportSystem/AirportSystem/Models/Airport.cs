using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Airport:BaseModel
    {
        public string AirportName { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; } = null!;
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
        
    }
}