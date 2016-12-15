using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    [Table("Diary")]
    public class Diary
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }        
        public List<DiaryItem> DiaryItems { get; set; }
        public PersonNorm PersonNorm { get; set; }
    }
}
