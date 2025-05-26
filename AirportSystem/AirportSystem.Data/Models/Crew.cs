using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class Crew:BaseModel
    {
        public string Name {get; set;}
        public int? RoleId {get; set;}
        public Role? Role { get; set; } = null!;
        public ICollection<Airplane> Airplanes { get; set; } = new List<Airplane>();
    }
}