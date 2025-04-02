using Cars.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Fuel : BaseModel
    {
        public string Type { get; set; }
        public ICollection<Engine> Engines { get; set; } = new List<Engine>();
    }
}
