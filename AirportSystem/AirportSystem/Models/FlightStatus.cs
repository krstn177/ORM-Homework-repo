using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class FlightStatus:BaseModel
    {
        public string Status {get; set;} = null;
        public ICollection<Flight> Flights {get; set;}
        public ICollection<FlightStatusChange> FlightStatusChanges {get; set;}
    }
}