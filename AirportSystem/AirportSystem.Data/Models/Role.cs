using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class Role:BaseModel
    {
        public string RoleName { get; set; }
        public ICollection<Crew> Crews { get; set; } = new List<Crew>();
    }
}