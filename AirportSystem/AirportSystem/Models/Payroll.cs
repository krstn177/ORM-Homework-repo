using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Payroll:BaseModel
    {
        public int PassengerId {get; set;}
        public Passenger Passenger {get; set;}
    }
}