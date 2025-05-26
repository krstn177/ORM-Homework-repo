using AirportSystem.Data.BaseModels;

namespace AirportSystem.Data.Models
{
    public class Ticket:BaseModel
    {
        public decimal TicketPrice {get; set;}
        public string Type {get; set;}
        public ushort SeatNumber {get; set;}
        public bool PaymentSuccess {get; set;}
        public Payroll? Payroll { get; set; } = null!;
        public int? FlightId {get; set;}
        public Flight? Flight {get; set;} = null!;
        public int? PassengerId {get; set;}
        public Passenger? Passenger { get; set; } = null!;

    }
}