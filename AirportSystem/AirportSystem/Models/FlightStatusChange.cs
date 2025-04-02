using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class FlightStatusChange:BaseModel
    {
        public int FlightId {get; set;}
        public int FlightStatusId {get; set;}
        public DateTime ChangedAt {get; set;}
    }
}