using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

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
