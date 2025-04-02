using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class CarEngine
    {
        public int CarId { get; set; }
        public int EngineId { get; set; }
        public Car Car { get; set; } = null!;
        public Engine Engine { get; set; } = null!;
    }
}
