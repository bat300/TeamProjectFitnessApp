using FitnessDietApp.Data;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FitnessDietApp.UI {
    /// <summary>
    /// Логика взаимодействия для PageWithDiary.xaml
    /// </summary>
    public partial class PageWithDiary : Page {
        public PageWithDiary() {
            InitializeComponent();
        }

        public void Init() {
            try {
                using (var context = new Context()) {
                    if (context.Diary.Count() >= 2) {
                        GoToPageOfAnalysis.IsEnabled = true;
                    } else {
                        GoToPageOfAnalysis.IsEnabled = false;
                    }

                    StringBuilder intervals = new StringBuilder();
                    var infoProDaySummarising = new InfoProDaySummarising();
                    var deviations = Factory.Default.GetDeviationsCalculating();
                    FullTableOfComponents.Items.Clear();

                    foreach (var diary in context.Diary.Include("PersonNorm").Include("DiaryItems").Include("DiaryItems.Product")) {
                        intervals.Append(string.Format("{0}/{1}/{2}/{3} ",
                            ((diary.PersonNorm.CaloriesUp + diary.PersonNorm.CaloriesLow) / 2).ToString("F2"),
                            ((diary.PersonNorm.ProteinsUp + diary.PersonNorm.ProteinsLow) / 2).ToString("F2"),
                            ((diary.PersonNorm.FatUp + diary.PersonNorm.FatLow) / 2).ToString("F2"),

                            ((diary.PersonNorm.CarbohydratesUp + diary.PersonNorm.CarbohydratesLow) / 2).ToString("F2")));

                        double proteinsPerDay = infoProDaySummarising.ProteinsPerDay(diary.DiaryItems.ToList());
                        double caloriesPerDay = infoProDaySummarising.CalloriesPerDay(diary.DiaryItems.ToList());
                        double fatsPerDay = infoProDaySummarising.FatsPerDay(diary.DiaryItems.ToList());
                        double carbohydratesPerDay = infoProDaySummarising.CarbohydratesPerDay(diary.DiaryItems.ToList());

                        double deviationOfProteinsPerDay = deviations.DeviationOfProteinsPerDay(proteinsPerDay, diary.PersonNorm);
                        double deviationOfFatsPerDay = deviations.DeviationOfFatsPerDay(fatsPerDay, diary.PersonNorm);
                        double deviationOfCarbohydratesPerDay = deviations.DeviationOfCarbohydratesPerDay(carbohydratesPerDay, diary.PersonNorm);
                        double deviationOfCalloriesPerDay = deviations.DeviationOfCalloriesPerDay(caloriesPerDay, diary.PersonNorm);

                        FullTableOfComponents.Items.Add(new {
                            ProteinsPerDay = proteinsPerDay,
                            ProteinsColor = GetBrushFromDouble(deviationOfProteinsPerDay),
                            CaloriesPerDay = caloriesPerDay,
                            CaloriesColor = GetBrushFromDouble(deviationOfCalloriesPerDay),
                            FatsPerDay = fatsPerDay,
                            FatsColor = GetBrushFromDouble(deviationOfFatsPerDay),
                            CarbohydratesPerDay = carbohydratesPerDay,
                            CarbohydratesColor = GetBrushFromDouble(deviationOfCarbohydratesPerDay),
                            Date = diary.Date.ToString("dd.MM.yyyy"),
                            Products = string.Join("\n", from diaryItem in diary.DiaryItems select diaryItem.Product.Name)
                        });
                    }

                    YourCalculation.Text = intervals.ToString();
                }
            } catch (Exception ex) {
                MessageBox.Show("Ошибка!", ex.Message);
            }

        }


        protected static Brush GetBrushFromDouble(double value) {
            if (value < 0)
                return Brushes.Yellow;
            if (value > 0)
                return Brushes.Red;
            else
                return Brushes.Green;
        }


        private void GoToPageForRecepies_Click(object sender, System.Windows.RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("PageForRecepies.xaml", UriKind.Relative));
        }
    }
}
