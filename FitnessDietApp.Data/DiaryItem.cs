using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class DiaryItem
    {
        public int Id { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
                
    }
}
