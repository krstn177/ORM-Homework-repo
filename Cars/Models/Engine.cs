using Cars.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Engine : BaseModel
    {
        public string Name { get; set; }
        public int MaxRPM { get; set; }
        public int HorsePower { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
        public ICollection<ModelEngine> ModelEngines { get; set; } = new List<ModelEngine>();
        public ICollection<CarEngine> CarEngines { get; set; } = new List<CarEngine>();
    }
}
