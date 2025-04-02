using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class ModelEngine
    {
        public int ModelId { get; set; }
        public int EngineId { get; set; }
        public Model Model { get; set; } = null!;
        public Engine Engine { get; set; } = null!;
    }
}
