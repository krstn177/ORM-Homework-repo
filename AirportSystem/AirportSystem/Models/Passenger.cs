using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportSystem.BaseModels;

namespace AirportSystem.Models
{
    public class Passenger:BaseModel
    {
        public string Name {get; set;}
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}