using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class Continent:BaseModel
    {
        public string ContinentName {get; set;}
        public ICollection<Country> Countries {get; set;} = new List<Country>();
    }
}