using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FitnessDietApp.UI {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        StartPage Start = new StartPage();
        PageWithDiary Diary = new PageWithDiary();
        PageWithPersonalData PersonalData = new PageWithPersonalData();
        //PageOfAnalysis Analysis = new PageOfAnalysis();
        PageWithRation Ration = new PageWithRation();

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try
            {
                MainFrame.Content = Start;
                Start.ChooseNewUser.Click += GoToPageWithPersonalData_Click;
                Start.ChooseOldUser.Click += GoToPageWithPersonalData_Click;
                PersonalData.GoToPageWithRation.Click += GoToPageWithRation_Click;
                Ration.GoToPageOfAnalysis.Click += GoToPageOfAnalysis_Click;
                Ration.GoToPageWithDiary.Click += GoToPageWithDiary_Click;
                Diary.GoToPageOfAnalysis.Click += GoToPageOfAnalysis_Click;
                Diary.GoToPageWithRation.Click += GoToPageWithRation_Click;

                PersonalData.Age.TextChanged += ValidatePositiveInt;
                PersonalData.Weight.TextChanged += ValidatePositiveDouble;
                PersonalData.Height.TextChanged += ValidatePositiveInt;
                Ration.ProductWeight.TextChanged += ValidatePositiveInt;
            }catch(Exception ex)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void ValidatePositiveInt(object sender, TextChangedEventArgs e) {
            var textbox = (TextBox)sender;
            int n = 0;
            if ((int.TryParse(textbox.Text, out n)) && (n > 0))
                textbox.Background = Brushes.White;
            else
                textbox.Background = Brushes.Red;
        }

        private void ValidatePositiveDouble(object sender, TextChangedEventArgs e) {
            var textbox = (TextBox)sender;
            double n = 0;
            if ((double.TryParse(textbox.Text, out n)) && (n > 0))
                textbox.Background = Brushes.White;
            else
                textbox.Background = Brushes.Red;
        }

        private void GoToPageWithDiary_Click(object sender, RoutedEventArgs e) {
            Diary.Init();
            MainFrame.Content = Diary;
        }

        private void GoToPageOfAnalysis_Click(object sender, RoutedEventArgs e) {
            MainFrame.Content = new PageOfAnalysis();// Analysis;
        }

        private void GoToPageWithRation_Click(object sender, RoutedEventArgs e) {
            Ration.Init();
            MainFrame.Content = Ration;
        }

        private void GoToPageWithPersonalData_Click(object sender, RoutedEventArgs e) {
            PersonalData.Init();
            MainFrame.Content = PersonalData;
        }
    }
    
}


