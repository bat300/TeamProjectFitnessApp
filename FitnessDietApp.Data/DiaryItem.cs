using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    [Table("DiaryItems")]
    public class DiaryItem
    {
        public int Id { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
                
    }
}
