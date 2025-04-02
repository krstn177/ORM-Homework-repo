using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Ticket:BaseModel
    {
        public decimal TicketPrice {get; set;}
        public string Type {get; set;}
        public ushort SeatNumber {get; set;}
        public bool PaymentSuccess {get; set;}
        public int? PayrollId {get; set;}
        public Payroll? Payroll {get; set;}
        public int FlightId {get; set;}
        public Flight Flight {get; set;}
        public int UserId {get; set;}

    }
}