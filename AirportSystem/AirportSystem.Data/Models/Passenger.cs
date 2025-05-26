using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class Passenger:BaseModel
    {
        public string Name {get; set;}
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}