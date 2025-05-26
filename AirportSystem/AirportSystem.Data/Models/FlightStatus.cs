using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class FlightStatus:BaseModel
    {
        public string Status {get; set;} = null!;
        public ICollection<FlightStatusChange> FlightStatusChanges { get; set; } = new List<FlightStatusChange>();
    }
}