using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class City:BaseModel
    {
        public string CityName { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; } = null!;
        public ICollection<Airport> Airports { get; set; } = new List<Airport>();
    }
}