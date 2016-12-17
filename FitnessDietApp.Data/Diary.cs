using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<DiaryItem> DiaryItems { get; set; } = new ObservableCollection<DiaryItem>();
        public PersonNorm PersonNorm { get; set; }
    }
}
