using FitnessDietApp.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        PersonInfo Person;
        StartPage Start = new StartPage();
        PageWithDiary Diary = new PageWithDiary();
        PageWithPersonalData PersonalData = new PageWithPersonalData();
        PageOfAnalysis Analysis = new PageOfAnalysis();
        PageWithRation Ration = new PageWithRation();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //CurrentPage = MainFrame.Content as Page;
            MainFrame.Content = Start;
            Start.ChooseNewUser.Click += ChooseNewUser_Click;
        }

        private void ChooseNewUser_Click(object sender, RoutedEventArgs e)
        {
            Person = new PersonInfo();
            PersonalData.Person = Person;
            MainFrame.Content = PersonalData;
        }
    }
}


