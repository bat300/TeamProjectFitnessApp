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
        StartPage Start = new StartPage();
        PageWithDiary Diary = new PageWithDiary();
        PageWithPersonalData PersonalData = new PageWithPersonalData();
        PageOfAnalysis Analysis = new PageOfAnalysis();
        PageWithRation Ration = new PageWithRation();

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            MainFrame.Content = Start;
            Start.ChooseNewUser.Click += ChooseNewUser_Click;
            Start.GoToPageWithDiary.Click += GoToPageWithDiary_Click;
            PersonalData.GoToPageWithRation.Click += GoToPageWithRation_Click;
            PersonalData.GoToPageWithRation.Click += InitPageWithRation;
            Ration.GoToPageOfAnalysis.Click += GoToPageOfAnalysis_Click;
            Ration.GoToPageWithDiary.Click += GoToPageWithDiary_Click; ;
            Diary.GoToPageOfAnalysis.Click += GoToPageOfAnalysis_Click;
            Diary.GoToPageWithRation.Click += GoToPageWithRation_Click;
        }

        private void InitPageWithRation(object sender, RoutedEventArgs e) {
            Ration.Init();
        }

        private void GoToPageWithDiary_Click(object sender, RoutedEventArgs e) {
            MainFrame.Content = Diary;
        }

        private void GoToPageOfAnalysis_Click(object sender, RoutedEventArgs e) {
            MainFrame.Content = Analysis;
        }

        private void GoToPageWithRation_Click(object sender, RoutedEventArgs e) {
            MainFrame.Content = Ration;
        }

        private void ChooseNewUser_Click(object sender, RoutedEventArgs e) {
            MainFrame.Content = PersonalData;
        }
    }
}


