using System.Windows;

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
            MainFrame.Content = Start;
            Start.ChooseNewUser.Click += GoToPageWithPersonalData_Click;
            Start.ChooseOldUser.Click += GoToPageWithPersonalData_Click;
            PersonalData.GoToPageWithRation.Click += GoToPageWithRation_Click;
            Ration.GoToPageOfAnalysis.Click += GoToPageOfAnalysis_Click;
            Ration.GoToPageWithDiary.Click += GoToPageWithDiary_Click; ;
            Diary.GoToPageOfAnalysis.Click += GoToPageOfAnalysis_Click;
            Diary.GoToPageWithRation.Click += GoToPageWithRation_Click;
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


