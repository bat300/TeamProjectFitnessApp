using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    class PersonNorm
    {
        public int Id { get; set; }
        public DateTime DateOfBegin { get; set; }
        public DateTime DateOfChange { get; set; }
        public PersonInfo Parametrs { get; set; }
    }
}
