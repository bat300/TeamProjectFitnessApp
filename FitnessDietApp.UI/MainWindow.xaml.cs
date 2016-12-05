using FitnessDietApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessDietApp.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var c = new Context())
            {
                //List<Products> products = new List<Products>();

                //using (var reader = new StreamReader("../../../products.csv"))
                //{
                //    string line = reader.ReadLine();
                //    while (!reader.EndOfStream)
                //    {
                //        line = reader.ReadLine();
                //        var values = line.Split(';');
                //        if (values.Length == 5)
                //        {
                //            products.Add(new Products()
                //            {
                //                Name = values[0],
                //                Proteins = double.Parse(values[1]),
                //                Fat = double.Parse(values[2]),
                //                Carbohydrates = double.Parse(values[3]),
                //                Сalories = int.Parse(values[4])
                //            });
                //        }
                //    }
                //}
            }
        }
    }
}

