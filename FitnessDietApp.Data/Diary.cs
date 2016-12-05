using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    class Diary
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Products> Products { get; set; }
    }
}
