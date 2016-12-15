using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.UI
{
    class ProductInfo
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
