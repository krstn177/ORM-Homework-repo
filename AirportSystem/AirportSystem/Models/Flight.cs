using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Flight:BaseModel
    {
        public int FlightDuration {get; set;}
        public DateTimeOffset FlightDate {get; set;}
        public ushort PassengerCount {get; set;}
        public FlightStatus Status {get; set;}
        public ICollection<FlightStatusChange> FlightStatusChanges {get; set;}
        public ICollection<Crew> Crews {get; set;}
        public int AirplaneId {get; set;}
        public Airplane Airplane {get; set;}
    }
}