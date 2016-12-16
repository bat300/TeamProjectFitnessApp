using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    [Table("DiaryItems")]
    public class DiaryItem//в UI когда пользователь пишет продукт и количество, создаёшь объект Diary Item ; потом создаёшь объект класса Diary с этим DiaryItem! Если такой продукт в этот день уже есть, прибавляешь количество.
    {
        public int Id { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
                
    }
}
