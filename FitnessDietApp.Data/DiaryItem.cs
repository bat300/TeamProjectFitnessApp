using System.ComponentModel.DataAnnotations.Schema;

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
