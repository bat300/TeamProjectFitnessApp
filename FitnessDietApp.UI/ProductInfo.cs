
namespace FitnessDietApp.UI
{
    public class ProductInfo
    {
        public ProductInfo(string date, string productName, double weight)
        {
            Date = date;
            ProductName = productName;
            Weight = weight;
        }
        public string Date { get; private set;  }
        public string ProductName { get; private set; }
        public double Weight { get; private set; }
    }
}
