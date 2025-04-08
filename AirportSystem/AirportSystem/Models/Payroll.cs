using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Payroll:BaseModel
    {
        public double Total { get; set; }
        public int? PassengerId {get; set;}
        public Passenger? Passenger { get; set; } = null!;

        public int? TicketId {get; set;}
        public Ticket? Ticket { get; set; } = null!;
    }
}