using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessDietApp.Data
{
    [Table("Products")]
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Сalories { get; set; }        
    }
}
