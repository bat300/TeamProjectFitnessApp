using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class Diary
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }        
        public List<DiaryItem> DiaryItems { get; set; }
        public PersonNorm PersonNorm { get; set; }
    }
}
