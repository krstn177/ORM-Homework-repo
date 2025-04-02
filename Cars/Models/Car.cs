using Cars.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Car : BaseModel
    {
        public int YearOfManufacture { get; set; }
        public string Name { get; set; }
        public ICollection<CarEngine> CarEngines { get; } = new List<CarEngine>();
        public ICollection<Model> Models { get; } = new List<Model>();
    }
}
