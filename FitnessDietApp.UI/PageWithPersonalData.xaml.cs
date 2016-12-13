using FitnessDietApp.Data;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageWithPersonalData.xaml
    /// </summary>
    public partial class PageWithPersonalData : Page
    {
        public PersonInfo Person { get; set; }
        public PageWithPersonalData()
        {
            InitializeComponent();
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {

            Person.Age = int.Parse(Age.Text);
            Person.Weight = double.Parse(Weight.Text);
            Person.Height = int.Parse(Height.Text);
            Person.Gender = ;
        }
    }
}
