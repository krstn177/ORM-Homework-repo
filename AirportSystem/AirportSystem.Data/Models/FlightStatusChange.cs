using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class FlightStatusChange:BaseModel
    {
        public int? FlightId {get; set;}
        public Flight? Flight { get; set; } = null!;
        public int? FlightStatusId {get; set;}
        public FlightStatus? FlightStatus { get; set; } = null!;
        public DateTime ChangedAt {get; set;}
    }
}