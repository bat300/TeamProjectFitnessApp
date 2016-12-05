using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class PersonInfo
    {
        public int Id { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; } //см
        public double Weight { get; set; } //кг
        public int Lifestyle { get; set; }
    }
}
