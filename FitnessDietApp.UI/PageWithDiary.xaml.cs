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
    /// Логика взаимодействия для PageWithDiary.xaml
    /// </summary>
    public partial class PageWithDiary : Page//в textbox написать все промежутки кбжу
        //белки, жиры, углеводы, калории за день расчитываются в методах класса InfoProDaySummarising
        //для вывода в любом случае нужно писать цикл по элементам DBSet Diary, для каждого элемента нужно использовать 
        //эти методы 
    {
        public PageWithDiary()
        {
            InitializeComponent();
        }
    }
}
