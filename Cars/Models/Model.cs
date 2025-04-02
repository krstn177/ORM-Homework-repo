using Cars.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Model : BaseModel
    {
        public string Name { get; set; }
        public double MaxSpeed { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public int? CarId { get; set; }
        public Car? Car { get; set; }
        public ICollection<ModelEngine> ModelEngines { get; set; } = new List<ModelEngine>(); 
    }
}
