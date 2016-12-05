using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class PersonNorm
    {
        public int Id { get; set; }
        public DateTime DateOfBegin { get; set; }
        public DateTime DateOfChange { get; set; }
        public double Proteins { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public int Сalories { get; set; }
        public PersonInfo Parametrs { get; set; }
    }
}
