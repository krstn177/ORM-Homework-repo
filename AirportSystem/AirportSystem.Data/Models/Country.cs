using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class Country:BaseModel
    {
        public string CountryName { get; set; }
        public int? ContinentId { get; set; }
        public Continent? Continent { get; set; } = null!;
        public ICollection<City> Cities { get; set; } = new List<City>();   
    }
}