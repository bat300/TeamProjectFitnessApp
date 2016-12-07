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
        public double ProteinsLow { get; set; }
        public double ProteinsUp { get; set; }
        public double FatLow { get; set; }
        public double FatUp { get; set; }
        public double CarbohydratesLow { get; set; }
        public double CarbohydratesUp { get; set; }
        public double Calories { get; set; }
        public double CaloriesLow { get; set; }
        public double CaloriesUp { get; set; }
        public PersonInfo Parametrs { get; set; }
    }
}
